using System.Reflection.Metadata;

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

    public string? GetUserInput()
    {
        /* To get the users input this method is used in the game loop. 
        This both displays to the user though "Console.Write" that the game is ready to handle an input. And retrieves the input though 
        "Console.Readline */

        Console.Write("> ");
        return Console.ReadLine();
    }

    public void DisplayMessage(string message)
    {
        // The "DisplayMessage" method is use display some message to the user
        PrettyPrint.Print(message);
    }

    public void ExecuteCommand(string command, string[] parameters)
    {
        UiCommands[command].Execute(parameters);
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