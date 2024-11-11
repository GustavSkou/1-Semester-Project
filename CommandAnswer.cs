/* Command for transitioning between spaces */

class CommandAnswer : BaseCommand, ICommand
{
    public CommandAnswer()
    {
        description = "Answer a question";
    }
    
    //Answer 1

    public void Execute(Context context, string command, string[] parameters)
    {        
        try 
        {
            context.AnswerQuestion(int.Parse(parameters[0])); // convert string number to interger
        }
        catch(KeyNotFoundException)
        {
            Console.WriteLine("Please try again");
        }
        catch(NodeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}