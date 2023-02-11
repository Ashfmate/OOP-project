class Knife : Weapon
{
    public Knife()
    :
    base("knife", 2){}

    public override int CalculateDamage(Attribute attr, Dice d)
    {
        return attr.speed * 3 + d.Roll(3);
    }
}