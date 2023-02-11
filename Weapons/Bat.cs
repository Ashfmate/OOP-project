class Bat : Weapon
{
    public Bat()
    :
    base("bat", 1){}

    public override int CalculateDamage(Attribute attr, Dice d)
    {
        return attr.power * 2 + d.Roll();
    }
}