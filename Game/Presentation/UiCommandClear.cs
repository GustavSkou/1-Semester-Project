class UiCommandClear : IUiCommand
{
    public void Execute(string[] parameter)
    {
        Console.Clear();
    }
}