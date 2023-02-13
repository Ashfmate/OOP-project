public class Warrior : Fighter
{
    public Warrior(string name, Dice D, Weapon wep)
    :
    base(name, 80, 4,10, D, wep)
    {}
    public override void SpecialMove(ref Fighter other)
    {
        if( IsAlive() && other.IsAlive() )
		{
			if( Roll() > 3 )
			{
				Console.WriteLine(
                    "{0} remembers his family and becomes super {1}", name, name);
                name = "Super " + name;
                attr = new Attribute(
                    attr.hp + 10, attr.speed + 3 ,(attr.power * 60) /40);
				
			}
			else
			{
				Console.WriteLine("{0} forgot his family", name);
			}
		}
    }

    ~Warrior() { Console.WriteLine("{0} has left the ring", name); }

}