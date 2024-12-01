public abstract class Biome : Node
{
    protected Dictionary<string, Space> spacesDict;
    protected bool complete;

    public Dictionary<string, Space> SpacesDict
    {
        get { return spacesDict; }
    }

    public bool Complete
    {
        get { return complete; }
        set { complete = value; }
    }

    public Biome(string name, Dictionary<string, Space> spacesDict)
    {
        this.name = name;
        complete = false;
        this.spacesDict = spacesDict;
    }

    public void SetNextSpace(Space currentSpace)
    {
        Random random = new Random();
        Space[] nonCompletedSpaces = spacesDict.Values.Where(
            space => space.Complete == false).Where(
            space => space != currentSpace).ToArray();

        Space nextSpace = nonCompletedSpaces[
            random.Next(0, nonCompletedSpaces.Length)];

        currentSpace.AddEdge(nextSpace.Name, nextSpace);
        SetPreviousSpace(currentSpace, nextSpace);
    }

    private void SetPreviousSpace(Space currentSpace, Space nextSpace)
    {
        nextSpace.AddEdge(currentSpace.Name, currentSpace);
    }
}