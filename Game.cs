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
        ICommand cmdTryAgain = new CommandTryAgain();
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", cmdGo);
        registry.Register("goto", cmdGo);
        registry.Register("try", cmdTryAgain);
        registry.Register("answer", new CommandAnswer());
        registry.Register("help", new CommandHelp(registry));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the World of Zuul!\n");

        InitRegistry();
        context.Done = false;

        context.CurrentSpace.Welcome();
        if (context.CurrentSpace.SpaceDestription != null) context.CurrentSpace.Destription();
        if (context.CurrentSpace.SpaceQuestion != null) 
        {
            context.CurrentSpace.Question(context);
            context.InQuestion = true;
        }
        else
        {
            context.CurrentSpace.Exits();
        }

        while (context.Done == false)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line != null) registry.Dispatch(line);
        }
        Console.WriteLine("Thanks for playing :-)");
    }
}