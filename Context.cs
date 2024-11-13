/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome;
    private World world;

    private HashSet<Space> completedSpaces = [];
    private HashSet<Biome> completedBiomes = [];    

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

    public HashSet<Space> CompletedSpaces
    {
        get {return completedSpaces;}
    }
    
    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
    }

    /*public void AnswerQuestion(int choiceNum)
    {
        if (currentSpace.SpaceAnswerChoices[choiceNum].value)
        {
            SetSpaceComplete(currentSpace);
            Console.WriteLine("Correct answer");

            if(IsAllSpacesComplete())
            {
                done = true;
                return;
            }
        }
        else
        {
            Console.WriteLine("Sorry wrong answer");
        }
        
        inQuestion = false;
        Console.Clear();
        currentSpace.Exits();
    }*/

    public void Transition(string direction)
    {
        Console.Clear();
        Space nextSpace = currentSpace.FollowEdge(direction);
        
        currentSpace.Goodbye();
        currentSpace = nextSpace;
        currentSpace.Welcome();
        
        if (currentSpace.SpaceDestription != null) currentSpace.Destription();

        if (currentSpace.SpaceQuestion != null) 
        {
            currentSpace.Question();
            inQuestion = true;
        }
        else
        {
            currentSpace.Exits();
        }
        currentSpace.Complete = true;
    }
}