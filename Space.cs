/* Space class for modeling spaces (rooms, caves, ...) */

public class Space : Node, IPrint
{
    protected string[] paths;
    public string[] Paths 
    {
        get {return paths;}
        set {paths = value;}
    }
    protected bool answer;

    protected string spaceDestription, spaceQuestion;
    public Space(String name) : base(name)
    {
        answer = false;
    }

    public void Welcome()
    {
        Print($"You are now at {name}");
    }

    public void Exits()
    {
        HashSet<string> exits = edges.Keys.ToHashSet();
        Print("Current exits are:");

        foreach (string exit in exits)
        {
            Print($" - {exit}");
        }
    }

    public void Destription()
    {
        Print(spaceDestription);
    }
    
    public void Question()
    {
        Print(spaceQuestion);
    }

    public void Goodbye()
    {
    }

    public override Space FollowEdge(string direction)
    {
        return (Space) base.FollowEdge(direction);
    }

    public void Print(string someString)
    {
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(25);
        }
        Console.WriteLine();
    } 
}