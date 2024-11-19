class Quest <Type, Result>
{
    private string description;
    private QuestAnswers <Type, Result> [] answers;

    public string Description
    {
        get {return description;}
        set {description = value;}
    }

    public QuestAnswers <Type, Result> [] Answers
    {
        get {return answers;}
        set {answers = value;}
    }
}

class QuestAnswers <Type, Result>
{
    public Type Answer {get; set;}
    public Result IsCorrect {get; set;}    
}