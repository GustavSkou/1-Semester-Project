/* Baseclass for commands */

class BaseCommand
{
    protected string description = "Undocument";

    protected bool GuardEq(string[] parameters, int bound)
    {
        return parameters.Length != bound;
    }

    public String GetDescription()
    {
        return description;
    }
}
