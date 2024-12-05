public class UiCommandDone(UiHandler uiHandler) : IUiCommand
{
    public void Execute()
    {
        uiHandler.Done = true;
    }
}