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
            if (context.CurrentQuestionType == Context.QuestionType.boolean)
            {
                try
                {
                    context.AnswerQuestion((Context.YesNo) Enum.Parse(typeof(Context.YesNo), parameters[0]));
                    return;
                }
                catch(Exception e)
                {
                    context.CurrentSpace.Print("Please try again");
                    context.CurrentSpace.TryAgain(context);
                }
            }

            if (context.CurrentQuestionType == Context.QuestionType.numerical)
            {
                try 
                {
                    context.AnswerQuestion(int.Parse(parameters[0]) - 1); // convert string number to interger
                }
                catch(IndexOutOfRangeException)
                {
                    context.CurrentSpace.Print("Please try again");
                    context.CurrentSpace.Question(context);
                }
                catch(FormatException)
                {
                    context.CurrentSpace.Print("Please try again");
                    context.CurrentSpace.Question(context);
                }
            }
        }    
        else
        {
            context.CurrentSpace.Print("No question to answer"); 
        }   
    }
}