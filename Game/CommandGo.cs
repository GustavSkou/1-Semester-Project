/* Command for transitioning between spaces */

public class CommandGo : BaseCommand, ICommand
{
    public CommandGo()
    {
        description = "Use: go (path name)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion)    //check if player is in a question
        {
            string parameter = string.Join(" ", parameters);
            
            try 
            {
                context.Transition(parameter);
            }
            catch(KeyNotFoundException)
            {
                context.CurrentSpace.Print($"You seach for the path {parameter}, but you could not find it");
                context.CurrentSpace.DisplayExits();
            }
        }
        else
        {
            Console.WriteLine("You could not find any paths to follow");
        }
    }
}