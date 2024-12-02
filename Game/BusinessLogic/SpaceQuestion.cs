public class SpaceQuestion
{
    public static void CorrectAnswer(Context context)
    {
        Console.WriteLine("Correct answer");
        context.CurrentBiome.SpacesDict[context.CurrentSpace.Name].Complete = true;
        context.InQuestion = false;

        if (context.IsAllSpacesComplete())
        {
            if (!context.CurrentBiome.Complete)
            {
                context.World.BiomesSet[context.CurrentBiome.Name].Complete = true;
                if (context.IsAllBiomesComplete())
                {
                    context.QuitGame();
                    return;
                }
                else
                {
                    context.NextBiome = context.World.SetNextBiome(context.CurrentBiome, context.CurrentSpace);
                }
            }
        }
        context.CurrentSpace.DisplayExits(context);
    }

    public static void WrongAnswer(Context context)
    {
        context.AddMessage("Sorry wrong answer");
        TryAgain(context);
        context.AddMessage(context.CurrentQuestion.QuestionPromt);
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
            QuestionPromt = "Would you like to try again\n - Yes\n - No",
            Choices = new Dictionary<string, AnswerChoice>()
            {
                { yes.Description, yes },
                { no.Description, no }
            }
        };
        context.CurrentQuestion = question;
        context.InQuestion = true;
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