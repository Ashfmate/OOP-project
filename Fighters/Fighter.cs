public abstract class Fighter
{
    public bool IsAlive()
    {
        return Attr.hp > 0;
    }
    public int GetInitiative()
    {
        return Attr.speed + Roll( 2 );
    }
    public void Attack(ref Fighter other)
    {
        if (IsAlive() && other.IsAlive())
        {
            Console.WriteLine(
                "{0} attacks {1} with his {2}!",
                Name, other.Name, wep.Name);
                ApplyDamageTo(ref other, wep.CalculateDamage(attr,D));
        }
    }
    public virtual void Tick()
    {
        if (IsAlive())
        {
            int recovery = Roll();
            Console.WriteLine("{0} recovers {1} HP.", Name, recovery);
            Attr = new Attribute(Attr.hp + recovery, Attr.speed, Attr.power);
        }
    }
    public abstract void SpecialMove(ref Fighter other);
    public void GiveWeapon(Weapon wep)
    {
        this.wep = wep;
        wep = new NoWeapon();
    }
    public Weapon PilferWeapon()
    {
        var ret = this.wep;
        this.wep = new NoWeapon();
        return ret;
    }
    public bool HasWeapon()
    {
        return wep.Rank != -1;
    }
    protected Fighter(
        string name, int hp, int speed, int power,Dice D, Weapon wep)
        {
            this.name = name;
            this.attr = new Attribute(hp,speed,power);
            this.D = D;
            this.wep = wep;

            Console.WriteLine("{0} enters the ring!", this.name);
        }
    protected int Roll(int nRoll = 1)
    {
        return D.Roll(nRoll);
    }
    protected void ApplyDamageTo(ref Fighter target, int damage)
    {
        target.Attr = new Attribute(target.Attr.hp - damage, target.Attr.speed, target.Attr.power);
        Console.WriteLine("{0} takes {1} damage", target.Name, damage);
        if (!target.IsAlive())
        {
            Console.WriteLine("{0} has been killed by {1}", target.Name, name);
        }
    }
    protected string name;
    protected Attribute attr;

    public string Name
    {
        get
        { return this.name;}
    }
    public Attribute Attr
    {
        get
        { return this.attr;}
        set
        { 
            attr.hp = value.hp;
            attr.power = value.power;
            attr.speed = value.speed;
        }
    }

    private Dice D;
    private Weapon wep;

    public Weapon Wep
    {
        get
        {
            return wep;
        }
    }
}