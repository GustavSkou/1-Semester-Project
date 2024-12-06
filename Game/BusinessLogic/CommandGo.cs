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

                string[] pathNames = context.CurrentSpace.Edges.Keys.ToArray();

                if (pathNames.Length > 0)
                {
                    context.AddMessage("Current paths are:");
                    foreach (string path in pathNames)
                    {
                        string status = context.CurrentBiome.SpacesDict[path].Complete ? "Completed" : "Not complete";
                        context.AddMessage($" - {path} [{status}]");
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