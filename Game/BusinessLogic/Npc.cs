public class Npc
{
    private string name, dialogue;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Dialogue
    {
        get { return dialogue; }
        set { dialogue = value; }
    }

    public void PromtDialogue(Context context)
    {
        context.AddMessage(dialogue);
    }
}