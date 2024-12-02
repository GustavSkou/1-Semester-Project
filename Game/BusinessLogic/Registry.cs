/* Command registry */

class Registry
{
    Context context;
    ICommand fallback;
    Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public Registry(Context context, ICommand fallback)
    {
        this.context = context;
        this.fallback = fallback;
        InitRegistry();
    }

    private void InitRegistry()
    {
        ICommand cmdExit = new CommandExit();
        ICommand cmdGo = new CommandGo();
        Register("exit", cmdExit);
        Register("quit", cmdExit);
        Register("bye", cmdExit);
        Register("go", cmdGo);
        Register("goto", cmdGo);
        Register("answer", new CommandAnswer());
        Register("help", new CommandHelp(this));
        Register("status", new CommandStatus());
        Register("talk", new CommandTalk());
        Register("explore", new CommandExplore());
        Register("quest", new CommandQuest());
    }

    //add command to commands
    public void Register(string name, ICommand command)
    {
        commands.Add(name, command);
    }

    public void Dispatch(string line)
    {
        /* Dispatch method take in a string as a parameter, this string is from the players input. Here it is impotent to parse the input to make it homogeneous, this should insure us that all input are handled the correct way */

        line = line.ToLower();
        string[] elements = line.Split(" ");
        elements = elements.Where(element => element != "").ToArray();
        string command = elements[0];
        string[] parameters = GetParameters(elements);

        /* This is achieved by,
         1. setting the string the lowercase
         2. we spilt the string  */

        if (commands.ContainsKey(command))
        {
            GetCommand(command).Execute(context, command, parameters);
        }
        else
        {
            fallback.Execute(context, command, parameters);
        }
    }

    public ICommand GetCommand(string commandName)
    {
        return commands[commandName];
    }

    public string[] GetCommandNames()
    {
        return commands.Keys.ToArray();
    }

    // helpers
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