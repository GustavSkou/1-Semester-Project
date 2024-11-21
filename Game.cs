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
        //ICommand cmdTryAgain = new CommandTryAgain();
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", cmdGo);
        registry.Register("goto", cmdGo);
        /*registry.Register("try", cmdTryAgain);
        registry.Register("tryagain", cmdTryAgain);*/        
        registry.Register("answer", new CommandAnswer());
        registry.Register("help", new CommandHelp(registry));
    }

    static void Main(string[] args)
    {
        InitRegistry();
        context.Done = false;

        Console.WriteLine("Welcome to the World of Zuul!\n");
        context.CurrentSpace.Print("Before you begin, there are some commands that are nice to know:)\n 1) To go to a room, write \"go\" and then the room\n 2) To answer a question, write \"answer\" followed by your choice of answer\n 3) When in need for help simply write \"help\"\n Do you understand\n - Yes \n - No", false);

        context.CurrentSpace.DisplayWelcome();
        context.DisplayContext();
        while (context.Done == false)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line != null) registry.Dispatch(line);
        }
        Console.WriteLine("Thanks for playing :-)");
    }
}