public class UiHandler
{
    private Dictionary<string, IUiCommand> UiCommands;

    public UiHandler()
    {
        UiCommands = new Dictionary<string, IUiCommand>
        {
            { "(CONSOLE_CLEAR)", new UiClear() }
        };
    }

    public void PendingMessagesHandler(Context context)
    {
        foreach (var message in context.GetAllMessages())
        {
            if (UiCommands.ContainsKey(message)) ExecuteCommand(message);
            else DisplayMessage(message);
        }
    }

    public void DisplayMessage(string message)
    {
        if (UiCommands.ContainsKey(message)) UiCommands[message].Execute();
        else PrettyPrint.Print(message);
    }

    public void ExecuteCommand(String message)
    {
        UiCommands[message].Execute();
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }
}