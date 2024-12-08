public class Question
{
    public required string QuestionPrompt { get; set; }
    public required Dictionary<string, AnswerChoice> Choices { get; set; }
}

public class AnswerChoice
{
    public string? Description { get; set; }
    public bool Correct { get; set; }
    public Action<Context>? Action { get; set; }
}