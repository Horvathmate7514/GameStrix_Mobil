using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.Models
{

    public class UserRootObject
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string phone_number { get; set; }
        public int role { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
    }

}
