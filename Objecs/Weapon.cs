using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster3000
{
	public class Weapon : Object
	{
		public int Damage { get; set; }
		public int AdditionalAccuracy { get; set; }

		public Weapon(string Name, string Info, int Coast, int Strength, int MaxStrength, int Damage, int AdditionalAccuracy) :
			base(Name, Info, Coast, Strength, MaxStrength)
		{
			this.Damage = Damage;
			this.AdditionalAccuracy = AdditionalAccuracy;
		}

		public Weapon() { }

		public int Attack()
		{
			return Damage;
		}
	}
}
