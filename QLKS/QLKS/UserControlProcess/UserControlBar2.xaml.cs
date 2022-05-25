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

namespace QLKS.UserControlProcess
{
	/// <summary>
	/// Interaction logic for UserControlBar2.xaml
	/// </summary>
	public partial class UserControlBar2 : UserControl
	{
		public UserControlBar2()
		{
			InitializeComponent();
		}

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Button btn_close = sender as Button;
            Window mainwindows = Window.GetWindow(btn_close);
            mainwindows.Close();
        }

        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            Button btn_close = sender as Button;
            Window mainwindows = Window.GetWindow(btn_close);
            mainwindows.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            Window mainwindows = Window.GetWindow(grid);
            mainwindows.DragMove();
        }
    }
}
