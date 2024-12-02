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

    public Npc(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }

    public void PromtDialogue(Context context)
    {
        Console.WriteLine(dialogue);
    }
}