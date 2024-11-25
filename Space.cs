/* Space class for modeling spaces */

class Space : Node, IPrintable
{
    private string description, infoCard, biome;
    private Question quest;
    private bool complete;

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
                choice.Value.Action = choice.Value.Correct ? CorrectAnswer : WrongAnswer;
            }
        }
    }

    public void CorrectAnswer(Context context)
    {
        Console.WriteLine("Correct answer");
        context.CurrentBiome.Spaces[name].complete = true;
        context.InQuestion = false;

        if (context.IsAllSpacesComplete())            
        {
            if (!context.CurrentBiome.Complete)
            {      
                context.World.BiomesSet[context.CurrentBiome.Name].Complete = true;
                if (context.IsAllBiomesComplete()) context.QuitGame();
                context.NextBiome = context.World.SetNextBiome(context.CurrentBiome, context.CurrentSpace);                    
            }
        }
        else {
            context.CurrentBiome.SetNextSpace(context.CurrentSpace);
        }
        context.DisplayContext();
    }

    public void WrongAnswer(Context context)
    {
        Print("Sorry wrong answer");
        TryAgain(context);
        Print(context.CurrentQuestion.QuestionPromt);
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

    public void TryAgain(Context context)
    {
        AnswerChoice yes = new AnswerChoice()
        {
            Choice = "yes",
            Action = AnswerYes
        };
        AnswerChoice no = new AnswerChoice()
        {
            Choice = "no",
            Action = AnswerNo
        };
        Question question = new Question()
        {
            QuestionPromt = "Would you like to try again\n - Yes\n - No",
            Choices = new Dictionary<string, AnswerChoice>()
            {
                { yes.Choice, yes },
                { no.Choice, no }
            }
        };
        context.CurrentQuestion = question;
        context.InQuestion = true;
    }
    
    private void AnswerYes(Context context)
    {
        context.CurrentQuestion = quest;
        context.InQuestion = true;
        context.DisplayContext();
    }

    private void AnswerNo(Context context)
    {
        context.CurrentQuestion = null;
        context.InQuestion = false;
        context.CurrentBiome.SetNextSpace(context.CurrentSpace);
        context.DisplayContext();
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