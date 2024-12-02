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
            catch (KeyNotFoundException)
            {
                context.AddMessage($"You search for the path {parameter}, but you could not find it");
                List<string> exitNames = new List<string>(context.CurrentSpace.Edges.Keys);
                if (exitNames.Count > 0)
                {
                    context.AddMessage("Current paths are:");
                    foreach (var exit in exitNames)
                    {
                        string status = context.CurrentSpace.Complete ? "Completed" : "Not complete";
                        context.AddMessage($" - [{status}] {exit}");
                    }
                }
                else
                {
                    context.AddMessage("There are no available paths from this location.");
                }
            }
        }
        else
        {
            context.AddMessage("You could not find any paths to follow while in a question.");
        }
    }
}