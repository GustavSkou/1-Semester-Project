/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;
    private Question currentQuestion;
    private bool done, inQuestion;

    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public Question CurrentQuestion
    {
        get {return currentQuestion;}
        set {currentQuestion = value;}
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

    public Biome CurrentBiome
    {
        get { return currentBiome; }
        set { currentBiome = value; }
    }

    public Biome NextBiome
    {
        get { return nextBiome; }
        set { nextBiome = value; }
    }

    public World World
    {
        get { return world; }
        set { world = value; }
    }

    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
    }

    public void AnswerQuestion(string choice)
    {
        currentQuestion.Choices[choice].Action.Invoke(this);




        /*if (currentSpace.Quest.Choices[choice].Correct)
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
        }*/
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
        if (currentSpace.Quest != null && !currentSpace.Complete)
        {
            currentSpace.DisplayQuestion(this);
            
        } 
        if (!inQuestion)
        {
            currentSpace.DisplayExits();
        }
        return;
    }

    public bool IsAllSpacesComplete()
    {
        foreach (Space space in currentBiome.Spaces.Values)
        {
            if (space.Complete == false) return false;
        }
        return true;
    }

    public bool IsAllBiomesComplete()
    {
        foreach (Biome biome in world.BiomesSet.Values)
        {
            if (biome.Complete == false) return false;
        }
        return true;
    }

    public void QuitGame()
    {
        done = true;
        return;
    }
}