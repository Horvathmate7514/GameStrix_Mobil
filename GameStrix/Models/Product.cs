using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.Models
{

    public class Product
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int RetailPrice { get; set; }
        public int QuantityOnHand { get; set; }
        public int CategoryID { get; set; }
        public string Image { get; set; }
        public string StockImgUrl { get { if (QuantityOnHand > 0) return "tick.png"; else return "cross.png"; } }


    }

}
