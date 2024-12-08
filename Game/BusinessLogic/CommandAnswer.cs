/* Command for Answering questions */

using System.Reflection.Metadata;

class CommandAnswer : BaseCommand, ICommand
{
    public CommandAnswer()
    {
        description = "Use: answer (number)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion || context.CurrentQuestion == null)
        {
            context.AddMessage("No question to answer");
        }
        else if (context.CurrentSpace.Complete)
        {
            context.AddMessage("This space is completed");
        }
        else
        {
            try
            {
                context.CurrentQuestion.Choices[parameters[0]].Action.Invoke(context);
            }
            catch (KeyNotFoundException)
            {
                context.AddMessage("Try again");
            }
        }
    }
}