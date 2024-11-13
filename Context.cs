/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;

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
    
    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
    }

    public void AnswerQuestion(int choiceNum)
    {
        if (currentSpace.SpaceAnswerChoices[choiceNum].value)
        {
            Console.WriteLine("Correct answer");
            currentSpace.Complete = true;
        }
        else
        {
            Console.WriteLine("Sorry wrong answer");
        }
        
        inQuestion = false;
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
                if (IsAllBiomesComplete()) Quit();
                nextBiome = world.SetNextBiome(currentBiome);
            }
        }
        
        Space nextSpace = currentSpace.FollowEdge(direction);
        if (IsDirectionToNewBiome(direction)) //world.Biomes.Any(biome => biome.Name == direction)
        {
            Console.WriteLine("you are now in a new biome");
            currentBiome = nextBiome;
        }
        

        currentSpace.Goodbye();
        currentSpace = nextSpace;
        currentSpace.Welcome();
        if (currentSpace.SpaceDestription != null) currentSpace.Destription();

        if (currentSpace.SpaceQuestion != null && !currentSpace.Complete) 
        {
            currentSpace.Question();   
            inQuestion = true;
        }
        else
        {
            currentSpace.Exits();
            currentSpace.Complete = true;
        }
    }

    private bool IsAllSpacesComplete()
    {
        foreach (Space space in currentBiome.Spaces)
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

    private bool IsDirectionToNewBiome(string direction)
    {
        foreach (Biome biome in world.Biomes)
        {
            if (biome.Name == direction) return true;
        }
        return false;
    }

    private void Quit()
    {
        done = true;
        return;
    }
}