public class CommandStatus : BaseCommand, ICommand
{
    public CommandStatus()
    {
        description = "Displays your current health, items, and karma.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Console.WriteLine("Player Status:");
        Console.WriteLine($"- Health: {context.Health}");
        Console.WriteLine($"- Karma: {context.Karma}");
        Console.WriteLine($"- Items: {string.Join(", ", context.Items)}");
    }
}