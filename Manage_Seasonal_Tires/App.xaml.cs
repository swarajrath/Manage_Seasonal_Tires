//using Manage_Seasonal_Tires.Classes;
using Manage_Seasonal_Tires.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Manage_Seasonal_Tires
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Customer> _customer;
        public static ObservableCollection<CarStorage> _cars;
        public static ObservableCollection<HistoryRecord> _history;

        public static ObservableCollection<Customer> _custhistory;
        //Random rnd = new Random(Guid.NewGuid().GetHashCode());

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //get data from storage
            _customer = XMLCustStorage.ReadXML<ObservableCollection<Customer>>("customerfile.xml");
            _cars = XMLCustStorage.ReadXML<ObservableCollection<CarStorage>>("carStorage.xml");
            _history = XMLCustStorage.ReadXML<ObservableCollection<HistoryRecord>>("historyRecord.xml");

            _custhistory = XMLCustStorage.ReadXML<ObservableCollection<Customer>>("custhistoryRecord.xml");

            if (_customer == null)
            {
                _customer = new ObservableCollection<Customer>();
            }
            if (_cars == null)
            {
                _cars = new ObservableCollection<CarStorage>();
            }
            if (_history == null)
            {
                _history = new ObservableCollection<HistoryRecord>();
            }
            if (_custhistory == null)
            {
                _custhistory = new ObservableCollection<Customer>();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            XMLCustStorage.WriteXml<ObservableCollection<Customer>>(_customer, "customerfile.xml");
            XMLCustStorage.WriteXml<ObservableCollection<CarStorage>>(_cars, "carStorage.xml");
            XMLCustStorage.WriteXml<ObservableCollection<HistoryRecord>>(_history, "historyRecord.xml");

            XMLCustStorage.WriteXml<ObservableCollection<Customer>>(_custhistory, "custhistoryRecord.xml");
        }
    }
}
