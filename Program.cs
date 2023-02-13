namespace Program
{
	public class Project
	{
		public static void Main(string[] args)
		{
			var fist = new Fist();
			var bat = new Bat();
			var knife = new Knife();
			var dice = new Dice();

			var Wep = new List<Weapon>
			{
				fist,
				bat,
				knife
			};

			var rng = new Random();

            Console.WriteLine("++++++++++++++++++Team 1++++++++++++++++++");

            List<Fighter> Team1 = new()
			{
				new Warrior("Ahmed", dice, Wep[rng.Next(Wep.Count)]),
				new Soldier("Brhoom", dice, Wep[rng.Next(Wep.Count)]),
				new Warrior("Mohammed", dice, Wep[rng.Next(Wep.Count)])
			};

			Console.WriteLine("++++++++++++++++++Team 2++++++++++++++++++");

			List<Fighter> Team2 = new()
			{
				new Warrior("Ouais", dice, Wep[rng.Next(Wep.Count)]),
				new Soldier("Taha", dice, Wep[rng.Next(Wep.Count)]),
				new Warrior("Noory", dice, Wep[rng.Next(Wep.Count)])
			};

			Console.WriteLine("-----------------------------------BEGIN-----------------------------------");

			while(AnyAliveFighter(ref Team1) && AnyAliveFighter(ref Team2))
			{
				Shuffle(ref Team1);
				PartitionAlive(ref Team1);
				Shuffle(ref Team2);
				PartitionAlive(ref Team2);

				for (int i = 0; i < Team1.Count; i++)
				{
					Engage(Team1[i], Team2[i]);
					DoSpecials(Team1[i], Team2[i]);
					Console.WriteLine("------------------------------------");
				}

				Console.WriteLine("=====================================");

				for (int i = 0; i < Team1.Count; i++)
				{
					Team1[i].Tick();
					Team2[i].Tick();
				}

				Console.WriteLine("=====================================");
				Console.WriteLine("Press any key to continue");
				Console.ReadKey();
				Console.WriteLine("\n");
			}

			if (AnyAliveFighter(ref Team1))
			{
				Console.WriteLine("Team 1 is victorious!!!");
			}
			else
			{
				Console.WriteLine("Team 2 is victorious!!!");
			}

			Console.ReadKey();
		}

		public static void TakeWeaponIfDead(ref Fighter taker, ref Fighter giver)
		{
			if (taker.IsAlive() && !giver.IsAlive() && giver.HasWeapon())
			{
				if (giver.Wep.Rank > taker.Wep.Rank)
				{
					Console.WriteLine(
						"{0} takes the {1} from {2}",
						taker.Name, giver.Wep.Name, giver.Name);
					taker.GiveWeapon(giver.PilferWeapon());
				}
			}
		}

		public static void Engage(Fighter F1, Fighter F2)
		{
			if( F1.GetInitiative() > F2.GetInitiative() )
			{
				F1.Attack( ref F2 );
				TakeWeaponIfDead( ref F1, ref F2 );
				F2.Attack( ref F1 );
				TakeWeaponIfDead( ref F2, ref F1 );
			}
			else
			{
				F2.Attack( ref F1 );
				TakeWeaponIfDead( ref F2, ref F1 );
				F1.Attack( ref F2 );
				TakeWeaponIfDead( ref F1, ref F2 );
			}
		}

		public static void DoSpecials(Fighter F1,Fighter F2 )
		{
			if( F1.GetInitiative() > F2.GetInitiative() )
			{
				F1.SpecialMove( ref F2 );
				TakeWeaponIfDead( ref F1, ref F2 );
				F2.SpecialMove( ref F1 );
				TakeWeaponIfDead( ref F2, ref F1 );
			}
			else
			{
				F2.SpecialMove( ref F1 );
				TakeWeaponIfDead( ref F2, ref F1 );
				F1.SpecialMove( ref F2 );
				TakeWeaponIfDead( ref F1, ref F2 );
			}
		}
	
		public static bool AnyAliveFighter(ref List<Fighter> fighters)
		{
			foreach (var f in fighters)
			{
				if (f.IsAlive())
				{
					return true;
				}
			}
			return false;
		}
	
		public static void PartitionAlive(ref List<Fighter> fighters)
		{
			var alive = new List<Fighter>();
			var dead = new List<Fighter>();

			foreach (var f in fighters)
			{
				if (f.IsAlive())
				{
					alive.Add(f);
				}
				else
				{
					dead.Add(f);
				}
			}

			var complete = new List<Fighter>();
			complete.AddRange(alive);
			complete.AddRange(dead);
			fighters = complete;
		}
	
		public static void Shuffle(ref List<Fighter> fighters)
		{
			var Rng = new Random();

			for (int i = fighters.Count; i > 0; i--)
			{
				var FirstFighter = Rng.Next(fighters.Count);
				var SecondFighter = Rng.Next(fighters.Count);

				var temp = fighters[FirstFighter];
				fighters[FirstFighter] = fighters[SecondFighter];
				fighters[SecondFighter] = temp;
			}
		}
	}
}
