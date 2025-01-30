/* Node class for modeling graphs */

abstract public class Node
{
    protected string name;

    

    public string Name
    {
        get { return name; }
        set { name = value.ToLower(); }
    }

    public Dictionary<string, Node> Edges
    {
        get { return edges; }
    }

    public void RemoveEdges()
    {
        edges = new Dictionary<string, Node>();
    }

    protected Dictionary<string, Node> edges = [];

    public void AddEdge(string name, Node node)
    // Add edge that leads to some other Node object
    {
        name = name.ToLower();
        edges.Add(name, node);
    }

    public virtual Node FollowEdge(string direction)
    /* Return the corresponding Node object to the edge"direction" chosen by having this virtual we can override it to return a space object instead */
    {
        return edges[direction];
    }
}