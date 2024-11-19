class CommandTryAgain : BaseCommand, ICommand
{
    public CommandTryAgain()
    {
        description = "Command to try question again";
    }

    public void Execute(Context context, string command, string[] parameters)
    {   
        if (context.CurrentSpace.Complete)
        {
            context.CurrentSpace.Print($"{context.CurrentSpace.Name} is already completed\n");
            return;
        }

        if (context.InQuestion)
        {
            Console.Clear();
            context.CurrentSpace.Print("You are already in a question\n");
            context.CurrentSpace.Question(context);
            return;
        }

        context.CurrentSpace.Question(context);
    }
}