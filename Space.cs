/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node
{
    protected bool isDone = false;
    protected string[] paths;
    protected string spaceDestription;
    public Space(String name) : base(name)
    {
    }

    public void Welcome()
    {
        Print($"You are now at {name}");
    }

    public void Exits()
    {
        HashSet<string> exits = edges.Keys.ToHashSet();
        Print("Current exits are:");

        foreach (String exit in exits)
        {
            Print($" - {exit}");
        }
    }

    public virtual void Destription()
    {
        Print(spaceDestription);
    }

    public void Goodbye()
    {
        this.isDone = true;
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

    protected void Print(string someString)
    {
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }
}
