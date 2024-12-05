public class Question
{
    public string? QuestionPrompt { get; set; }
    public Dictionary<string, AnswerChoice>? Choices { get; set; }
}

// The Question class represents a question with multiple choices.
// It has two properties: "QuestionPromt" and "Choices".
// - "QuestionPromt" is a string that contains the text of the question.
// - "Choices" is a dictionary where the key is a string representing the player's choice (e.g., "1", "2", "3"),
//   and the value is an instance of the AnswerChoice class.
//   This class is also used for deserializing questions from a JSON file that contains the spaces.

public class AnswerChoice
{
    public string? Description { get; set; }
    public bool Correct { get; set; }
    public Action<Context>? Action { get; set; }
}

// The AnswerChoice class represents a possible answer to a question.
// It has three properties:
// - "Description" is a string that describes the answer choice.
// - "Correct" is a boolean indicating whether the answer is correct.
// - "Action" is a delegate that encapsulates a method with a single parameter of type Context.
//   This method is executed when the answer is selected.
//   The Action property is used in the "AnswerCommand" class to invoke the corresponding method for the chosen answer.