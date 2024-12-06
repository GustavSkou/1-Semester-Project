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
                    context.AddMessage("(DONE)");
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
        context.InQuestion = true;
    }

    private static void AnswerNo(Context context)
    {
        context.CurrentQuestion = null;
        context.InQuestion = false;
        context.CurrentBiome.SetNextSpace(context.CurrentSpace);
    }
}