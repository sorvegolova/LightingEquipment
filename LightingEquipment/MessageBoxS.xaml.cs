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
using System.Windows.Shapes;

namespace LightingEquipment
{
	/// <summary>
	/// Логика взаимодействия для MessageBoxS.xaml
	/// </summary>
	public partial class MessageBoxS : Window
	{
		public MessageBoxS(string title, string text)
		{
			InitializeComponent();
			TitleS.Content = title;
			Text.Text = text;
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
			this.Close();
		}
	}
}
