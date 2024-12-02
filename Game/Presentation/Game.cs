public class Game
{
    static World world = new World();
    static Context context = new Context(world);
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback);

    static UIHandler uiHandler;



    static void Main()
    {
        Ui ui = new Ui();

        context.Done = false;

        ui.DisplayWelcome();
        context.CurrentQuestion = IntroQuestion.Question(context);
        context.InQuestion = true;
        Console.WriteLine(context.CurrentQuestion.QuestionPromt);

        while (context.Done == false)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line != null) registry.Dispatch(line);
            DisplayPendingMessages();
        }
        ui.DisplayFinalMessage();
    }

    private static void DisplayPendingMessages()
    {
        uiHandler = new UIHandler();
        foreach (var message in context.GetAllMessages())
        {
            uiHandler.DisplayMessage(message);
        }
    }
}