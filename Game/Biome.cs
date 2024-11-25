public abstract class Biome : Node
{
    protected Dictionary<string, Space> spaces;
    protected bool complete;
    
    public Dictionary<string, Space> Spaces
    {
        get {return spaces;}
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
