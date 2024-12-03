public class UiHandler
{
    public void DisplayMessage(string message)
    {
        if (message == "(CONSOLE_CLEAR)") Console.Clear();

        else PrettyPrint.Print(message);
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }
}