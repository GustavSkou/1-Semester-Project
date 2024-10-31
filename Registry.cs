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
    }

    //add command to commands
    public void Register(string name, ICommand command)
    {
        commands.Add(name, command);
    }

    public void Dispatch(string line) //tager i mod input
    {
        line = line.ToLower();
        string[] elements = line.Split(" ");
        string command = elements[0];
        string[] parameters = GetParameters(elements);

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