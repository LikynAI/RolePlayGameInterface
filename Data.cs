using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameMaster3000
{
	public class Data
	{
		public ObservableCollection<Object> Inventory { get; set; }
		private string path = @"GameMaster3000Inventory.txt";
		public money Money { get; set; }

		public Data()
		{
			try
			{
				Inventory = new ObservableCollection<Object>();

				if (File.Exists(@"GameMaster3000Money.txt"))
				{
					Money = new money(int.Parse(File.ReadAllText(@"GameMaster3000Money.txt")));
				}
				else { Money = new money(0); }
				List<Type> types = new List<Type>
				{
				typeof(Object),
				typeof(Armor),
				typeof(Weapon)
				};

				if (File.Exists(@"GameMaster3000Inventory.txt"))
				{
					XmlSerializer xmlFormat = new XmlSerializer(Inventory.GetType(), types.ToArray());
					Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
					Inventory = (xmlFormat.Deserialize(fStream) as ObservableCollection<Object>);
					fStream.Close();
				}
				else { Inventory = new ObservableCollection<Object>(); }
			}
			catch { }
		}

		public void Save()
		{
			try
			{
				List<Type> types = new List<Type>();
				foreach (Object obj in Inventory)
				{
					Type type = obj.GetType();
					if (!types.Contains(type))
					{
						types.Add(type);
					}
				}

				XmlSerializer xmlSerializer = new XmlSerializer(Inventory.GetType(), types.ToArray());
				Stream fStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
				xmlSerializer.Serialize(fStream, Inventory);
				fStream.Close();

				if (!(File.Exists(@"GameMaster3000Money.txt")))
				{
					File.Create(@"GameMaster3000Money.txt");
				}
				File.WriteAllText(@"GameMaster3000Money.txt", Convert.ToString(Money.Money));
			} catch { }
		}
	

		internal void Repair(Object @object)
		{
			if (@object.MaxStrength > @object.Strength)
			{
				@object.Strength++;
			}
		}

		internal void Break(Object @object)
		{
			if (@object.Strength - 1 > 0)
			{
				@object.Strength--;
			}
		}

		internal void Delete(Object @object)
		{
			Inventory.Remove(@object);
		}

		internal void Sell(Object @object, int v)
		{
			Delete(@object);
			Money.Money += v;
		}

		public void Add(Object o)
		{
			Inventory.Add(o);
		}

		public void Add(int o)
		{
			Money.Money += o;
		}

		public void Buy(Object o)
		{
			if (Money.Money - o.Coast > 0)
			{
				Money.Money -= o.Coast;
				Add(o);
			} 
		}
	}
}
