using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace Store.Models
{
    public class UserData
    {
        public int userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Cart> PurchaseList { get; set; } = new List<Cart>(); //This is our purchase list with a Cart class that contains things we wish to display later.

        public static List<UserData> UserList = GetUsers();

        public static UserData GetUserData(string Email)
        {
            var selected = UserList.Where(x => x.Email == Email).FirstOrDefault();
            return selected;
        }
        public static UserData GetUserData(int id)
        {
            UserData userdata;
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + id + ".json");

            if (File.Exists(filepath))
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = File.ReadAllText(filepath);
                userdata = JsonConvert.DeserializeObject<UserData>(json, settings);
            }
            else
            {
                userdata = UserList.Where(x => x.userId == id).FirstOrDefault();
            }

            return userdata;
        }
        public static void SaveUserData(UserData user)
        {
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + user.userId + ".json");
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(user, settings);

            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, json);
            }
            else
            {
                File.Create(filepath);
            }
        }

        public static List<UserData> GetUsers()
        {
            List<UserData> UserList = new List<UserData>();
            UserList.Add(new UserData { userId = 1, Email = "user@name.se", Password = "pw", Name = "Pelle" });
            return UserList;
        }

        public class Cart
        {
            public int Id;
            public string Name;
            public int Price;
        }
    }
}