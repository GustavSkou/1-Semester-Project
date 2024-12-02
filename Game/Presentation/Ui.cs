public class Ui
{
    public void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the World of EcoQuest!\n");
    }

    public void DisplayFinalMessage()
    {
        Console.WriteLine("Congrats! You made it through the jungle of eco quests and have now reached the end.\nAlthough not all questions had one specific solution, your decision-making helped solve issues regarding life on land.\nThank you for playing.");
    }

    public void DisplayQuestion(string prompt)
    {
        Console.WriteLine(prompt);
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine()?.Trim();
    }

    
}