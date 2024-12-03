public class IntroQuestion
{
    public static Question Question(Context context)
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
            QuestionPromt = "Before you begin, there are some commands that are nice to know:)\n 1) To go to a room, write \"go\" and then the room\n 2) To answer a question, write \"answer\" followed by your choice of answer\n 3) When in need for help simply write \"help\"\n Do you understand\n - Yes\n - No",
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
        //Console.Clear();
        context.CurrentSpace.DisplayWelcome(context);
        context.CurrentQuestion = context.CurrentSpace.Quest;
        context.InQuestion = false;
        context.CurrentQuestion = null;
    }

    private static void AnswerNo(Context context)
    {
        context.AddMessage(context.CurrentQuestion.QuestionPromt);
    }
}