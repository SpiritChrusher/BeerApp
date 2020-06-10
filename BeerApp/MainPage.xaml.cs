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
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace BeerApp
{
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

                Application.Current.Properties["Everybeer"] = json;

                jsonbeer = ReadBeer(json);
            }
            else
            {
                mainlabel.Text = "No internet, working with local file!";
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
            List<BeerPOJO> Beerslist;

            var jsonString = Application.Current.Properties["Everybeer"].ToString();

            Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(jsonString);
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

                    switch (seachby.SelectedIndex)
                    {
                        case 0:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                            break;
                        case 1:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.type[x.type.Count - 1].ToLower() == beername.Text.ToLower()).OrderBy(y => y.name));
                            break;
                        case 2:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.origin.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                            break;
                        case 3:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.manufacturer.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                            break;
                        default:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                            break;
                            /*   case 0:
                                   //Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.name.Contains(beername.Text)).OrderBy(x => x.name));
                                   Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                                   break;
                               case 1:
                                   Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.type[x.type.Count - 1].ToLower() == beername.Text.ToLower()).OrderBy(y => y.name));
                                   break;
                               case 2:
                                   Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.origin.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                                   break;
                               case 3:
                                   Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.manufacturer.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                                   break;

                               default:
                                   Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                                   break;*/
                    }
                    if (Expandinglist.Count > 0)
                    {
                        MyListView.ItemsSource = Expandinglist;
                    }
                    else
                    {
                        MyListView.ItemsSource = null;
                        mainlabel.Text = "No beer found, try something else";
                    }
                        
                }
                else
                {
                    switch (seachby.SelectedIndex)
                    {
                        case 0:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                            break;
                        case 1:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.type[x.type.Count - 1].ToLower() == beername.Text.ToLower()).OrderBy(y => y.name));
                            break;
                        case 2:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.origin.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                           break;
                        case 3:
                            Expandinglist = new ObservableCollection<BeerPOJO>(beerlist.Where(x => x.manufacturer.ToLower() == beername.Text.ToLower()).OrderBy(x => x.name));
                            break;
                        default:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.BeerListSearch(beerlist, beername.Text).OrderBy(y => y.name));
                            break;
                    }
                    if (Expandinglist.Count > 0)
                    {
                        MyListView.ItemsSource = Expandinglist;
                    }
                    else
                    {
                        MyListView.ItemsSource = null;
                        mainlabel.Text = "No beer found, try something else";
                    }
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

        private void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                App.Current.Resources["MainBackGround"] = Color.Black;
                App.Current.Resources["FontColor"] = Color.White;
                App.Current.Resources["NormalBackGround"] = Color.White;

            }
            else
            {
                App.Current.Resources["MainBackGround"] = Color.White;
                App.Current.Resources["FontColor"] = Color.Black;
                App.Current.Resources["NormalBackGround"] = Color.Gray;
            }
        }
    }
}

