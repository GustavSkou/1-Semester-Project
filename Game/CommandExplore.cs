class CommandExplore : BaseCommand, ICommand
{
    public CommandExplore()
    {
        description = "Explore rooms within the current biome.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Console.WriteLine($"Exploring the space: {context.CurrentSpace.Name}");
        context.CurrentSpace.Explore();

        List<string> options = [];

        if (context.CurrentSpace.Quest != null)
        {
            Console.WriteLine("This room has a challenge or a task!");
            context.CurrentQuestion = context.CurrentSpace.Quest;
            options.Add("quest");
        }

        if (context.CurrentSpace.Npc != null)
        {
            Console.WriteLine($"You see {context.CurrentSpace.Npc.Name} here.");
        }

        if (options.Count > 0)
        {
            Console.WriteLine("What would you like to do?\n Use");
            foreach (string option in options)
            {
                Console.WriteLine($" - {option}");
            }
        }
    }
}