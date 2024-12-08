/* Game class for starting application*/
public class Game
{
    static readonly World world = new World();
    static readonly Context context = new Context(world);
    static readonly ICommand fallback = new CommandUnknown();
    static readonly Registry registry = new Registry(context, fallback);
    static readonly UiHandler uiHandler = new UiHandler();

    static void Main()
    {
        uiHandler.DisplayMessage(UiMessages.Welcome);

        uiHandler.PendingMessagesHandler(context);

        while (uiHandler.Done == false)
        {
            string? line = uiHandler.GetUserInput();
            if (line != null) registry.Dispatch(line);
            uiHandler.PendingMessagesHandler(context);
        }
        uiHandler.DisplayMessage(UiMessages.Goodbye);
    }
}