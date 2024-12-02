public class CommandQuest : BaseCommand, ICommand
{
    public CommandQuest()
    {
        description = "";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.CurrentQuestion == null) Console.WriteLine("No questions available");
        else
        {
            Console.WriteLine(context.CurrentQuestion.QuestionPromt);
            foreach (var choice in context.CurrentQuestion.Choices)
            {
                Console.WriteLine($" - {choice.Key} {choice.Value.Description}");
            }
        }
    }
}