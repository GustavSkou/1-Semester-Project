/* Context class to hold all context relevant to a session. */
public class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;
    private QuestionType currentQuestionType;
    private bool done, inQuestion;

    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public bool Done
    {
        get { return done; }
        set { done = value; }
    }

    public bool InQuestion
    {
        get { return inQuestion; }
        set { inQuestion = value; }
    }

    public QuestionType CurrentQuestionType
    {
        get { return currentQuestionType; }
        set { currentQuestionType = value; }
    }

    public enum YesNo
    {
        yes = 0,
        no = 1
    }

    public enum QuestionType
    {
        boolean,
        numerical
    }

    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
    }

    public void AnswerQuestion(int choiceNum)
    {
        if (currentSpace.Quest.Choices[choiceNum].Correct)
        {
            Console.WriteLine("Correct answer");
            currentBiome.Spaces[currentSpace.Name].Complete = true;

            inQuestion = false;
            if (IsAllSpacesComplete())            
            {
                if (!currentBiome.Complete)
                {      
                    world.BiomesSet[currentBiome.Name].Complete = true;
                    if (IsAllBiomesComplete()) QuitGame();
                    nextBiome = world.SetNextBiome(currentBiome, currentSpace);                    
                }
            }
            else {
                currentBiome.SetNextSpace(currentSpace);
            }
            DisplayContext();
        }
        else {
            currentSpace.Print("Sorry wrong answer");
            currentSpace.TryAgain(this);
        }
    }

    public void AnswerQuestion(YesNo answer)
    {
        if (answer == YesNo.yes)
        {
            currentSpace.DisplayQuestion(this);
        }
        else if (answer == YesNo.no)
        {
            if (currentBiome.Spaces.Values.Where(space => space.Complete == false).Count() > 1) currentBiome.SetNextSpace(currentSpace);
            currentSpace.DisplayExits();
        }
        else
        {
            throw new Exception($"{answer} is not part of YesNo enum");
        }
    }

    public void Transition(string direction)
    {
        Console.Clear();
        currentSpace.DisplayGoodbye();

        Space nextSpace = currentSpace.FollowEdge(direction);

        if (IsAllSpacesComplete())
        {
            if (!currentBiome.Complete)
            {
                world.BiomesSet[currentBiome.Name].Complete = true;
                if (IsAllBiomesComplete()) QuitGame();
                nextBiome = world.SetNextBiome(currentBiome, currentSpace);
            }
        }

        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;
        currentSpace = nextSpace;
        currentSpace.DisplayWelcome();
        DisplayContext();        
    }

    public void DisplayContext()
    {
        if (currentSpace.Description != null) currentSpace.DisplayDestription();
        if (currentSpace.Quest != null && !currentSpace.Complete) currentSpace.DisplayQuestion(this);
        if (!inQuestion)
        {
            currentSpace.DisplayExits();
        }
        return;
    }

    private bool IsAllSpacesComplete()
    {
        foreach (Space space in currentBiome.Spaces.Values)
        {
            if (space.Complete == false) return false;
        }
        return true;
    }

    private bool IsAllBiomesComplete()
    {
        foreach (Biome biome in world.BiomesSet.Values)
        {
            if (biome.Complete == false) return false;
        }
        return true;
    }

    private void QuitGame()
    {
        done = true;
        return;
    }
}