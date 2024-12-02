class StatusCommand : BaseCommand, ICommand
{
    public StatusCommand()
    {
        description = "Displays your current health, items, and karma.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("Player Status:");
            Console.WriteLine($"- Health: {context.Player.Health}");
            Console.WriteLine($"- Karma: {context.Player.Karma}");
            Console.WriteLine($"- Items: {string.Join(", ", context.Player.Items)}");
        }
        else
        {
            Console.WriteLine("This command does not take parameters.");
        }
    }
}
