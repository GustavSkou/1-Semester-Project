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
        /* Transition is used to handle the movement of the player from one space to another.
        Insuring that the context is up to date with what space and biome the player is currently in. 
        This is important to insure that the correct messages will be displayed to the user, and so that the inputs values from the user will correspond to the correct values */

        currentSpace.GoodbyeMessage(this);

        /* This is achieved by changing the "currentSpace" to "nextSpace" which is the one edge from the current space that corresponds to the "direction" given by the user.
        The biome is change by comparing "currentSpace" to "nextSpace" if it has changed currentBiome will be changed */
        Space nextSpace = currentSpace.FollowEdge(direction);
        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;
        currentSpace = nextSpace;

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

    public void EarnStar()
    {
        stars++;
        AddMessage($"Good Job! You earned a Star ({stars}/20)");
    }
}
