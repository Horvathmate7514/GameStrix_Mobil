using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.Models
{
    public class LocationRoot
    {
        public LocationData[] locationData { get; set; }
    }

    public class LocationData
    {
        public string name { get; set; }
        public Local_Names local_names { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
    }

    public class Local_Names
    {
        public string en { get; set; }
        public string uk { get; set; }
        public string la { get; set; }
        public string tr { get; set; }
        public string sr { get; set; }
        public string hu { get; set; }
        public string sk { get; set; }
        public string de { get; set; }
        public string ka { get; set; }
        public string ru { get; set; }
    }
}
