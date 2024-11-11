/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private World world;
    private Dictionary<Space,bool> completedSpaces = [];
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

    public Dictionary<Space, bool> CompletedSpaces
    {
        get {return completedSpaces;}
    }
    
    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;

        foreach (Space space in world.Spaces)
        {
            completedSpaces.Add(space, false);
        }
    }

    public void AnswerQuestion(int choiceNum)
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
        world.SetNextSpaces(currentSpace, completedSpaces);
        currentSpace.Exits();
    }

    public void Transition(string direction)
    {
        Console.Clear();
        Space nextSpace = currentSpace.FollowEdge(direction);
        
        currentSpace.Goodbye();
        currentSpace = nextSpace;
        currentSpace.Welcome();
        currentSpace.Destription();
        currentSpace.Question();
        inQuestion = true;
    }

    private bool IsAllSpacesComplete()
    {
        if (completedSpaces.ContainsValue(false))
        {
            return false;
        }
        return true;
    }

    private void SetSpaceComplete(Space space)
    {
        if (completedSpaces.ContainsKey(space))
        {
            completedSpaces[space] = true;
        }
    }
}