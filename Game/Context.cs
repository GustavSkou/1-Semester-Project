/* Context class to hold all context relevant to a session. */
public class Context
{
    private Space currentSpace;
    private Biome currentBiome;
    private Biome? nextBiome;
    private World world;
    private Question? currentQuestion;
    private bool done, inQuestion;

    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public Question? CurrentQuestion
    {
        get { return currentQuestion; }
        set { currentQuestion = value; }
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
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
        nextBiome = null;
        currentQuestion = new Question();
    }

    public void AnswerQuestion(string choice)
    {
        if (currentQuestion != null) currentQuestion.Choices[choice].Action.Invoke(this);
    }

    public void Transition(string direction)
    {
        Console.Clear();
        currentSpace.DisplayGoodbye();

        Space nextSpace = currentSpace.FollowEdge(direction);
        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;

        currentSpace = nextSpace;
        currentQuestion = currentSpace.Quest;
        currentSpace.DisplayWelcome();
        DisplayContext();
    }

    public void DisplayContext()
    {
        if (currentSpace.Description != null) currentSpace.DisplayDescription();
        if (currentQuestion != null && !currentSpace.Complete)
        {
            currentSpace.DisplayQuestion(this);
        }
        if (!inQuestion)
        {
            currentSpace.DisplayExits();
        }
        return;
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

    public void QuitGame()
    {
        done = true;
        return;
    }
}