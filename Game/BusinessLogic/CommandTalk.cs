public class CommandTalk : BaseCommand, ICommand
{
    public CommandTalk()
    {
        description = "Talk to an NPC in the current room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.CurrentSpace.Npc == null)
        {
            context.AddMessage("There's no one to talk to in this room.");
        }
        else
        {
            context.AddMessage($"You talk to {context.CurrentSpace.Npc.Name}.");
            context.AddMessage(context.CurrentSpace.Npc.Dialogue);
        }
    }
}