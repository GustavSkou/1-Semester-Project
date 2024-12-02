class TalkCommand : BaseCommand, ICommand
{
    public TalkCommand()
    {
        description = "Talk to an NPC in the current room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("This command does not take parameters.");
            return;
        }

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
