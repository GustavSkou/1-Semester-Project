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
        try 
        {
            String parameter = String.Join(" ", parameters);
            context.Transition(parameter);
        }
        catch
        {
            Console.WriteLine("try a different path");
        }
    }
}