abstract class Biome : Node
{
    protected Dictionary<string, Space> spaces;
    protected bool complete;
<<<<<<< Updated upstream:Biome.cs

    private InfoCard infoCard;

    public InfoCard InfoCard {
        get {return infoCard;}
        set {infoCard = value;}
    }
    
=======
    private InfoCard infoCard;
    private int shardsCollected;

>>>>>>> Stashed changes:Game/Biome.cs
    public Dictionary<string, Space> Spaces
    {
        get { return spaces; }
    }

    public bool Complete
    {
        get { return complete; }
        set { complete = value; }
    }

<<<<<<< Updated upstream:Biome.cs
    public Biome(string name, Dictionary<string, Space> spaces, InfoCard infoCard)
    {
        this.name = name;
        complete = false;
        this.spaces = spaces;
        this.infoCard = infoCard;
=======
    public InfoCard InfoCard
    {
        get { return infoCard; }
        set { infoCard = value; }
    }

    public int ShardsCollected
    {
        get { return shardsCollected; }
        set { shardsCollected = value; }
    }
protected Dictionary<string, int> inventory;

public Dictionary<string, int> Inventory
{
    get { return inventory; }
}

public Biome(string name, Dictionary<string, Space> spaces, InfoCard infoCard)
{
    this.name = name;
    complete = false;
    this.spaces = spaces;
    this.infoCard = infoCard;
    inventory = new Dictionary<string, int>();
    shardsCollected = 0;
}

    public bool IsInfoCardUnlocked()
    {
        return shardsCollected >= spaces.Count;
>>>>>>> Stashed changes:Game/Biome.cs
    }

    public void SetNextSpace(Space currentSpace)
    {
        Random random = new Random();
        Space[] nonCompletedSpaces = spaces.Values.Where (
            space => space.Complete == false ).ToArray();

        Space nextSpace = nonCompletedSpaces [
            random.Next(0, nonCompletedSpaces.Length) ];

        currentSpace.AddEdge(nextSpace.Name, nextSpace);
    }
}
