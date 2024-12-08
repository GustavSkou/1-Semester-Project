public class CommandTalk : BaseCommand, ICommand
{
    public CommandTalk()
    {
        description = "Talk to an NPC in the current space.";
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

                context.AddMessage("What would you like to do?");
                if (context.CurrentSpace.Quest != null) context.AddMessage("- quest");
                if (context.CurrentSpace.Npc != null) context.AddMessage("- talk");
                context.CurrentSpace.ExitsMessage(context);
            }
            else
            {
                context.AddMessage("There's no one to talk to.");
            }
        }
        else
        {
            context.AddMessage("(CLEAR)");
            context.AddMessage("Please answer the question\n");
            context.AddMessage(context.CurrentQuestion.QuestionPrompt);

            foreach (var choice in context.CurrentQuestion.Choices)
            {
                context.AddMessage($" - {choice.Key} {choice.Value.Description}");
            }
        }
    }
}