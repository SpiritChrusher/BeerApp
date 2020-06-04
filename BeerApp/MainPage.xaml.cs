using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Linq;
using BeerApp.Backend;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using SQLite;

namespace BeerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private List<BeerPOJO> beerlist;

      
        private ObservableCollection<BeerPOJO> Expandinglist {get; set;}

        public MainPage()
        {
            InitializeComponent();
            beerlist = GetJson();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<BeerSQL>();
                var beers = conn.Table<BeerSQL>().ToList();
                if(beers.Count > 0)
                {
                    foreach (var item in beerlist)
                    {
                        foreach (var item2 in beers)
                        {
                            if(item.name == item2.Name)
                            {
                                item.IsChecked = true;
                            }
                        }
                    }
                }

                
            }
           
        }

        public MainPage(List<BeerPOJO> list)
        {
           beerlist = list;
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
                mainlabel.Text = "no internet, only local file is working!";
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
            async private void ToListbeers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listbeers(beerlist));
          
        }

        private void beername_Completed(object sender, EventArgs e)
        {
         
           if (beername.Text != null)
            {
                if (beername.Text.EndsWith(" "))
                {
                  string newname = beername.Text.Remove(beername.Text.Length-1);

                    Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(x => x.name).ToList());
                    MyListView.ItemsSource = Expandinglist;
                  
                }
                else
                {
                    Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(x => x.name).ToList());
                    MyListView.ItemsSource = Expandinglist;
                   
                }
            }
            else
            {
                mainlabel.Text = "No enough characters";
            }
            
        }

        private async void Favorites_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Favorites(beerlist));
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (Expandinglist[e.ItemIndex].IsVisible == false)
            {
                Expandinglist[e.ItemIndex].IsVisible = true;
            }
            else
            {
                Expandinglist[e.ItemIndex].IsVisible = false;
            }
        }
    }
}

