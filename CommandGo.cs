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
            context.CurrentSpace.Print("Please try again");
            context.CurrentSpace.Exits();
        }
    }
}