/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node
{
    protected bool isDone = false;
    protected string[] paths;
    protected string spaceDestription;
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

    public virtual void Destription()
    {
        Print(spaceDestription);
        this.SetNextSpace();
    }

    public void Goodbye()
    {
        this.isDone = true;
    }

    public virtual string[] GetPaths()
    {
        return paths;
    }

    public bool IsDone()
    {
        return isDone;
    }

    public override Space FollowEdge(string direction)
    {
        return (Space) base.FollowEdge(direction);
    }

    public void SetNextSpace()
    {
        Random random = new Random();

        Space savannah = new Savannah("Savannah");
        Space city = new City("City");
        Space beach = new Beach("Beach");
        Space forest = new Forest("Forest");
        Space farm = new Farm("Farm");

        Space[] spaces = [savannah, city, beach, forest, farm];

        string GetRandomPath()    
        {
            return this.GetPaths()[random.Next(0, this.GetPaths().Length)];
        }

        Space GetRandomSpace()    //Get random different space
        {
            Space[] differentSpaces = new Space[4];

            for (int i = 0, n = 0; i < spaces.Length; i++)
            {
                if(spaces[i].GetType() == this.GetType())
                {
                    continue;
                }
                differentSpaces[n++] = spaces[i];
            }
            return differentSpaces[random.Next(0,differentSpaces.Length)];
        }
        this.AddEdge(GetRandomPath(), GetRandomSpace());
    }

    protected void Print(string someString)
    {
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }
}
