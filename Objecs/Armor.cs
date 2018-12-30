using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster3000
{
	public class Armor : Object
	{ 
		public int BlockingAbility { get; set; }

		public Armor(string Name, string Info, int Coast, int Strength, int MaxStrength, int BlockingAbility) : base(Name, Info, Coast, Strength, MaxStrength)
		{
			this.BlockingAbility = BlockingAbility;
		}

		public Armor() { }

		public int Block()
		{
			return BlockingAbility;
		}
	}
}
