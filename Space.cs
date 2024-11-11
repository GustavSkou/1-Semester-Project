/* Space class for modeling spaces */

abstract public class Space : Node, IPrintable
{
    protected string[] paths;

    protected string spaceDestription, spaceQuestion;

    protected (string someAnswer, bool value)[] spaceAnswerChoices;

    protected bool answer;

    public string[] Paths 
    {
        get {return paths;}
        set {paths = value;}
    }

    public (string someAnswer, bool value)[] SpaceAnswerChoices
    {
        get {return spaceAnswerChoices;}
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
        Print("Current paths are:");

        foreach (string exit in exits)
        {
            Print($" - {exit}");
        }
    }

    public void Destription()
    {
        Print(spaceDestription);
        Console.WriteLine();
    }
    
    public void Question()
    {
        Print(spaceQuestion);
        int answerChoiceNumber = 0;
        foreach (string answerChoice in spaceAnswerChoices.Select(tuple => tuple.someAnswer).ToArray())
        {  
            Print($"{answerChoiceNumber}. {answerChoice}");
            answerChoiceNumber++;
        }
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