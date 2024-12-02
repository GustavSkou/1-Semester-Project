public class CommandTalk : BaseCommand, ICommand
{
    public CommandTalk()
    {
        description = "Talk to an NPC in the current room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.CurrentSpace == null)
        {
            Console.WriteLine("There's no one to talk to here.");
            return;
        }

        if (context.CurrentSpace.Npc == null)
        {
            Console.WriteLine("There's no one to talk to in this room.");
        }
        else
        {
            Console.WriteLine($"You talk to {context.CurrentSpace.Npc.Name}.");
            Console.WriteLine(context.CurrentSpace.Npc.Dialogue);
        }
    }
}