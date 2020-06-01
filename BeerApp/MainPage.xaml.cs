using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BeerApp;
using Newtonsoft.Json;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerApp.Backend;
using Xamarin.Essentials;
using System.Net.Http;

namespace BeerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private List<BeerPOJO> lista;
       
        public MainPage()
        {
            InitializeComponent();
            lista = GetJson();
        }

        public MainPage(List<BeerPOJO> list)
        {
           lista = list;
        }

        private List<BeerPOJO> GetJson()
        {
            List<BeerPOJO> jsonbeer;

            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                   String url = "https://raw.githubusercontent.com/SpiritChrusher/FavoriteBeer/master/src/main/Allbeers.json";
                   System.Net.WebClient client = new System.Net.WebClient();
                   String json = client.DownloadString(url);

                jsonbeer = ReadBeer(json);
            }
            else
            {
                beerinfos.Text = "no internet, only local file is working!";
                jsonbeer = LocalJsonData();
            }
            return jsonbeer;
        }

        private List<BeerPOJO> ReadBeer(string all)
        {
            List<BeerPOJO> Beerslist; 

            Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(all);

            return Beerslist;
        }

        List<BeerPOJO> LocalJsonData()
        {
            List<BeerPOJO> Beerslist = new List<BeerPOJO>();
            string jsonfilename = "Allbeers.json";

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonfilename}");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(jsonString);

            }
            return Beerslist;
        }
            async private void tosecond_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listbeers(lista));
          
        }

        private void beername_Completed(object sender, EventArgs e)
        {
         
           if (beername.Text.Length > 0)
            {
                if (beername.Text.EndsWith(" "))
                {
                  string newname = beername.Text.Remove(beername.Text.Length-1);
                    beerinfos.Text = Search.BeerSearch(lista, newname);
                }
                else
                {
                beerinfos.Text = Search.BeerSearch(lista, beername.Text);
                }
            }
            else
            {
                beerinfos.Text = "Not enough characters";
            }
        }

        private async void favorites_Clicked(object sender, EventArgs e)
        {
            List<BeerPOJO> favoritelist = new List<BeerPOJO>();

            foreach (var item in lista)
            {
                if (item.IsChecked == true)
                {
                    favoritelist.Add(item);
                }
            }
            await Navigation.PushAsync(new Favorites(favoritelist));


        }
    }
}

