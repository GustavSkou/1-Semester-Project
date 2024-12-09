public class Question
{
    public required string QuestionPrompt { get; set; }
    public required Dictionary<string, AnswerChoice> Choices { get; set; }

    /* The Question class represents a question with multiple choices.
    It has two properties: "QuestionPrompt" and "Choices".
    - "QuestionPrompt" is a string that contains the text of the question.
    - "Choices" is a dictionary where the key is a string representing the player's choice (e.g., "1", "2", "3"),
    and the value is an instance of the AnswerChoice class.
    This class is also used for deserializing questions from a JSON file that contains the spaces. */
}

public class AnswerChoice
{
    /* The AnswerChoice class represents a possible answer to a question.
    It has three properties: */

    // "Description" is a string that describes the answer choice.
    public string? Description { get; set; }

    // "Correct" is a boolean indicating whether the answer is correct.
    public bool Correct { get; set; }

    /* "Action" is a delegate that encapsulates a method with a single parameter of type Context.
    This method is executed when the answer is selected.
    The Action property is used in the "AnswerCommand" class to invoke the corresponding method for the chosen answer. */
    public Action<Context>? Action { get; set; }
}