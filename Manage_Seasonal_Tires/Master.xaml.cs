using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manage_Seasonal_Tires
{
    /// <summary>
    /// Interaction logic for Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        string language;
        bool firstTime = true;

        public Master()
        {
            language = Properties.Settings.Default.language;
            //language = "de";
            CultureInfo.CurrentCulture = new CultureInfo(language);
            CultureInfo.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();
        }

        private void Storage_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            

            switch (index)
            {
                case 0:
                    GridStorage.Children.Clear();
                    GridStorage.Children.Add(new UserControlStorage());
                    break;
                case 1:
                    GridStorage.Children.Clear();
                    GridStorage.Children.Add(new UserControlHistory());
                    break;
                default:
                    break;
            }
        }


        private void Window_Loaded_Master(object sender, RoutedEventArgs e)
        {
            GridStorage.Children.Clear();
            GridStorage.Children.Add(new UserControlStorage());


            var lst = new List<string> { "en English", "de German", "hi Hindi", "ar Arabic" };
            CoBx_language.ItemsSource = lst;
            var itm = (from l in lst where l.Contains(language) select l).FirstOrDefault();
            CoBx_language.SelectedItem = itm;

            if (Properties.Resources.fdirection.Contains("ToLeft"))
                FlowDirection = FlowDirection.RightToLeft;
            else
                FlowDirection = FlowDirection.LeftToRight;
        }

        private void CoBx_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstTime)
            {
                firstTime = false;
                return;
            }

            language = CoBx_language.SelectedItem.ToString().Substring(0, 2);

            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();

            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }
    }
}
