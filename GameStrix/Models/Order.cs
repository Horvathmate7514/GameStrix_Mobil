using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.Models
{


    public class Order
    {
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int CustomerID { get; set; }
        public int OrderNumber { get; set; }
        public int Total { get; set; }
    }


}
