/* Command interface */
public interface ICommand
{
    public void Execute(Context context, string command, string[] parameters);
    string GetDescription();
}