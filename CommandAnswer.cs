/* Command for transitioning between spaces */

class CommandAnswer : BaseCommand, ICommand
{
    public CommandAnswer()
    {
        description = "Use: answer (number)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {   
        if (context.InQuestion)
        {     
            try 
            {
                context.AnswerQuestion(int.Parse(parameters[0]) - 1); // convert string number to interger
                return;
            }
            catch(IndexOutOfRangeException)
            {
                context.CurrentSpace.Print("Please try again");
                context.CurrentSpace.Question();
            }
        }    
        else
        {
            context.CurrentSpace.Print("No question to answer"); 
        }   
    }
}