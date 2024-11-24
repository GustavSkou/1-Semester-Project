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
            context.AnswerQuestion(parameters[0]);
        }    
    }
}