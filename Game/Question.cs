public class Question
{
   public string QuestionPromt {get; set;}
   public AnswerChoice[] Choices {get; set;}
}

public class AnswerChoice 
{
    public string Choice {get; set;}
    public bool Correct {get; set;}
}