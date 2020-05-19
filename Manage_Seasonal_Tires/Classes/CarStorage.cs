using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Seasonal_Tires
{
    public class CarStorage
    {
        public int TicketId { get; set; }
        public int CustId { get; set; }
        public string CarModel { get; set; }
        public string VehicleNumber { get; set; }
        public string tireCategory { get; set; }
        public int numberofTires { get; set; }
        public DateTime storaeDate { get; set; }
        public string storage { get; set; }
        public int price { get; set; }
    }
}
