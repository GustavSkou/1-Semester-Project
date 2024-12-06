public class CommandExplore : BaseCommand, ICommand
{
    public CommandExplore()
    {
        description = "Explore current space.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion)
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

            string[] pathNames = context.CurrentSpace.Edges.Keys.ToArray();
            foreach (string path in pathNames)
            {
                string status = context.CurrentBiome.SpacesDict[path].Complete ? "Completed" : "Not complete";
                options.Add($"go {path} [{status}]");
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
        else
        {
            context.AddMessage("(CLEAR)");
            context.AddMessage("Please answer the question before exploring.");

            context.AddMessage(context.CurrentQuestion.QuestionPrompt);
            foreach (var choice in context.CurrentQuestion.Choices)
            {
                context.AddMessage($" - {choice.Key} {choice.Value.Description}");
            }
        }
    }
}