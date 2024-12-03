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
        uiHandler.PendingMessagesHandler(context);

        while (context.Done == false)
        {
            string? line = uiHandler.GetUserInput();
            if (line != null) registry.Dispatch(line);
            uiHandler.PendingMessagesHandler(context);
        }
        WelcomeAndExitMessage.DisplayFinalMessage();
    }
}