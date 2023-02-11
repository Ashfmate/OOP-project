public abstract class Weapon
{
    public Weapon(string name, int rank)
    {
        this.Name = name;
        this.Rank = rank;
    }

    public abstract int CalculateDamage(Attribute attr, Dice d);
    ~Weapon() {}

    public string Name {get; private set;}
    public int Rank {get; private set;}
}