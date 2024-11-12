class Savannah : Space
{
    public Savannah(string name) : base(name)
    {
        
        Space vandhullet = new Vandhullet("vandhullet");
        Space busken = new Busken("busken");

        AddEdge("vandhullet", vandhullet);
        vandhullet.AddEdge(this.Name, this);

        AddEdge("busken", busken);
        busken.AddEdge(this.Name, this);

        spaceDestription = "test";//"Land of endless horizons packed with incredible wildlife, and home to the King of the jungle.\nUnfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers.\nIn addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
        spaceQuestion = null;
    }
}
class Vandhullet : Space
{
    public Vandhullet(string name) : base(name)
    {
        spaceDestription = "ikke noget her inde";
        spaceQuestion = "hvad er 1 + 1";
        spaceAnswerChoices =
        [
            ("2", true),
            ("1", false),
            ("4", false),
        ];
    }
}

class Busken : Space
{   
    public Busken(string name) : base(name)
    {
        spaceDestription = "ikke noget her inde";
        spaceQuestion = null;
    }
}