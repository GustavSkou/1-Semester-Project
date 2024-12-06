using System.ComponentModel.Design.Serialization;

public class Context
{
    private Space currentSpace;
    private Biome currentBiome;
    private Biome? nextBiome;
    private World world;
    private Question? currentQuestion;
    private Npc? currentNpc;
    private bool done, inQuestion;
    private int stars;
    private readonly Queue<string> messages = new Queue<string>();

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public Question? CurrentQuestion
    {
        get { return currentQuestion; }
        set { currentQuestion = value; }
    }

    public Npc? CurrentNpc
    {
        get { return currentNpc; }
        set { currentNpc = value; }
    }

    public bool Done
    {
        get { return done; }
        set { done = value; }
    }

    public bool InQuestion
    {
        get { return inQuestion; }
        set { inQuestion = value; }
    }

    public Biome CurrentBiome
    {
        get { return currentBiome; }
        set { currentBiome = value; }
    }

    public Biome? NextBiome
    {
        get { return nextBiome; }
        set { nextBiome = value; }
    }

    public World World
    {
        get { return world; }
        set { world = value; }
    }

    public Context(World world)
    {
        stars = 0;
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
        nextBiome = null;

        currentQuestion = IntroQuestion.Question();
        inQuestion = true;
        AddMessage(currentQuestion.QuestionPrompt);
    }

    public void Transition(string direction)
    {
        currentSpace.GoodbyeMessage(this);

        Space nextSpace = currentSpace.FollowEdge(direction);
        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;

        currentSpace = nextSpace;
        currentQuestion = currentSpace.Quest;
        currentSpace.WelcomeMessage(this);
    }

    public bool IsAllSpacesComplete()
    {
        foreach (Space space in currentBiome.SpacesDict.Values)
        {
            if (!space.Complete) return false;
        }
        return true;
    }

    public bool IsAllBiomesComplete()
    {
        foreach (Biome biome in world.BiomesSet.Values)
        {
            if (!biome.Complete) return false;
        }
        return true;
    }

    public void AddMessage(string message)
    {
        messages.Enqueue(message);
    }

    public string[] GetAllMessages()
    {
        string[] messages = this.messages.ToArray();
        this.messages.Clear();
        return messages;
    }

    public void EarnStar() {
        stars++;
        AddMessage($"Good Job! You earned a Star ({stars}/20)");
    }
}
