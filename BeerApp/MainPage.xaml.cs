using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Linq;
using BeerApp.Backend;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using SQLite;
using System.Globalization;
using System.Threading.Tasks;

namespace BeerApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private List<BeerPOJO> beerlist;
        private ObservableCollection<BeerPOJO> Expandinglist {get; set;}


        private bool isDark;
        public bool IsDark
        {
            get
            {
                return isDark;
            }
            set
            {
                if (isDark != value)
                {
                    isDark = value;

                    if (IsDark)
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
                    Preferences.Set("darkmode", IsDark);
                }
            }
        }
        public MainPage()
        {
            InitializeComponent();
            Construct();
          // await Task.Run(() => Construct()).Wait();
            IsDark = Preferences.Get("darkmode", true);
            switcher.IsToggled = IsDark;
          
        }


        private async Task Construct()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                beerlist = await Readfile.GetJson();
                Application.Current.Properties["Everybeer"] = beerlist;
            }
            else
            {
                var jsonString = Application.Current.Properties["Everybeer"].ToString();
                beerlist = await Readfile.LocalJsonData(jsonString);
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<BeerSQL>();
                var beers = conn.Table<BeerSQL>().ToList();
                if (beers.Count > 0)
                {
                    foreach (var item in beerlist)
                    {
                        foreach (var item2 in beers)
                        {
                            if (item.name == item2.Name)
                            {
                                item.IsChecked = true;
                            }
                        }
                    }
                }
            }
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
                        case 4:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.PriceSearch(beerlist, beername.Text));
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
                        case 4:
                            Expandinglist = new ObservableCollection<BeerPOJO>(Search.PriceSearch(beerlist, beername.Text));
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

        private async void ToRecommend_Clicked(object sender, EventArgs e)
        {
              await Navigation.PushAsync(new  Recommend(beerlist));
            
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
            IsDark = e.Value;
          }

        
    }
}

