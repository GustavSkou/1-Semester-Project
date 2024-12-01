/* Main class for launching the game */
class Game
{
    static World world = new World();
    static Context context = new Context(world);
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback); 

    private static void InitRegistry()
    {
        ICommand cmdExit = new CommandExit();
        ICommand cmdGo = new CommandGo();
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", cmdGo);
        registry.Register("goto", cmdGo);
        registry.Register("answer", new CommandAnswer());
        registry.Register("help", new CommandHelp(registry));
    }

    static void Main(string[] args)
    {
        InitRegistry();
        context.Done = false;

        Console.WriteLine("Welcome to the World of EcoQuest!\n");
        context.CurrentQuestion = IntroQuestion.Question(context);
        context.InQuestion = true;
        Console.WriteLine(context.CurrentQuestion.QuestionPromt);

        while (context.Done == false)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line != null) registry.Dispatch(line);
        }
        Console.WriteLine("Congrats! You made it through the jungle of eco quests and have now reached with end.\nAlthough not all questions had one specific solution, your decision making helped solve issues regarding life on land.\nThank you for playing.");
    }
}