public class CommandExplore : BaseCommand, ICommand
{
    public CommandExplore()
    {
        description = "Explore current space.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        context.AddMessage("(CLEAR)");

        context.AddMessage($"Exploring the space: {context.CurrentSpace.Name}");
        context.CurrentSpace.DescriptionMessage(context);

        List<string> options = [];

        // this is 2 since we want an edge back and to next space
        if (context.CurrentSpace.Edges.Count < 2) context.CurrentBiome.SetNextSpace(context.CurrentSpace);

        if (context.CurrentSpace.Quest != null)
        {
            context.AddMessage("This room has a challenge or a task!");
            context.CurrentQuestion = context.CurrentSpace.Quest;
            options.Add("quest");
        }

        if (context.CurrentSpace.Npc != null)
        {
            context.AddMessage($"You see {context.CurrentSpace.Npc.Name} here.");
            context.CurrentNpc = context.CurrentSpace.Npc;
            options.Add("talk");
        }

        foreach (var edge in context.CurrentSpace.Edges)
        {
            string edgeComplete = ((Space)edge.Value).Complete ? "Completed" : "Not complete";
            options.Add($"go {edge.Key} [{edgeComplete}]");
        }

        if (options.Count > 0)
        {
            context.AddMessage("What would you like to do?\n Use");
            foreach (string option in options)
            {
                context.AddMessage($" - {option}");
            }
        }
    }
}