/* Class of handling Ui*/

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
            { "(DONE)", new UiCommandDone(this) },
            { "(VICTORY)", new UiCommandGameVictory(this) },
        };
    }

    public void PendingMessagesHandler(Context context)
    {
        foreach (var message in context.GetAllMessages())
        {
            if (message == null) continue;

            string[] elements = message.Split(" ");

            if (UiCommands.ContainsKey(elements[0])) ExecuteCommand(elements[0], GetParameters(elements));
            else DisplayMessage(message);
        }
    }

    public void DisplayMessage(string message)
    {
        PrettyPrint.Print(message);
    }

    public void ExecuteCommand(string command, string[] parameters)
    {
        UiCommands[command].Execute(parameters);
    }

    public string? GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

    private string[] GetParameters(string[] input)
    {
        string[] output = new string[input.Length - 1];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = input[i + 1];
        }
        return output;
    }
}