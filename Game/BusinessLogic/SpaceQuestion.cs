public class SpaceQuestion
{
    public static void CorrectAnswer(Context context)
    {
        context.AddMessage("Correct answer");

        if (!context.CurrentBiome.SpacesDict[context.CurrentSpace.Name].Complete == true)
        {
            context.EarnStar();
        }

        context.CurrentBiome.SpacesDict[context.CurrentSpace.Name].Complete = true;
        context.InQuestion = false;
        context.CurrentQuestion = null;

        if (context.IsAllSpacesComplete())
        {
            if (!context.CurrentBiome.Complete)
            {
                context.World.BiomesSet[context.CurrentBiome.Name].Complete = true;
                if (context.IsAllBiomesComplete())
                {
                    context.AddMessage($"(VICTORY) {context.Stars}");
                    return;
                }
                else
                {
                    context.NextBiome = context.World.SetNextBiome(context.CurrentBiome, context.CurrentSpace);
                }
            }
        }
        context.CurrentSpace.ExitsMessage(context);
    }

    public static void WrongAnswer(Context context)
    {
        context.AddMessage("Sorry wrong answer");
        TryAgain(context);
    }

    public static void TryAgain(Context context)
    {
        AnswerChoice yes = new AnswerChoice()
        {
            Description = "yes",
            Action = AnswerYes
        };
        AnswerChoice no = new AnswerChoice()
        {
            Description = "no",
            Action = AnswerNo
        };
        Question question = new Question()
        {
            QuestionPrompt = "Would you like to try again\n - Yes\n - No",
            Choices = new Dictionary<string, AnswerChoice>()
            {
                { yes.Description, yes },
                { no.Description, no }
            }
        };
        context.CurrentQuestion = question;
        context.InQuestion = true;
        context.AddMessage(context.CurrentQuestion.QuestionPrompt);
    }

    private static void AnswerYes(Context context)
    {
        context.CurrentQuestion = context.CurrentSpace.Quest;
        context.AddMessage("(CLEAR)");
        context.AddMessage(context.CurrentQuestion.QuestionPrompt);

        foreach (var choice in context.CurrentQuestion.Choices)
        {
            context.AddMessage($" - {choice.Key} {choice.Value.Description}");
        }
        context.InQuestion = true;

    }

    private static void AnswerNo(Context context)
    {
        context.CurrentQuestion = context.CurrentSpace.Quest;
        context.InQuestion = false;
        context.AddMessage("What would you like to do?");
        if (context.CurrentSpace.Quest != null) context.AddMessage("- quest");
        if (context.CurrentSpace.Npc != null) context.AddMessage("- talk");
        context.CurrentSpace.ExitsMessage(context);
    }
}