using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameMaster3000
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		Data data;
		public Window1(Data data)
		{
			InitializeComponent();

			//ObservableCollection<System.Type> Classes = 
			//	new ObservableCollection<System.Type> { typeof(Object), typeof(Weapon), typeof(Armor) }; 
			string[] Classes = new string[] { "Object", "Weapon", "Armor", "Money" };

			DataContext = Classes;

			this.data = data;
		}

		private void CreateBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Object o = new Object();
				if (!((Class.SelectedItem as string) == "Money") && Class.SelectedItem != null) 
				{
					if ((Class.SelectedItem as string) == "Object")
					{
						o = new Object(Name.Text, Info.Text, int.Parse(Coast.Text), int.Parse(Strength.Text),
							int.Parse(MaxStrength.Text));
					}
					else if ((Class.SelectedItem as string) == "Weapon")
					{
						o = new Weapon(Name.Text, Info.Text, int.Parse(Coast.Text), int.Parse(Strength.Text), 
							int.Parse(MaxStrength.Text),int.Parse(Damage_or_block.Text), int.Parse(Accuracy.Text));
					}
					else if ((Class.SelectedItem as string) == "Armor")
					{
						o = new Armor(Name.Text, Info.Text, int.Parse(Coast.Text), int.Parse(Strength.Text), 
							int.Parse(MaxStrength.Text), int.Parse(Damage_or_block.Text), int.Parse(Accuracy.Text));
					}
					if ((sender as Button).Name == "Buy")
					{
						data.Buy(o);
					}
					else if((sender as Button).Name == "CreateBtn")
					{
						data.Add(o);
					}
				}
				else if((Class.SelectedItem as string) == "Money")
				{
					data.Add(int.Parse(Coast.Text));
				}
			}
			catch { }
		}
	}
}
