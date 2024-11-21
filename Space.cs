/* Space class for modeling spaces */

class Space : Node, IPrintable
{
    protected string spaceDestription, spaceQuestion, infoCard;

    protected AnswerChoice[] spaceAnswerChoices;

    protected bool complete;

    protected string biome;

    public string SpaceDestription
    {
        get {return spaceDestription;}
        set {spaceDestription = value;}
    }

    public bool Complete
    {
        get {return complete;}
        set {complete = value;}
    }

    public AnswerChoice[] SpaceAnswerChoices {
        get {return spaceAnswerChoices;}
        set {spaceAnswerChoices = value;}
    }

    public string SpaceQuestion 
    {
        get {return spaceQuestion;}
        set {spaceQuestion = value;}
    }

    public string Biome
    {
        get {return biome;}
        set {biome = value;}
    }

    public Space()
    {
    }

    public void DisplayWelcome()
    {
        Print($"You are now at {name} in {biome}");
    }

    public void DisplayExits()
    {
        string[] exits = edges.Keys.ToArray();
        Print("Current paths are:");

        foreach (string exit in exits)
        {
            Print($" - {exit}");
        }
    }

    public void DisplayDestription()
    {
        Print(spaceDestription);
        Console.WriteLine();
    }
    
    public void DisplayQuestion(Context context)
    {
        context.InQuestion = true;
        context.CurrentQuestionType = Context.QuestionType.numerical;
        
        Print(spaceQuestion);
        int answerChoiceNumber = 1;
        foreach (string answerChoice in spaceAnswerChoices.Select(spaceAnswerChoices => spaceAnswerChoices.Answer).ToArray())
        {  
            Print($"{answerChoiceNumber}. {answerChoice}");
            answerChoiceNumber++;
        }
    }

    public void DisplayGoodbye()
    {
        Print($"You left the {name}\n");
    }

    public void TryAgain(Context context)
    {
        context.CurrentQuestionType = Context.QuestionType.boolean;
        Print("Would you like to try again?");
        Print(" - Yes\n - No");
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
            Thread.Sleep(0);
            index++;

            if (index > 50 && letter == ' ' || index > 30 && letter == '.') {
                Console.WriteLine();
                index = 0;
            }
        }
        Console.WriteLine();
    }

    public void Print(string someString, bool autoNewLine)
    {
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(0);
        }
        Console.WriteLine();
    }    
}

class AnswerChoice 
{
    public string Answer {get; set;}
    public bool IsCorrect {get; set;}
}