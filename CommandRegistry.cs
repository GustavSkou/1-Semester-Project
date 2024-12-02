class CommandRegistry
{
    private readonly Dictionary<string, ICommand> commands;

    public CommandRegistry()
    {
        commands = new Dictionary<string, ICommand>();
        RegisterCommand("talk", new TalkCommand());
        RegisterCommand("explore", new ExploreCommand());
        RegisterCommand("interact", new InteractCommand());
        RegisterCommand("status", new StatusCommand());
        RegisterCommand("help", new HelpCommand(this));
        RegisterCommand("go", new GoCommand());
    }

    public bool ExecuteCommand(Context context, string input)
    {
        string[] parts = input.Trim().Split(' ');
        string commandName = parts[0].ToLower();
        string[] parameters = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

        if (commands.ContainsKey(commandName))
        {
            commands[commandName].Execute(context, commandName, parameters);
            return true;
        }
        else
        {
            Console.WriteLine("Unknown command. Type 'help' to see a list of available commands.");
            return false;
        }
    }

    public void ListCommands()
    {
        Console.WriteLine("Available commands:");
        foreach (var command in commands)
        {
            Console.WriteLine($"- {command.Key}: {command.Value.GetDescription()}");
        }
    }

    private void RegisterCommand(string name, ICommand command)
    {
        commands[name] = command;
    }
}
