public class IntroQuestion
{

    public static Question Question()
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
            QuestionPrompt = "Before you begin, there are some commands that are nice to know:)\n1) To go to a room, write \"go\" and then the room\n2) To explore a room, write \"explore\" to explore the room\n3) To answer a question, write \"answer\" followed by your choice of answer\n4) When in need for help simply write \"help\"\n Do you understand\n - answer Yes\n - answer No",
            Choices = new Dictionary<string, AnswerChoice>()
            {
                { "yes", yes },
                { "no", no }
            }
        };

        return question;
    }

    private static void AnswerYes(Context context)
    {
        context.AddMessage("(CLEAR)");
        context.CurrentSpace.WelcomeMessage(context);
        context.CurrentQuestion = context.CurrentSpace.Quest;
        context.InQuestion = false;
        context.CurrentQuestion = null;
    }

    private static void AnswerNo(Context context)
    {
        context.AddMessage("(CLEAR)");
        context.AddMessage(context.CurrentQuestion.QuestionPrompt);
    }
}