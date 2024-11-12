/* Command for transitioning between spaces */

class CommandGo : BaseCommand, ICommand
{
    public CommandGo()
    {
        description = "Use: go (path name)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion)
        {
            string parameter = string.Join(" ", parameters);
            try 
            {
                context.Transition(parameter);
                return;
            }
            catch(KeyNotFoundException)
            {
                context.CurrentSpace.Print($"You seach for the path {parameter}, but you could not find it");
                context.CurrentSpace.Exits();
            }
        }
        else
        {
            Console.WriteLine("You could not find any paths to follow");
        }
    }
}