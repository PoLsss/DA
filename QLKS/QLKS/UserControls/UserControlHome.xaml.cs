﻿using System;
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

namespace QLKS
{
	/// <summary>
	/// Interaction logic for UserControlHome.xaml
	/// </summary>
	public partial class UserControlHome : UserControl
	{
        private string baseDir;
        private int index = 0;
        public UserControlHome()
		{
			InitializeComponent();

            baseDir = Environment.CurrentDirectory;
            ImageBrush ENABLED_BACKGROUND = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Anh/Home0.jpg")));
            this.Background = ENABLED_BACKGROUND;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();

        }
        #region method
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                index++;
                if (index > 3)
                    index = 0;
                ImageBrush ENABLED_BACKGROUND = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Anh/Home" + index.ToString() + ".jpg")));
                this.Background = ENABLED_BACKGROUND;
            }
            catch (Exception ex)
            {
                new DialogCustoms("Lỗi: T " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }

        }
        #endregion

        #region event
        private void right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index++;
                if (index > 3)
                    index = 0;
                ImageBrush ENABLED_BACKGROUND = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Anh/Home" + index.ToString() + ".jpg")));
                this.Background = ENABLED_BACKGROUND;
            }
            catch (Exception ex)
            {
                new DialogCustoms("Lỗi: R " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }

        }
        private void left_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index--;
                if (index < 0)
                    index = 3;
                ImageBrush ENABLED_BACKGROUND = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Anh/Home" + index.ToString() + ".jpg")));
                this.Background = ENABLED_BACKGROUND;
            }
            catch (Exception ex)
            {
                new DialogCustoms("Lỗi: L " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }

        }
        #endregion
    }
}
