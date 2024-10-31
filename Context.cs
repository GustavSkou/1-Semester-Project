/* Context class to hold all context relevant to a session.
 */

class Context
{
    Space currentSpace;
    bool done = false;
    Dictionary<Space,bool> completedSpaces;
    Space[] spaces;

    public Context(Space startNode, Space[] spaces)
    {
        this.spaces = spaces;
        currentSpace = startNode;
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
        if(IsAllSpacesComplete())
        {
            MakeDone();
        }

        Space next = currentSpace.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine("You are confused, and walk in a circle looking for '" + direction + "'. In the end you give up 😩");
        }
        else
        {
            SetSpaceComplete(currentSpace);

            currentSpace.Goodbye();                         //gør ikke noget
            currentSpace = next;
            currentSpace.Welcome();
            currentSpace.Destription();
            currentSpace.SetNextSpaces(GetCompletedSpaces());
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
            if (!completedSpaces[space])
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
            this.completedSpaces[space] = true;
        }
        else
        {
            return;
        }
    }
}