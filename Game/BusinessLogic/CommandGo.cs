/* Command for transitioning between spaces */

public class CommandGo : BaseCommand, ICommand
{
    public CommandGo()
    {
        description = "Go down path";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion)
        {
            string parameter = string.Join(" ", parameters);

            try
            {
                context.AddMessage("(CLEAR)");
                context.Transition(parameter);
            }
            catch (KeyNotFoundException)
            {
                context.AddMessage($"You search for the path {parameter}, but you could not find it");

                context.CurrentSpace.ExitsMessage(context);
            }
        }
        else
        {
            context.AddMessage("(CLEAR)");
            context.AddMessage("You could not find any paths to follow while in a question.");

            context.AddMessage(context.CurrentQuestion.QuestionPrompt);
            foreach (var choice in context.CurrentQuestion.Choices)
            {
                context.AddMessage($" - {choice.Key} {choice.Value.Description}");
            }
        }
    }
}