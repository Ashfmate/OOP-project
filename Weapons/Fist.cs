class Fist : Weapon
{
    public Fist()
    :
    base("fist", 0){}

    public override int CalculateDamage(Attribute attr, Dice d)
    {
        return attr.power + d.Roll(2);
    }
}