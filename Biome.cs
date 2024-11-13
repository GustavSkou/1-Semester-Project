abstract class Biome : Node
{
    protected Space[] spaces = [];
    
    protected bool complete;

    public Space[] Spaces
    {
        get {return spaces;}
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
