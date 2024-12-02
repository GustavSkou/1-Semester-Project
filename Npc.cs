class Npc
{
    public string Name { get; private set; }
    public string Dialogue { get; private set; }

    public Npc(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }
}
