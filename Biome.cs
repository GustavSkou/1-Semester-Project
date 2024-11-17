abstract class Biome : Node
{
    protected Dictionary<string, Space> spaces;

    protected string name;

    public string Name 
    {
        get {return name;}
    }
    
    protected bool complete;

    protected Space entrySpace, exitSpace;
    
    public Dictionary<string, Space> Spaces
    {
        get {return spaces;}
    }

    public Space EntrySpace
    {
        get {return entrySpace;}
    }

    public Space ExitSpace
    {
        get {return exitSpace;}
    }

    public bool Complete
    {
        get {return complete;}
        set {complete = value;}
    }

    public Biome(string name, Dictionary<string, Space> spaces)
    {
        this.name = name;
        complete = false;
        this.spaces = spaces;
    }
}
