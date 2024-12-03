public class UiHandler
{
    public void DisplayMessage(string message)
    {
        PrettyPrint.Print(message);
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }
}