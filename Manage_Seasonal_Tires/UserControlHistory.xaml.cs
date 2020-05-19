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
    /// Interaction logic for UserControlHistory.xaml
    /// </summary>
    public partial class UserControlHistory : UserControl
    {
        public UserControlHistory()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            Lbx_Customers.ItemsSource = App._custhistory;
        }


        private void Lbx_Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Customer cust = Lbx_Customers.SelectedItem as Customer;
           // int idcust = cust.CustId;

            var cars = (from c in App._history where c.CustId == cust.CustId select c).ToArray();

            Dgrid_Customer.ItemsSource = null;
            Dgrid_Customer.ItemsSource = cars;
        }

        private void Lbx_customersFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._customer where s.name.ToLower().Contains(filter) select s;
            Lbx_Customers.ItemsSource = lst;
        }
    }
}
