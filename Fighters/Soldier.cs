public class Soldier : Fighter
{
    public Soldier (string name, Dice D, Weapon wep)
    :
    base(name, 70, 7,14, D, wep)
    {}
    public override void SpecialMove(ref Fighter other)
    {
        if( IsAlive() && other.IsAlive() )
		{
			if( Roll() > 4 )
			{
				Console.WriteLine("{0} attacks {1} with an AK-47", name, other.Name);
				ApplyDamageTo(ref other,Roll( 3 ) + 20 );
			}
			else
			{
				Console.WriteLine("{0}'s gun is not responding", name);
			}
		}
    }
    public override void Tick()
    {
        if (IsAlive())
        {
            Console.WriteLine("{0} is hurt by a stone", name);

            var damage = Roll( 3 ) + 20;
            attr = new Attribute(Attr.hp - damage, Attr.speed, Attr.power);
            Console.WriteLine("{0} takes {1} damage", name, damage);
            if (!IsAlive())
            {
                Console.WriteLine("{0} killed himself", name);
            }
    
            base.Tick();
        }
    }

    ~Soldier() { Console.WriteLine("{0} has left the ring", name); }
}