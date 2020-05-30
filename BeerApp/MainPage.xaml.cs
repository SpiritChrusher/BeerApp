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
            lista = GetJsonData();
        }





         List<BeerPOJO> GetJsonData()
        {
            string jsonfilename = "Allbeers.json";

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

              List<BeerPOJO> Beerslist = new List<BeerPOJO>();

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonfilename}");
            using (var reader = new System.IO.StreamReader(stream))
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
    }
}

