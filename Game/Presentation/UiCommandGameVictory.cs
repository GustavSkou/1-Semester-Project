public class UiCommandGameVictory(UiHandler uiHandler) : IUiCommand
{
    public void Execute(string[] parameter)
    {
        uiHandler.DisplayMessage(UiMessages.Victory(parameter[0]));
        uiHandler.Done = true;
    }
}