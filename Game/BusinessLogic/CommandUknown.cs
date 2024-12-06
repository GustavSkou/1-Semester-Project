/* Fallback for when a command is not implemented */

class CommandUnknown : BaseCommand, ICommand
{
    public void Execute(Context context, string command, string[] parameters)
    {
        switch (command.First())
        {
            case 'a':
                context.AddMessage("did you mean answer?");
                break;

            case 'e':
                context.AddMessage("did you mean explore?");
                break;

            case 'g':
                context.AddMessage("did you mean go?");
                break;

            case 't':
                context.AddMessage("did you mean talk?");
                break;

            case 'h':
                context.AddMessage("did you mean help?");
                break;

            default:
                context.AddMessage("Woopsie, I don't understand + \"{command}\"");
                break;
        }
    }
}