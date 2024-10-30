/* Context class to hold all context relevant to a session.
 */

class Context
{
    Space current;
    bool done = false;
    Dictionary<Space,bool> isSpaceComplete;
    

    public Context(Space node)
    {
        current = node;
        isSpaceComplete.Add(current, false);

    }

    public Space GetCurrent()
    {
        return current;
    }

    public void Transition(string direction)
    {
        Space next = current.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine("You are confused, and walk in a circle looking for '" + direction + "'. In the end you give up 😩");
        }
        else
        {
            current.Goodbye();
            isSpaceComplete[current] = true; // current.isSpaceComplete
            current = next;
            current.Welcome();
            current.Destription();
            
            current.Exits();
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
}

