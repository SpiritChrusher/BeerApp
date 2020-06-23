using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static System.Net.Mime.MediaTypeNames;

namespace BeerApp.Backend
{
    class Readfile
    {
        public static List<BeerPOJO> GetJson()
        {
            List<BeerPOJO> jsonbeer;

            Uri url = new Uri("https://raw.githubusercontent.com/SpiritChrusher/FavoriteBeer/master/src/main/Allbeers.json", UriKind.Absolute);

           // String url = "https://raw.githubusercontent.com/SpiritChrusher/FavoriteBeer/master/src/main/Allbeers.json";
                System.Net.WebClient client = new System.Net.WebClient();
           
              string json = client.DownloadString(url);


                jsonbeer = ReadBeer(json);
        
            return jsonbeer;
        }

        private static List<BeerPOJO> ReadBeer(string all)
        {
            List<BeerPOJO> Beerslist;

            Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(all);

            return Beerslist;
        }

       public static List<BeerPOJO> LocalJsonData(string allbeer)
        {
            List<BeerPOJO> Beerslist;


            Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(allbeer);

            return Beerslist;
        }

    }
}
