public class WelcomeAndExitMessage
{
    private static UiHandler uiHandler = new UiHandler();
    public static void DisplayWelcome()
    {
        uiHandler.DisplayMessage("Welcome to the World of EcoQuest!\n");
    }

    public static void DisplayFinalMessage()
    {
        uiHandler.DisplayMessage("Thank you for playing.");
    }
}