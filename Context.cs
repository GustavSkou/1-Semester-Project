/* Context class to hold all context relevant to a session. */

class Context
{
    Space currentSpace;
    Space[] spaces;
    World world;
    bool done = false;
    Dictionary<Space,bool> completedSpaces;
    
    public Context(World world)
    {
        this.world = world;
        
        spaces = world.GetSpaces();
        currentSpace = world.GetStartSpace();

        completedSpaces = new Dictionary<Space, bool>();
        foreach (Space space in spaces)
        {
            completedSpaces.Add(space, false);
        }
    }

    public Space GetCurrent()
    {
        return currentSpace;
    }

    public void Transition(string direction)
    {
        SetSpaceComplete(currentSpace);
        if(IsAllSpacesComplete())
        {
            MakeDone();
            return;
        }

        Space next = currentSpace.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up 😩");
        }
        else
        {
            currentSpace.Goodbye();                         //gør ikke noget
            currentSpace = next;
            currentSpace.Welcome();
            currentSpace.Destription();
            world.SetNextSpaces(currentSpace, GetCompletedSpaces());
            currentSpace.Exits();
        }
    }

    public void MakeDone()
    {
        done = true;
    }

    public bool IsDone()
    {
        return done;
    }

    public Dictionary<Space, bool> GetCompletedSpaces()
    {
        return completedSpaces;
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