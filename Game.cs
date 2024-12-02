using System;

class Game
{
    private readonly Context context;
    private readonly CommandRegistry commandRegistry;
    private readonly StartScreen startScreen;

    public Game()
    {
        Player player = new Player();
        context = new Context(player);
        context.LoadBiomes("data.json");
        commandRegistry = new CommandRegistry();
        startScreen = new StartScreen();
    }

    public void Run()
    {
        startScreen.Show();

        Console.Clear();
        Console.WriteLine("Welcome to EcoQuest: Life on Land!");
        Console.WriteLine("Type 'help' to list commands.");
        Console.WriteLine();

        bool isRunning = true;
        while (isRunning)
        {
            if (context.CurrentBiome == null)
            {
                ShowAvailableBiomes();
            }

            Console.Write("> ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input)) continue;

            if (input == "quit")
            {
                isRunning = false;
                Console.WriteLine("Goodbye!");
                break;
            }

            if (!commandRegistry.ExecuteCommand(context, input))
            {
                Console.WriteLine("Invalid command. Type 'help' for a list of valid commands.");
            }
        }
    }

    private void ShowAvailableBiomes()
    {
        Console.WriteLine("Available Biomes:");
        foreach (Biome biome in context.Biomes)
        {
            Console.WriteLine($"- {biome.Name}");
        }
        Console.WriteLine("Type 'go [biome]' to explore a biome.");
    }
}
