using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameMaster3000
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Data data;

		public MainWindow()
		{
			InitializeComponent();
			data = new Data();

			DataContext = data;
		}

		private void AddObject_Click(object sender, RoutedEventArgs e)
		{
			Window1 win1 = new Window1(data);
			win1.Show();
		}

		private void DeletObject_Click(object sender, RoutedEventArgs e)
		{
			data.Delete(Invemtory.SelectedItem as Object);
		}

		private void SellObject_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				data.Sell(Invemtory.SelectedItem as Object, int.Parse(SellPrice.Text));
			}
			catch { }
		}

		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			data.Save();
		}

		private void Break_Click(object sender, RoutedEventArgs e)
		{
			data.Break(Invemtory.SelectedItem as Object);
		}

		private void Repair_Click(object sender, RoutedEventArgs e)
		{
			data.Repair(Invemtory.SelectedItem as Object);
		}

		private void Random_Click(object sender, RoutedEventArgs e)
		{
			Random r = new Random();
			InfoBox.Text = Convert.ToString(r.Next(1, 7));
		}

		private void Battle_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Equip_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
