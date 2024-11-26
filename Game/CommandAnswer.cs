/* Command for transitioning between spaces */

class CommandAnswer : BaseCommand, ICommand
{
    public CommandAnswer()
    {
        description = "Use: answer (number)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {   
        
        if (!context.InQuestion) context.CurrentSpace.Print("No question to answer"); 
        else 
        {
            try {
                context.AnswerQuestion(parameters[0]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Try again");
            }
        }    
    }
}