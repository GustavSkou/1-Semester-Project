/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;

    private QuestionType currentQuestionType;

    private bool done, inQuestion;

    public Space CurrentSpace
    {
        get {return currentSpace;}
    }

    public bool Done 
    {
        get {return done;}
        set {done = value;}
    }

    public bool InQuestion
    {
        get {return inQuestion;}
        set {inQuestion = value;}
    }

    public QuestionType CurrentQuestionType
    {
        get {return currentQuestionType;}
        set {currentQuestionType = value;}
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
        if (currentSpace.SpaceAnswerChoices[choiceNum].IsCorrect)
        {
            Console.WriteLine("Correct answer");
            currentSpace.Complete = true;
            inQuestion = false;
            currentSpace.Exits();
        }
        else
        {
            currentSpace.Print("Sorry wrong answer");
            currentSpace.TryAgain(this);
        }
        
        if (IsAllSpacesComplete()) 
        {
            if (!currentBiome.Complete)
            {
                currentBiome.Complete = true;
                if (IsAllBiomesComplete()) QuitGame();
                nextBiome = world.SetNextBiome(currentBiome, currentSpace);
            }
        }
    }

    public void AnswerQuestion(YesNo answer)
    {
        if (answer == YesNo.yes)
        {
            currentSpace.Question(this);
        }
        else if (answer == YesNo.no)
        {
            currentSpace.Exits();
            
        }
        else
        {
            throw new Exception($"{answer} is not part of YesNo enum");
        }
    }

    public void Transition(string direction)
    {
        Console.Clear();
        
        if (IsAllSpacesComplete()) 
        {
            if (!currentBiome.Complete)
            {
                currentBiome.Complete = true;
                if (IsAllBiomesComplete()) QuitGame();
                nextBiome = world.SetNextBiome(currentBiome, currentSpace);
            }
        }
        
        Space nextSpace = currentSpace.FollowEdge(direction);

        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;

        currentSpace.Goodbye();
        currentSpace = nextSpace;
        currentSpace.Welcome();
        if (currentSpace.SpaceDestription != null) currentSpace.Destription();
        if (currentSpace.SpaceQuestion != null && !currentSpace.Complete) currentSpace.Question(this);   
        if (!inQuestion) 
        {
            currentSpace.Exits();
            currentSpace.Complete = true;
        }
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
        foreach (Biome biome in world.Biomes)
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