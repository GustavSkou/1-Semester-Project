public class UiCommandDone(UiHandler uiHandler) : IUiCommand
{
    public void Execute(string[] parameter)
    {
        uiHandler.Done = true;
    }
}