public class CommandStatus : BaseCommand, ICommand
{
    public CommandStatus()
    {
        description = "Displays your current health, items, and karma.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        context.AddMessage("Player Status:");
        context.AddMessage($"- Health: {context.Health}");
        context.AddMessage($"- Karma: {context.Karma}");
        context.AddMessage($"- Items: {string.Join(", ", context.Items)}");
    }
}