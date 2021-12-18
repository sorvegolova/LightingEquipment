using LightingEquipment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LightingEquipment
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		//public static readonly DependencyProperty PropertyRoom = DependencyProperty.Register(
		//		nameof(RoomInfo),
		//		typeof(Room),
		//		typeof(MainWindow));

		//public Room RoomInfo
		//{
		//	get => (Room)GetValue(PropertyRoom);
		//	set => SetValue(PropertyRoom, value);
		//}




		public MainWindow()
		{
			InitializeComponent();
		}

		private void Roll_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void DragMove(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}

		private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//Room r = new Room {
			//	Height = "100",
			//	Width = "100",
			//	Length = "100"
			//};
			//RoomInfo = r;


			//MessageBoxS messageBoxS = new MessageBoxS("Результат", $"{RoomInfo.Height} {RoomInfo.Width} {RoomInfo.Length}");
			//messageBoxS.Show();
		}







		//private int GetHeightLighting()
		//{
		//	return heightRoom - heightOverhend - heightWorkSurf;
		//}

		//private int GetDistanceLighting(int heightLighting, int coefDistance)
		//{
		//	return heightLighting * coefDistance;
		//}
	}
}
