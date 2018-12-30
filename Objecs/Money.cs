using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster3000
{
	public class money : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int t;

		public int Money { get { return this.t; }
			set
			{
				t = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
			}
		}

		public money(int v)
		{
			Money = v;
		}
	}
}
