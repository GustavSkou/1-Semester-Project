/* Command for transitioning between spaces */

class CommandAnswer : BaseCommand, ICommand
{
    public CommandAnswer()
    {
        description = "Answer a question";
    }

    public void Execute(Context context, string command, string[] parameters)
    {        
        try 
        {
            context.AnswerQuestion(int.Parse(parameters[0])); // convert string number to interger
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Please try again");
        }
    }
}