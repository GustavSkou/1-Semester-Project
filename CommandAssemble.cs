class CommandAssemble : BaseCommand, ICommand
{
    public CommandAssemble()
    {
        description = "Use: assemble (infoCardName)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1))
        {
            context.CurrentSpace.Print("Invalid command. Use: assemble (infoCardName)");
            return;
        }

        string infoCardName = parameters[0];
        if (context.CurrentBiome.IsInfoCardUnlocked() && context.CurrentBiome.InfoCard.InfoCardName.ToLower() == infoCardName.ToLower())
        {
            context.CurrentSpace.Print($"You have successfully assembled the {infoCardName}!");
        }
        else
        {
            context.CurrentSpace.Print($"You cannot assemble {infoCardName}. Either you don't have all the shards or the name is incorrect.");
        }
    }
}
