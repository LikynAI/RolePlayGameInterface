using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster3000
{
	[Serializable]
	public class Object : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public string Info { get; set; }
		public int Price { get; set; }
		public int MaxStrength { get; set; }
		public bool on { get; set; }

	private int t;
		public event PropertyChangedEventHandler PropertyChanged;
		public int Strength
		{
			get { return this.t; }
			set
			{
				t = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Strength)));
			}
		}

		public Object(string name, string info, int coast, int Strength,int MaxStrength)
		{
			this.Name = name;
			this.Info = info;
			this.Price = coast;
			this.Strength = Strength;
			this.MaxStrength = MaxStrength;
			on = false;
		}

		public Object() { }

		public override string ToString()
		{
			return Name;
		}

		public int Sell()
		{
			return Price;
		}
	}
}
