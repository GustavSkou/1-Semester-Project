/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;

    private World world;

    private Dictionary<Space,bool> completedSpaces = [];

    private bool done;

    public Space CurrentSpace
    {
        get {return currentSpace;}
    }

    public bool Done 
    {
        get {return done;}
        set {done = value;}
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
        }
    }

    public void Transition(string direction)
    {
        SetSpaceComplete(currentSpace);

        if(IsAllSpacesComplete())
        {
            done = true;
            return;
        }



        Space nextSpace = currentSpace.FollowEdge(direction);
        
        Console.Clear();
        currentSpace.Goodbye();
        currentSpace = nextSpace;
        currentSpace.Welcome();
        currentSpace.Destription();
        world.SetNextSpaces(currentSpace, completedSpaces);
        currentSpace.Exits();
        
    }

    public bool IsAllSpacesComplete()
    {
        foreach (Space space in world.Spaces)
        {
            if (completedSpaces[space] == false)
            {
                return false; 
            }
        }
        return true;
    }

    private void SetSpaceComplete(Space space)
    {
        if (completedSpaces.ContainsKey(space))
        {
            completedSpaces[space] = true;
        }
        else
        {
            return;
        }
    }
}