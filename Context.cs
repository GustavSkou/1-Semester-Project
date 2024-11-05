/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    public Space CurrentSpace
    {
        get {return currentSpace;}
    }
    private Space[] spaces;
    private World world;
    private bool done;
    public bool Done 
    {
        get {return done;}
        set {done = value;}
    }
    private Dictionary<Space,bool> completedSpaces;
    public Dictionary<Space, bool> CompletedSpaces
    {
        get {return completedSpaces;}
    }
    
    public Context(World world)
    {
        this.world = world;
        
        spaces = world.GetSpaces();
        currentSpace = world.GetStartSpace();
        done = false;

        completedSpaces = new Dictionary<Space, bool>();
        foreach (Space space in spaces)
        {
            completedSpaces.Add(space, false);
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
        if (nextSpace == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up");
        }
        else
        {
            Console.Clear();
            currentSpace.Goodbye();
            currentSpace = nextSpace;
            currentSpace.Welcome();
            currentSpace.Destription();
            world.SetNextSpaces(currentSpace, completedSpaces);
            currentSpace.Exits();
        }
    }

    public bool IsAllSpacesComplete()
    {
        foreach (Space space in spaces)
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