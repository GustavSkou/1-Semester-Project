public class CommandQuest : BaseCommand, ICommand
{
    public CommandQuest()
    {
        description = "Get current question";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.CurrentQuestion == null) context.AddMessage("No questions available");
        else if (context.CurrentSpace.Complete)
        {
            context.AddMessage("This space is completed");
        }
        else
        {
            context.AddMessage("(CLEAR)");
            context.AddMessage(context.CurrentQuestion.QuestionPrompt);

            foreach (var choice in context.CurrentQuestion.Choices)
            {
                context.AddMessage($" - {choice.Key} {choice.Value.Description}");
            }
            context.InQuestion = true;
        }
    }
}