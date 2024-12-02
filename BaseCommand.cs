/* Baseclass for commands
 */
class BaseCommand
{
    protected string description = "Undocumented";

    // GuardEq ensures the correct number of parameters
    protected bool GuardEq(string[] parameters, int bound)
    {
        return parameters.Length != bound;
    }

    public string GetDescription()
    {
        return description;
    }
}
