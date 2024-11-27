/* Context class to hold all context relevant to a session. */

class Context
{
    private Space currentSpace;
    private Biome currentBiome, nextBiome;
    private World world;
    private Question currentQuestion;
    private bool done, inQuestion;

    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public Question CurrentQuestion
    {
        get {return currentQuestion;}
        set {currentQuestion = value;}
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

    public Biome NextBiome
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
    }

    public void AnswerQuestion(string choice)
    {
        currentQuestion.Choices[choice].Action.Invoke(this);
    }

    public void Transition(string direction)
    {
        Console.Clear();
        currentSpace.DisplayGoodbye();

        Space nextSpace = currentSpace.FollowEdge(direction);

        if (IsAllSpacesComplete())
        {
            if (!currentBiome.Complete)
            {
                world.BiomesSet[currentBiome.Name].Complete = true;
                if (IsAllBiomesComplete()) QuitGame();
                nextBiome = world.SetNextBiome(currentBiome, currentSpace);
            }
        }

        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;
        currentSpace = nextSpace;
        currentSpace.DisplayWelcome();
        DisplayContext();        
    }

    public void DisplayContext()
    {
        if (currentSpace.Description != null) currentSpace.DisplayDestription();
        if (currentSpace.Quest != null && !currentSpace.Complete)
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
        foreach (Space space in currentBiome.Spaces.Values)
        {
            if (space.Complete == false) return false;
        }
        return true;
    }

    public bool IsAllBiomesComplete()
    {
        foreach (Biome biome in world.BiomesSet.Values)
        {
            if (biome.Complete == false) return false;
        }
        return true;
    }

    public void QuitGame()
    {
        done = true;
        GameSave gameSave = new GameSave();
        gameSave.Save(this);
        return;
    }

    public void PickUpShard(Context context)
    {
        ICommand fallback = new CommandUnknown();
        Registry registry = new Registry(context, fallback);
        if (!CurrentBiome.IsInfoCardUnlocked())
        {
            CurrentBiome.ShardsCollected++;
            Console.WriteLine($"You have collected a shard ({CurrentBiome.ShardsCollected}/{CurrentBiome.Spaces.Count}).");

            if (CurrentBiome.IsInfoCardUnlocked())
            {
                Console.WriteLine($"You have collected all the shards for {CurrentBiome.InfoCard.InfoCardName}!");
                Console.WriteLine($"Would you like to assemble it? Type 'assemble {CurrentBiome.InfoCard.InfoCardName}'.");

                Console.Write(">");
                string? line = Console.ReadLine();
                if (line != null) registry.Dispatch(line);
            }
        }
        else
        {
            Console.WriteLine($"You already have all shards for {CurrentBiome.InfoCard.InfoCardName}.");
        }
    }

    public void AssembleInfoCard(string infoCardName)
    {
        if (CurrentBiome.IsInfoCardUnlocked() && CurrentBiome.InfoCard.InfoCardName == infoCardName)
        {
            Console.WriteLine($"You have successfully assembled the {infoCardName}!");
        }
        else
        {
            Console.WriteLine($"You cannot assemble {infoCardName}. Either you don't have all the shards or it's the wrong name.");
        }
    }

    public void ReadInfoCard(string infoCardName)
    {
        if (CurrentBiome.IsInfoCardUnlocked() && CurrentBiome.InfoCard.InfoCardName == infoCardName)
        {
            Console.WriteLine(CurrentBiome.InfoCard.InfoCardDescription);
        }
        else
        {
            Console.WriteLine($"You have not assembled the {infoCardName} yet or the name is incorrect.");
        }
    }
}