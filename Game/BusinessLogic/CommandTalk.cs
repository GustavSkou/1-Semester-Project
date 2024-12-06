public class CommandTalk : BaseCommand, ICommand
{
    public CommandTalk()
    {
        description = "Talk to an NPC in the current room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (!context.InQuestion)
        {
            if (context.CurrentNpc != null)
            {
                context.AddMessage("(CLEAR)");
                context.AddMessage($"You talk to {context.CurrentNpc.Name}.");
                context.AddMessage(context.CurrentNpc.Dialogue);
                context.AddMessage("");
            }
            else
            {
                context.AddMessage("There's no one to talk to.");
            }
        }
        else
        {
            context.AddMessage("Please answer the question");
        }
    }
}