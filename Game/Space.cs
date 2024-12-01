/* Space class for modeling spaces */

public class Space : Node, IPrintable
{
    private string description, biome;
    private Question quest;
    private bool complete;
    private InfoCard infoCard;
    private SpaceQuestion spaceQuestion = new SpaceQuestion();

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

    public Question Quest 
    {
        get {return quest;}
        set 
        {
            quest = value;        
            foreach (var choice in quest.Choices)
            {
                choice.Value.Action = choice.Value.Correct ? spaceQuestion.CorrectAnswer : spaceQuestion.WrongAnswer;
            }
        }
    }

    public InfoCard InfoCard 
    {

        get {return infoCard;}
        set {infoCard = value;}
    }
    public string Biome
    {
        get {return biome;}
        set {biome = value;}
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
        Print(description);
        Console.WriteLine();
    }
    
    public void DisplayQuestion(Context context)
    {
        context.InQuestion = true;
        context.CurrentQuestion = quest;
        
        Print(quest.QuestionPromt);
        int choiceNumber = 1;
        foreach (string choice in quest.Choices.Select(spaceAnswerChoices => spaceAnswerChoices.Value.Choice).ToArray())
        {  
            Print($"{choiceNumber}. {choice}");
            choiceNumber++;
        }
    }

    public void DisplayGoodbye()
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
            Thread.Sleep(0);
            index++;

            if (index > 50 && letter == ' ' || index > 30 && letter == '.') {
                Console.WriteLine();
                index = 0;
            }
        }
        Console.WriteLine();
    }
}