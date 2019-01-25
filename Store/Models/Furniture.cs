using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
// ReSharper disable All

namespace Store.Models
{
    public class Furniture //things shared by all of the furniture objects are here.
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public int BuyCount { get; set; }


        public static List<Furniture> CreateData()
        {
            List<Furniture> FurnitureList = new List<Furniture>();

            FurnitureList.Add(new Bed {Id = 1, BuyCount = 0, Img = "/Content/images/bed1.jpg", Name = "Babuska", Price = 3000, Size = "Dubbel", Info = "Babuska är en av de starkaste sängarna i balkan. Gjord med äkta Bulgariskt stål."});
            FurnitureList.Add(new Bed {Id = 2, BuyCount = 0, Img = "/Content/images/bed2.jpg", Name = "Baklava", Price = 2500, Size = "Dubbel", Info = "Baklava kommer från Rumäniens hemsökta skogar, det sägs att folk kan höra röster på natten."});
            FurnitureList.Add(new Bed {Id = 3, BuyCount = 0, Img = "/Content/images/bed3.jpg", Name = "Lepa Brena", Price = 3500, Size = "Dubbel", Info = "Denna säng är en replika utav den Serbiska prinsessans Brenas säng. Lepa betyder 'Den vackra' på Serbiska."});
            FurnitureList.Add(new Bed {Id = 4, BuyCount = 0, Img = "/Content/images/bedsingle1.jpg", Name = "Katyusha", Price = 1500, Size = "Singel", Info = "Nämnd efter den Ryska rakt lastbilen eftersom den är super enkel men väldigt effektiv."});
            FurnitureList.Add(new Bed {Id = 5, BuyCount = 0, Img = "/Content/images/bedsingle2.jpg", Name = "Sarma", Price = 1750, Size = "Singel", Info = "Om du är överviktig och ensam så är denna säng perfekt för dig eftersom den klarar av 200kg."});
            FurnitureList.Add(new Bed {Id = 6, BuyCount = 0, Img = "/Content/images/bedsingle3.jpg", Name = "Burek", Price = 2000, Size = "Singel", Info = "Burek kom till Bosnien via den Ottomanska Imperiet, den är lätt att flytta runt och mycket stadig."});

            FurnitureList.Add(new Sofa {Id = 7, BuyCount = 0, Img = "/Content/images/sofa1.jpg", Name = "Baba", Price = 2000, Seats = 3, Info ="En mjuk soffa som är perfekt för din rumpa."});
            FurnitureList.Add(new Sofa {Id = 8, BuyCount = 0, Img = "/Content/images/sofa2.jpg", Name = "Dedo", Price = 2200, Seats = 2, Info = "Den mysigaste soffan som du kan annvända för att prata med din dejt." });
            FurnitureList.Add(new Sofa {Id = 9, BuyCount = 0, Img = "/Content/images/sofa3.jpg", Name = "Bre", Price = 2300, Seats = 3, Info = "En lädersoffa som kan klara sig i vilket väder som helst." });
            FurnitureList.Add(new Sofa {Id = 10, BuyCount = 0, Img = "/Content/images/sofa4.jpg", Name = "Ajde", Price = 2500, Seats = 2, Info = "Ajde är en väldigt lyxig soffa med två säten som var skapade med kärlek." });
            FurnitureList.Add(new Sofa {Id = 11, BuyCount = 0, Img = "/Content/images/sofa5.jpg", Name = "Govno", Price = 2100, Seats = 2, Info = "Dina familje medlemmar kommer att älska Govno. Den luktar super gott." });
            FurnitureList.Add(new Sofa {Id = 12, BuyCount = 0, Img = "/Content/images/sofa6.jpg", Name = "Majmun", Price = 2800, Seats = 2, Info = "Vår dyraste soffa, den är perfekt för en advokats kontor eller en världsledarens bibliotek." });

            FurnitureList.Add(new Table {Id = 13, BuyCount = 0, Img = "/Content/images/table1.jpg", Name = "Kokosh", Price = 1000, Material = "Träd", Info = "Ett bord som är perfekt för att skära bröd på." });
            FurnitureList.Add(new Table {Id = 14, BuyCount = 0, Img = "/Content/images/table2.jpg", Name = "Krava", Price = 500, Material = "Träd", Info = "Om du vill känna dig som Kung Arthur då ska du köpa ett runt bort som det här." });
            FurnitureList.Add(new Table {Id = 15, BuyCount = 0, Img = "/Content/images/table3.jpg", Name = "Cuko", Price = 700, Material = "Träd", Info = "Ett ganska stort bord som kan tåla mycket stryk, äkta balkan bord." });
            FurnitureList.Add(new Table {Id = 16, BuyCount = 0, Img = "/Content/images/table4.jpg", Name = "Maca", Price = 1200, Material = "Metall", Info = "Maca är skapat från material från ett krashat amerikanskt flygplan." });
            FurnitureList.Add(new Table {Id = 17, BuyCount = 0, Img = "/Content/images/table5.jpg", Name = "Moskvich", Price = 2500, Material = "Metall", Info = "Det dyraste och lyxigaste bordet i balkan, den är också strömförande." });
            FurnitureList.Add(new Table {Id = 18, BuyCount = 0, Img = "/Content/images/table6.jpg", Name = "Rakija", Price = 2100, Material = "Glas", Info = "Ett bord som ser till att inget hemligt sker under den." });

            return FurnitureList;
        }

        public static string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/library.json"); //Filepath turns a big link into a simple string which we use in json bellow.

        public static bool SaveData(List<Furniture> furniturelist)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(furniturelist.ToArray(), settings);
            System.IO.File.WriteAllText(filepath, json);

            return true;
        }

        public static List<Furniture> GetData()
        {
            List<Furniture> data;
            if (System.IO.File.Exists(filepath))
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = System.IO.File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<List<Furniture>>(json, settings);
            }
            else
            {
                data = CreateData();
            }

            data = data.OrderByDescending(x => x.BuyCount).ToList(); //A simple algorithm that sorts the list based on the BuyCount variable.

            SaveData(data);
            return data;
        }


    public class Sofa : Furniture //Special attributes which are only accessible by Sofa, Bed or Table.
        {
            public int Seats { get; set; }
        }

        public class Bed : Furniture
        {
            public string Size { get; set; }
        }

        public class Table : Furniture
        {
            public string Material { get; set; }
        }
    }
}