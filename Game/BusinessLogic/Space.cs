/* Space class for modeling spaces */

public class Space : Node
{
    private string biome;
    private Question? quest;
    private bool complete;
    private Npc? npc;

    public required string Description { get; set; }

    public bool Complete
    {
        get { return complete; }
        set { complete = value; }
    }

    public Npc? Npc
    {
        get { return npc; }
        set { npc = value; }
    }

    public Question? Quest
    {
        get { return quest; }
        set
        {
            quest = value;
            foreach (var choice in quest.Choices)
            {
                choice.Value.Action = choice.Value.Correct ? SpaceQuestion.CorrectAnswer : SpaceQuestion.WrongAnswer;
            }
        }
    }

    public string Biome
    {
        get { return biome; }
        set { biome = value; }
    }

    public void WelcomeMessage(Context context)
    {
        context.AddMessage($"You are now at {name} in {biome}");
    }

    public void ExitsMessage(Context context)
    {
        context.AddMessage("Current paths are:");

        foreach (var edge in edges)
        {
            string edgeComplete = ((Space)edge.Value).Complete ? "Completed" : "Not complete";
            context.AddMessage($" - go {edge.Key} [{edgeComplete}]");
        }
    }

    public void DescriptionMessage(Context context)
    {
        context.AddMessage(Description);
    }

    public void GoodbyeMessage(Context context)
    {
        context.AddMessage($"You left the {name}\n");
    }

    public override Space FollowEdge(string direction)
    {
        return (Space)base.FollowEdge(direction);
    }
}