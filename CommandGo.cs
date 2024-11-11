/* Command for transitioning between spaces */

class CommandGo : BaseCommand, ICommand
{
    public CommandGo()
    {
        description = "Follow a path";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        try 
        {
            string parameter = string.Join(" ", parameters);
            context.Transition(parameter);
        }
        catch(KeyNotFoundException)
        {
            Console.WriteLine("Please try again");
        }
    }
}