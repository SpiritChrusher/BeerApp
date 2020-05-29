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
        public MainPage()
        {
            InitializeComponent();
        }

        List<Beers> GetJsonData()
        {
            string jsonfilename = "Allbeers.json";

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

              List<Beers> Beerslist = new List<Beers>();

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonfilename}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                  Beerslist = JsonConvert.DeserializeObject<List<Beers>>(jsonString);

            }

            return Beerslist;
           
        }


        private void search_Clicked(object sender, EventArgs e)
        {
            if (beername.Text.Length > 2)
            {
                beerinfos.Text = Search.BeerSearch(GetJsonData(), beername.Text);
            }
            else
            {
                beerinfos.Text = "Not enough characters";
            }
        }

        private void tosecond_Clicked(object sender, EventArgs e)
        {

        }
    }
}

