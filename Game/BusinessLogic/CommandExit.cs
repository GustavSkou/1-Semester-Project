/* Command for exiting program */

class CommandExit : BaseCommand, ICommand
{
    public CommandExit()
    {
        description = "Quit game";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        context.Done = true;
    }
}