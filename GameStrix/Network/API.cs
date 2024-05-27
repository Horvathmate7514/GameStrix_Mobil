
using GameStrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.Network
{
    public static class API
    {
        public static List<Product>? GetProducts()
        {
            List<Product>? products = HTTPCommunication<List<Product>>.Get($"https://bgs.jedlik.eu/gamestrix/gamestrix/api/products").Result;
            return products;
        }

        public static List<ProductCategory>? GetCategories()
        {
            List<ProductCategory>? categories = HTTPCommunication<List<ProductCategory>>.Get($"https://bgs.jedlik.eu/gamestrix/gamestrix/api/categories").Result;
            if (categories != null) categories.Insert(0, new ProductCategory() { CategoryID = 0, CategoryName = "Összes" });
            return categories;
        }

        public static UserRootObject? Register(string fullName, string email, string password, string address, string phone)
        {
            UserRootObject? user = null;
            user = HTTPCommunication<UserRootObject>.Post("https://bgs.jedlik.eu/gamestrix/gamestrix/api/register", new StringContent("{\r\n  \"name\": \""+fullName+"\",\r\n  \"email\": \""+email+"\",\r\n  \"password\": \""+password+"\",\r\n  \"adress\": \""+address+"\",\r\n  \"phone_number\": \""+phone+"\"\r\n}", null, "application/json")).Result;
            return user;
        }

        public static UserRootObject? Login(string email, string password)
        {
            UserRootObject? user = null;
            user = HTTPCommunication<UserRootObject>.Post("https://bgs.jedlik.eu/gamestrix/gamestrix/api/login", new StringContent("{\r\n  \"email\": \"elek@gmail.com\",\r\n  \"password\": \"qwertz1234\"\r\n}", null, "application/json")).Result;
            return user;
        }

        public static void Order(Product product)
        {

            string userToken = SecureStorage.Default.GetAsync("token").Result;

           Order order =  HTTPCommunication<Order>.Post("https://bgs.jedlik.eu/gamestrix/gamestrix/api/orders", new StringContent("{\r\n  \"ProductNumber\": \"201\",\r\n  \"QuantityOrdered\": \"2\",\r\n \"QuotedPrice\":\"2\"\r\n}", null, "application/json")).Result;
        }


        private static string token = "8a3c93c962f9f30903ae8b5e13698d9e";

        public static LocationData? GetLocationData(string? cityName)
        {
            string url = $"https://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid={token}";
            var location = HTTPCommunication<List<LocationData>>.Get(url).Result;
            if (location.Count > 0)
                return location[0];
            return null;
        }
    }
}
