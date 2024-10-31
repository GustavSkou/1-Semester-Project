/* Space class for modeling spaces (rooms, caves, ...) */

class Space : Node
{
    protected string[] paths;
    protected string spaceDestription, spaceQuestion;
    public Space(String name) : base(name)
    {
    }

    public void Welcome()
    {
        Print($"You are now at {name}");
    }

    public void Exits()
    {
        HashSet<string> exits = edges.Keys.ToHashSet();
        Print("Current exits are:");

        foreach (string exit in exits)
        {
            Print($" - {exit}");
        }
    }

    public void Destription()
    {
        Print(spaceDestription);
    }
    
    public void question()
    {
        Print(spaceQuestion);
    }

    public void Goodbye()
    {
    }

    public override Space FollowEdge(string direction)
    {
        return (Space) base.FollowEdge(direction);
    }

    public void SetNextSpaces(Dictionary<Space,bool> completedSpaces)
    {
        Random random = new Random();
        Space[] differentSpaces = GetDifferentNonCompletedSpaces(completedSpaces);
        string[] paths = this.paths;

        if (differentSpaces.Length < 1)
        {
            AddEdge("Ending", new End("The end"));
            return;
        }

        if (differentSpaces.Length < 2)
        {
            int pathIndex = random.Next(0, paths.Length);
            AddEdge(paths[pathIndex], differentSpaces[0]);
            return;
        }

        for (int edges = 0; edges < 2; edges++)
        {
            int pathIndex = random.Next(0, paths.Length);
            int spaceIndex = random.Next(0, differentSpaces.Length);

            AddEdge(paths[pathIndex], differentSpaces[spaceIndex]);

            paths = paths.Where(path => path != paths[pathIndex]).ToArray();
            differentSpaces = differentSpaces.Where(space => space != differentSpaces[spaceIndex]).ToArray();
        }
    }

    private Space[] GetDifferentNonCompletedSpaces(Dictionary<Space,bool> completedSpaces)
    {
        Space[] spaces = completedSpaces.Keys.ToArray();

        spaces = spaces.Where(space => space.GetType() != this.GetType() && !completedSpaces[space]).ToArray();
    
        return spaces;
    }

    protected void Print(string someString)
    {
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(25);
        }
        Console.WriteLine();
    }
}
