public class Game
{
    static World world = new World();
    static Context context = new Context(world);
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback);
    static UiHandler uiHandler = new UiHandler();

    static void Main()
    {
        context.Done = false;

        WelcomeAndExitMessage.DisplayWelcome();

        context.CurrentQuestion = IntroQuestion.Question(context);
        context.InQuestion = true;
        uiHandler.DisplayMessage(context.CurrentQuestion.QuestionPromt);

        while (context.Done == false)
        {
            string? line = uiHandler.GetUserInput();
            if (line != null) registry.Dispatch(line);
            DisplayPendingMessages();
        }
        WelcomeAndExitMessage.DisplayFinalMessage();
    }

    private static void DisplayPendingMessages()
    {
        foreach (var message in context.GetAllMessages())
        {
            uiHandler.DisplayMessage(message);
        }
    }
}