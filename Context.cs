/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;

    private bool done, inSpaceQuestion;

    public Space CurrentSpace
    {
        get {return currentSpace;}
    }

    public bool Done 
    {
        get {return done;}
        set {done = value;}
    }

    public bool InSpaceQuestion
    {
        get {return inSpaceQuestion;}
        set {inSpaceQuestion = value;}
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
        }
        else
        {
            currentSpace.Print("Sorry wrong answer\n Would you like to try again?");
            CurrentSpace.Print(" - Yes\n - No");
        }
        
        inSpaceQuestion = false;

        if (IsAllSpacesComplete()) 
        {
            if (!currentBiome.Complete)
            {
                currentBiome.Complete = true;
                if (IsAllBiomesComplete()) QuitGame();
                nextBiome = world.SetNextBiome(currentBiome, currentSpace);
            }
        }
        currentSpace.Exits();
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
        if (!inSpaceQuestion) 
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