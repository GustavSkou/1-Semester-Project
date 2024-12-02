class HelpCommand : BaseCommand, ICommand
{
    private readonly CommandRegistry registry;

    public HelpCommand(CommandRegistry registry)
    {
        this.registry = registry;
        description = "Lists all available commands.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Console.WriteLine("Available commands:");
        if (context.CurrentRoom != null)
        {
            // Room-specific commands
            Console.WriteLine("- explore: Explore the current room.");
            Console.WriteLine("- talk: Talk to an NPC in the room.");
            Console.WriteLine("- interact: Interact with objects or tasks in the room.");
            Console.WriteLine("- escape: Leave the room.");
        }
        else if (context.CurrentBiome != null)
        {
            // Biome-specific commands
            Console.WriteLine("- explore: Explore the current biome.");
        }
        else
        {
            // General commands
            Console.WriteLine("- go [biome]: Enter a biome (e.g., 'go forest').");
        }

        Console.WriteLine("- status: Check your current health, karma, and items.");
        Console.WriteLine("- help: Display this list of commands.");
        Console.WriteLine("- quit: Exit the game.");
    }
}
