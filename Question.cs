class Question
{
   public string QuestionPromt {get; set;}
   public AnswerChoice[] Choices {get; set;}
}

class AnswerChoice 
{
    public string Choice {get; set;}
    public bool Correct {get; set;}
    public Action<Context> Action {get; set;}
}