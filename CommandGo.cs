/* Command for transitioning between spaces */

using System.Reflection.Metadata;

class CommandGo : BaseCommand, ICommand
{
    public CommandGo()
    {
        description = "Follow an exit";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        String parameter = String.Join(" ", parameters);
        Console.Clear();
        context.Transition(parameter);
    }
}