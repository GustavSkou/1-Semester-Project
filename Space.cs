/* Space class for modeling spaces */

abstract public class Space : Node, IPrintable
{
    protected string[] paths;

    protected string spaceDestription, spaceQuestion;

    protected bool answer;

    public string[] Paths 
    {
        get {return paths;}
        set {paths = value;}
    }

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
        string[] exits = edges.Keys.ToArray();
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
            Thread.Sleep(0);
        }
        Console.WriteLine();
    } 
}