/* Node class for modeling graphs */

abstract public class Node
{
    protected string name;
    public string Name
    {
        get { return name; }
        set { name = value.ToLower(); }
    }

    protected Dictionary<string, Node> edges = [];

    public Dictionary<string, Node> Edges
    {
        get { return edges; }
    }

    public void RemoveEdges()
    {
        edges = new Dictionary<string, Node>();
    }

    public void AddEdge(string name, Node node)         // Add edge that lead to some other Node object
    {
        name = name.ToLower();
        edges.Add(name, node);
    }

    public virtual Node FollowEdge(string direction)    // Follow edge of this node object node object
    {
        return edges[direction];
    }
}