/* Space class for modeling spaces */

abstract class Space : Node, IPrintable
{
    protected string spaceDestription, spaceQuestion, infoCard;

    protected (string answer, bool value)[] spaceAnswerChoices;

    protected bool complete;

    public string SpaceDestription
    {
        get {return spaceDestription;}
    }

    public bool Complete
    {
        get {return complete;}
        set {complete = value;}
    }

    public (string someAnswer, bool value)[] SpaceAnswerChoices
    {
        get {return spaceAnswerChoices;}
    }

    public string SpaceQuestion
    {
        get {return spaceQuestion;}
    }

    public Space(String name) : base(name)
    {
        spaceQuestion = null;
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
        int answerChoiceNumber = 1;
        foreach (string answerChoice in spaceAnswerChoices.Select(spaceAnswerChoices => spaceAnswerChoices.answer).ToArray())
        {  
            Print($"{answerChoiceNumber}. {answerChoice}");
            answerChoiceNumber++;
        }
    }

    public void Goodbye()
    {
        Print($"You left the {name}\n");
    }

    public override Space FollowEdge(string direction)
    {
        return (Space) base.FollowEdge(direction);
    }

    public void Print(string someString)
    {
        int index = 0;
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(10);
            index++;

            if (index > 50 && letter == ' ' || index > 30 && letter == '.') {
                Console.WriteLine();
                index = 0;
            }
        }
        Console.WriteLine();
    }    
}