/* Space class for modeling spaces */

public class Space : Node
{
    private string description, biome;
    private Question quest;
    private bool complete;
    private SpaceQuestion spaceQuestion = new SpaceQuestion();
    private Npc? npc;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

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

    public Question Quest
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

    public void DisplayWelcome(Context context)
    {
        context.AddMessage($"You are now at {name} in {biome}");
    }

    public void DisplayExits(Context context)
    {
        context.AddMessage("Current paths are:");

        foreach (var edge in edges)
        {
            string edgeComplete = ((Space)edge.Value).Complete ? "Completed" : "Not complete";
            context.AddMessage($" - go {edge.Key} [{edgeComplete}]");
        }
    }

    public void DisplayDescription(Context context)
    {
        context.AddMessage(description);
    }

    public void DisplayGoodbye(Context context)
    {
        context.AddMessage($"You left the {name}\n");
    }

    public string Biome
    {
        get { return biome; }
        set { biome = value; }
    }

    public override Space FollowEdge(string direction)
    {
        return (Space)base.FollowEdge(direction);
    }
}