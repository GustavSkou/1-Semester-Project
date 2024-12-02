/* Fallback for when a command is not implemented */

class CommandUnknown : BaseCommand, ICommand
{
    public void Execute(Context context, string command, string[] parameters)
    {
        context.AddMessage("Woopsie, I don't understand + \"{command}\"");
    }
}