/* Command for transitioning between spaces */

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
        catch(KeyNotFoundException)
        {
            Console.WriteLine("Please try again");
        }
    }
}