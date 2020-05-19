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

namespace Manage_Seasonal_Tires
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Replacement : Window
    {
        public Customer CustInfo { get; set; }

        public Replacement(Customer Cstmr)
        {
            InitializeComponent();
            CustInfo = Cstmr;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Owner.Visibility = Visibility.Visible;
        }

        private void Button_Add_Customer(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer { first_name = text_firstName.Text, last_name = text_lastName.Text, CustId = Math.Abs(Guid.NewGuid().GetHashCode()), date_of_birth = new DateTime(1987, 05, 15) };

            App._customer.Add(cust);
        }

        private void Window_Replacement_Loaded(object sender, RoutedEventArgs e)
        {
            text_firstName.Text = CustInfo.first_name;
            text_lastName.Text = CustInfo.last_name;
            text_address.Text = CustInfo.address;
            text_dob.DisplayDate = CustInfo.date_of_birth;
            // var cust = Lbx_Customer.SelectedItem;
        }
    }
}
