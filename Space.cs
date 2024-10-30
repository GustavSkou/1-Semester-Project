/* Space class for modeling spaces (rooms, caves, ...)
 */

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
        this.SetNextSpaces();
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

    public void SetNextSpaces()
    {
        Random random = new Random();
        Space[] differentSpaces = GetDifferentSpaces();
        string[] paths = this.paths;

        for (int edges = 0; edges < 2; edges++)
        {
            int pathIndex = random.Next(0, paths.Length);
            int spaceIndex = random.Next(0, differentSpaces.Length);

            this.AddEdge(paths[pathIndex], differentSpaces[spaceIndex]);

            paths[pathIndex] = pathIndex < paths.Length-1 ? paths[pathIndex+1] : paths[pathIndex-1];
            differentSpaces[spaceIndex] = spaceIndex < differentSpaces.Length-1 ? differentSpaces[spaceIndex+1] : differentSpaces[spaceIndex-1];  
        }
    }

    private Space[] GetDifferentSpaces()
    {
        Space[] spaces = 
        [
            new Savannah("Savannah"), 
            new City("City"), 
            new Beach("Beach"), 
            new Forest("Forest"), 
            new Farm("Farm")
        ];

        Space[] differentSpaces = new Space[spaces.Length-1];

        for (int i = 0, n = 0; i < spaces.Length; i++)
        {
            if(spaces[i].GetType() == this.GetType())
            {
                continue;
            }
            differentSpaces[n++] = spaces[i];
        }


        return differentSpaces;
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
