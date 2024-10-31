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
        registry.Register("exit", cmdExit);
        registry.Register("quit", cmdExit);
        registry.Register("bye", cmdExit);
        registry.Register("go", new CommandGo());
        registry.Register("help", new CommandHelp(registry));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the World of Zuul!\n");

        InitRegistry();
        context.GetCurrent().Welcome();
        context.GetCurrent().Destription();
        world.SetNextSpaces(context.GetCurrent(), context.GetCompletedSpaces());
        context.GetCurrent().Exits();

        while (context.IsDone() == false)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line != null) registry.Dispatch(line);
        }
        Console.WriteLine("Thanks for playing :-)");
    }
}
