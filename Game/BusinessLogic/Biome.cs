public class Biome : Node
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
        Space[] possibleNextSpaces = spacesDict.Values.ToArray();

        possibleNextSpaces = SortOutCompletedSpaces(currentSpace, possibleNextSpaces);

        possibleNextSpaces = SortOutCurrentEdges(currentSpace, possibleNextSpaces);

        if (possibleNextSpaces.Length > 0)
        {
            Space nextSpace = possibleNextSpaces[random.Next(0, possibleNextSpaces.Length)];
            currentSpace.AddEdge(nextSpace.Name, nextSpace);
            SetPreviousSpace(currentSpace, nextSpace);
        }
    }

    private Space[] SortOutCompletedSpaces(Space currentSpace, Space[] spaces)
    {
        return spaces.Where(
            space => space.Complete == false).Where(
            space => space != currentSpace).ToArray();
    }

    private Space[] SortOutCurrentEdges(Space currentSpace, Space[] spaces)
    {
        return spaces.Where(space => currentSpace.Edges.ContainsKey(space.Name.ToLower()) == false).ToArray();
    }

    private void SetPreviousSpace(Space currentSpace, Space nextSpace)
    {
        nextSpace.AddEdge(currentSpace.Name, currentSpace);
    }
}