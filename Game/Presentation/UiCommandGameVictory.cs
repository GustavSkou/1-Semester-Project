public class UiCommandGameVictory(UiHandler uiHandler) : IUiCommand
{
    public void Execute()
    {
        uiHandler.DisplayMessage(UiMessages.Victory);
        uiHandler.Done = true;
    }
}