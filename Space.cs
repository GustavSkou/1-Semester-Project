/* Space class for modeling spaces */

class Space : Node, IPrintable
{
    protected string description, infoCard;
    protected Quest <string, bool> question;

    protected bool complete;

    protected string biome;

    public Quest <string, bool> Question
    {
        get {return question;}
        set {question = value;}
    }

    public string Description
    {
        get {return description;}
        set {description = value;}
    }

    public bool Complete
    {
        get {return complete;}
        set {complete = value;}
    }

    public string QuestionDescription
    {
        set {question.Description = value;}
    }

    public QuestAnswers <string, bool> [] QuestionAnswers 
    {
        set {question.Answers = value;}
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

    public void DisplayDescription()
    {
        Print(description);
        Console.WriteLine();
    }
    
    public void DisplayQuestion(Context context)
    {

        context.InQuestion = true;
        context.CurrentQuestionType = Context.QuestionType.numerical;
        
        Print(question.Description);
        int answerChoiceNumber = 1;
        foreach (string answerChoice in question.Answers.Select(spaceAnswerChoices => spaceAnswerChoices.Answer).ToArray())
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
            Thread.Sleep(10);
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
            Thread.Sleep(10);
        }
        Console.WriteLine();
    }    
}

/*class AnswerChoice 
{
    public string Answer {get; set;}
    public bool IsCorrect {get; set;}
}*/