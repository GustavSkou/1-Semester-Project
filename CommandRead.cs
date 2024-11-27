class CommandRead : BaseCommand, ICommand
{
    public CommandRead()
    {
        description = "Use: read (infoCardName)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1))
        {
            context.CurrentSpace.Print("Invalid command. Use: read (infoCardName)");
            return;
        }

        string infoCardName = parameters[0];
        if (context.CurrentBiome.IsInfoCardUnlocked() && context.CurrentBiome.InfoCard.InfoCardName.ToLower() == infoCardName.ToLower())
        {
            context.CurrentSpace.Print(context.CurrentBiome.InfoCard.InfoCardDescription);
        }
        else
        {
            context.CurrentSpace.Print($"You have not assembled the {infoCardName} yet or the name is incorrect.");
        }
    }
}
