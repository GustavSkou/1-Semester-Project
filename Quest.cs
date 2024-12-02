using System.Collections.Generic;

class Quest
{
    public string QuestionPromt { get; private set; }
    public Dictionary<string, QuestChoice> Choices { get; private set; }

    public Quest(string questionPromt, Dictionary<string, QuestChoice> choices)
    {
        QuestionPromt = questionPromt;
        Choices = choices;
    }

    public bool IsCorrectChoice(string choice)
    {
        return Choices.ContainsKey(choice) && Choices[choice].Correct;
    }
}

class QuestChoice
{
    public string Choice { get; private set; }
    public bool Correct { get; private set; }

    public QuestChoice(string choice, bool correct)
    {
        Choice = choice;
        Correct = correct;
    }
}
