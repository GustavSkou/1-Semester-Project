/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node
{
    protected bool isDone = false;
    protected string[] paths;
    public Space(String name) : base(name)
    {
    }

    public void Welcome()
    {
        Console.WriteLine("You are now at " + name);
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");

        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }

    public void Goodbye()
    {
        this.isDone = true;
    }

    public virtual void Destription()
    {
    }

    public virtual string[] GetPaths()
    {
        return paths;
    }

    public bool IsDone()
    {
        return isDone;
    }

    public override Space FollowEdge(string direction)
    {
        return (Space) base.FollowEdge(direction);
    }
}
