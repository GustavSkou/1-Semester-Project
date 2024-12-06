public class UiHandler
{
    private bool done;
    private readonly Dictionary<string, IUiCommand> UiCommands;

    public bool Done
    {
        get { return done; }
        set { done = value; }
    }

    public UiHandler()
    {
        done = false;
        UiCommands = new Dictionary<string, IUiCommand>
        {
            { "(CLEAR)", new UiCommandClear() },
            { "(DONE)", new UiCommandDone(this) }
        };
    }

    public void PendingMessagesHandler(Context context)
    {
        foreach (var message in context.GetAllMessages())
        {
            if (message != null)

                if (UiCommands.ContainsKey(message)) ExecuteCommand(message);
                else DisplayMessage(message);

        }
    }

    public void DisplayMessage(string message)
    {
        if (UiCommands.ContainsKey(message)) UiCommands[message].Execute();
        else PrettyPrint.Print(message);
    }

    public void ExecuteCommand(string message)
    {
        UiCommands[message].Execute();
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }
}