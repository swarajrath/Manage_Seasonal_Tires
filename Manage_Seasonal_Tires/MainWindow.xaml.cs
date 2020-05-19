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

namespace Manage_Seasonal_Tires
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbx_Username.Text = "";
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var MasterWindow = new Master();
            MasterWindow.Owner = this;
            Visibility = Visibility.Hidden;
            MasterWindow.ShowDialog();
        }

        private void Window_Exit(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

       
    }
}
