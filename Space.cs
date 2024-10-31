/* Space class for modeling spaces (rooms, caves, ...) */

class Space : Node
{
    
    protected string[] paths;
    protected string spaceDestription;
    protected string spaceQuestion;
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
            Console.WriteLine("All rooms complete");
            return;
        }

        if (differentSpaces.Length < 2)
        {
            int pathIndex = random.Next(0, paths.Length);
            this.AddEdge(paths[pathIndex], differentSpaces[0]);
            return;
        }

        for (int edges = 0; edges < 2; edges++)
        {
            int pathIndex = random.Next(0, paths.Length);
            int spaceIndex = random.Next(0, differentSpaces.Length);

            this.AddEdge(paths[pathIndex], differentSpaces[spaceIndex]);

            paths[pathIndex]            = pathIndex     < paths.Length-1            ? paths[pathIndex+1]            : paths[pathIndex-1];
            differentSpaces[spaceIndex] = spaceIndex    < differentSpaces.Length-1  ? differentSpaces[spaceIndex+1] : differentSpaces[spaceIndex-1];  
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
