/* Command for Answering questions */

class CommandAnswer : BaseCommand, ICommand
{
    /* This is the implementation for answering questions. 
    This is done by inheriting from the "BaseCommand" class and the "ICommand" interface, this is done to insure that all commands works the same way. This will trough polytheism insure that all commands that are added to the "commands" dictionary in the registry class, will work in the same manner. Since the "commands" dictionary contains a string as a key, and the command value, is stored as an ICommand.
    Insuring that all commands stored in the dictionary contains the "Execute" and "GetDescription" methods. */

    public CommandAnswer()
    {
        description = "Use: answer (number)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        /* In the CommandAnswer class the Execute method is implement, so that when it is executed, it start by checking weather or not the context is currently in a question, and if the question is null. 
        This is done by getting the InQuestion property from the context object passed in as a parameter. This insures us that there question is not null, and the question has been presented to the player. */

        if (!context.InQuestion || context.CurrentQuestion == null)
        {
            context.AddMessage("No question to answer");
        }
        else if (context.CurrentSpace.Complete)
        {
            context.AddMessage("This space is completed");
        }
        else
        {
            /* The if statement being false would then imply that we are currently in a question. 
            Here a try catch is used to catch a KeyNotFoundException, if the given parameter does not correspond to a key in the question's "Choices" dictionary.
            This key not found exception is handled by telling the player the try again. If no exception is thrown the corresponding method encapsuled by Action is invoked. */

            try
            {
                context.CurrentQuestion.Choices[parameters[0]].Action.Invoke(context);
            }
            catch (KeyNotFoundException)
            {
                context.AddMessage("Try again");
            }
        }
    }
}