using Manage_Seasonal_Tires.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControlStorage.xaml
    /// </summary>
    public partial class UserControlStorage : UserControl
    {
       // public CarStorage CarStore { get; set; }

        public UserControlStorage()
        {
            InitializeComponent();
            
        }

      

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Lbx_Customer.ItemsSource = App._customer;

            CbX_tire_Category.ItemsSource = new List<string> { "Winter", "Summer", "Performance", "All Season", "Touring", "Light Truck" };
            //CarStore = App._cars;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void Button_AddCustomer(object sender, RoutedEventArgs e)
        {
            //int CustomerID = Math.Abs(Guid.NewGuid().GetHashCode());
            Customer cust = new Customer { first_name = "Edit...", last_name = "Edit...", CustId = Math.Abs(Guid.NewGuid().GetHashCode()), date_of_birth = new DateTime(1987, 05, 15), address = "Edit..." };
            App._customer.Add(cust);
            


            Lbx_Customer.SelectedItem = cust;
            Lbx_Customer.ScrollIntoView(cust);
        }

        
        private void Button_ReplaceTire(object sender, RoutedEventArgs e)
        {
            
            //HistoryRecord history = Lbx_Cars.SelectedItem as HistoryRecord;
            CarStorage chistory = Lbx_Cars.SelectedItem as CarStorage;

            if (Lbx_Cars.SelectedItem == null)
            {
                MessageBox.Show("Please select a Car first.");
            }
            else
            {
                CarStorage cstore = Lbx_Cars.SelectedItem as CarStorage;
                cstore.price = cstore.price + 15;
                
                Tbx_Price.Text = cstore.price.ToString();

                 HistoryRecord history = new HistoryRecord {TicketId = chistory.TicketId, CustId = chistory.CustId, CarModel = chistory.CarModel, tireCategory = chistory.tireCategory, VehicleNumber = chistory.VehicleNumber, numberofTires = 4, storageDate = DateTime.Today};
                App._history.Add(history);
                MessageBox.Show("Replacement Successful");
                
            }
        }


        
        private void Lbx_Customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lbx_Customer.SelectedItem == null)
            {
                return;
            }
            else
            {
                Customer cust = Lbx_Customer.SelectedItem as Customer;
                int idcust = cust.CustId;

                var cars = (from c in App._cars where c.CustId == cust.CustId select c).ToArray();

                Lbx_Cars.ItemsSource = null;
                Lbx_Cars.ItemsSource = cars; 
            }
            
            
        }

        private void Lbx_customerFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._customer where s.name.ToLower().Contains(filter) select s;
            Lbx_Customer.ItemsSource = lst;
        }

        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            if (Lbx_Customer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer first.");
            }
            else
            {
                Customer cust = Lbx_Customer.SelectedItem as Customer;
                int idcust = cust.CustId;

                CarStorage car = new CarStorage { CarModel = "Edit...", VehicleNumber = "Edit...", TicketId = Math.Abs(Guid.NewGuid().GetHashCode()), CustId = idcust, numberofTires = 4, storaeDate = DateTime.Today, storage = "Edit..." };
                

                App._cars.Add(car);

                var cars = (from c in App._cars where c.CustId == cust.CustId select c).ToArray();

                Lbx_Cars.ItemsSource = null;
                Lbx_Cars.ItemsSource = cars;

                Lbx_Cars.SelectedItem = car;
                Lbx_Cars.ScrollIntoView(car);
            }
        }


        private void Tbx_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_checkout_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_Cars.SelectedItem == null)
            {
                MessageBox.Show("Please select a Car first.");
            }
            else
            {
                CarStorage car = Lbx_Cars.SelectedItem as CarStorage;
                
                var toDelete = car as CarStorage;

                var res = MessageBox.Show($"Are you sure to Check-Out {toDelete.CarModel}?" + "\n" + $"Price to Pay: {toDelete.price}€", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.OK)
                {
                    App._cars.Remove(toDelete);


                    Customer cust = Lbx_Customer.SelectedItem as Customer;
                    int idcust = cust.CustId;
                    var cars = (from c in App._cars where c.CustId == cust.CustId select c).ToArray();
                    Lbx_Cars.ItemsSource = null;
                    Lbx_Cars.ItemsSource = cars;
                }


            }
        }

        private void Button_DeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (Lbx_Customer.SelectedItem == null)
            {
                MessageBox.Show("Please select a Customer first.");
            }
            else
            {
                Customer cust = Lbx_Customer.SelectedItem as Customer;

                var res = MessageBox.Show($"Are you sure to Delete {cust.name}?", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.OK)
                {
                    var toDelete = cust as Customer;

                    if (res == MessageBoxResult.OK)
                        App._customer.Remove(toDelete);
                }
                    


            }
        }
    }

    public class Customer
    {
        public int CustId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
        

        [System.Xml.Serialization.XmlIgnore]
        public string name { get { return $"{ first_name} { last_name}"; } }
    }
}
