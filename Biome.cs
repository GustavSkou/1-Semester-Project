abstract class Biome : Node
{
    protected Space[] spaces;
    
    protected bool complete;

    protected Space entrySpace, exitSpace;
    
    public Space[] Spaces
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

    public Biome(string name) : base(name) 
    {
        complete = false;
    }
}
