/* Node class for modeling graphs */

class Node
{
    protected string name;
    protected Node parentNode;
    protected Dictionary<string, Node> edges = new Dictionary<string, Node>();

    public Node(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void AddEdge(string name, Node node)         // Add egde that leades to some other Node object
    {
        name = name.ToLower();
        edges.Add(name, node);
    }

    public virtual Node FollowEdge(string direction)    // Follow noe of this node object egdes to another node object
    {
        return edges[direction];
    }

    public virtual Node BacktrackEgde(string direction)
    {
        return parentNode;
    }

    protected virtual void SetParentNode(Node parentNode)
    {
        this.parentNode = parentNode;
    }
}