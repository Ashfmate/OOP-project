class NoWeapon : Weapon
{
    public NoWeapon()
    :
    base("No Weapon", -1){}

    public override int CalculateDamage(Attribute attr, Dice d)
    {
        return 0;
    }
}