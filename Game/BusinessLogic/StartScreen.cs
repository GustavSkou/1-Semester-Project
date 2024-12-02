/*using System;

class StartScreen
{
    private dynamic story;

    public StartScreen()
    {
        story = Utility.LoadJson("story.json"); // Load story from JSON
    }

    public void Show()
    {
        Console.Clear();
        Console.WriteLine(story.intro.title);
        Utility.PressEnterToContinue();

        foreach (var line in story.intro.text)
        {
            Console.WriteLine(line);
            Utility.PressEnterToContinue();
        }

        ShowMenu();
    }

    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Tutorial");
        Console.WriteLine("2. Start Game");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine()?.Trim();
        if (choice == "1")
        {
            ShowTutorial();
        }
        else if (choice == "2")
        {
            Console.WriteLine("Starting the game...");
            Utility.PressEnterToContinue();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Utility.PressEnterToContinue();
            ShowMenu(); // Retry if invalid input
        }
    }

    private void ShowTutorial()
    {
        Console.Clear();
        Console.WriteLine("Tutorial:");
        Console.WriteLine("Commands you can use in the game:");
        Console.WriteLine("1. 'go [biome]' - To move to a specific biome (e.g., 'go forest').");
        Console.WriteLine("2. 'answer [response]' - To answer a question (e.g., 'answer yes').");
        Console.WriteLine("3. 'defend' - To defend against the enemy.");
        Console.WriteLine("4. 'run' - To attempt running away from the enemy.");
        Console.WriteLine("5. 'pick up [item]' - To pick up items.");
        Utility.PressEnterToContinue();

        Console.WriteLine("In each room, you'll face challenges, gain items, or fight an enemy.");
        Console.WriteLine("Your goal is to explore all rooms and survive!");
        Utility.PressEnterToContinue();
    }
}*/
