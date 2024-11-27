<<<<<<< Updated upstream:Forest.cs
class Forest : Biome
{
 public Forest (string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
    }
=======
public class Forest : Biome
{
 public Forest (string name, Dictionary<string, Space> spaces, InfoCard infoCard) 
        : base(name, spaces, infoCard)
    {
    }
>>>>>>> Stashed changes:Game/Forest.cs
}