using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster3000
{
	[Serializable]
	public class Object
	{
		public string Name { get; set; }
		public string Info { get; set; }
		public int Coast { get; set; }
		public int Strength { get; set; }
		public int MaxStrength { get; set; }
		public bool on;

		public Object(string name, string info, int coast, int Strength,int MaxStrength)
		{
			this.Name = name;
			this.Info = info;
			this.Coast = coast;
			this.Strength = Strength;
		}

		public Object() { }

		public override string ToString()
		{
			return Name;
		}

		public int Sell()
		{
			return Coast;
		}
	}
}
