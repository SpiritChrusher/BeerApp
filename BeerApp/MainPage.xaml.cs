using System.Collections.Generic;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Linq;
using BeerApp.Backend;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using SQLite;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BeerApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private List<BeerPOJO> beerlist;
        private ObservableCollection<BeerPOJO> Expandinglist { get; set; }


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
                        App.Current.Resources["MainBackGround"] = "#EF000500";
                        App.Current.Resources["FontColor"] = "#AFFFFFFF";
                        App.Current.Resources["NormalBackGround"] = Color.Transparent;
                        App.Current.Resources["Buttonbg"] = "#0FFFFFFF";
                        App.Current.Resources["Borderc"] = "#AFFFFFFF";
                        App.Current.Resources["ButtonText"] = "#AFFFFFFF";
                    }
                    else
                    {
                        App.Current.Resources["MainBackGround"] = Color.DarkSeaGreen;
                        App.Current.Resources["FontColor"] = Color.Black;
                        App.Current.Resources["NormalBackGround"] = Color.Transparent;
                        App.Current.Resources["Buttonbg"] = Color.Honeydew;
                        App.Current.Resources["Borderc"] = Color.Black;
                        App.Current.Resources["ButtonText"] = Color.Black;
                    }
                }
            }
        }
        public MainPage()
        {

            InitializeComponent();

            Construct();

            IsDark = Preferences.Get("darkmode", false);
            switcher.IsToggled = IsDark;
            if (IsDark)
            {
                App.Current.Resources["MainBackGround"] = "#EF000500";
                App.Current.Resources["FontColor"] = "#AFFFFFFF";
                App.Current.Resources["NormalBackGround"] = Color.Transparent;
                App.Current.Resources["Buttonbg"] = "#0FFFFFFF";
                App.Current.Resources["Borderc"] = "#AFFFFFFF";
                App.Current.Resources["ButtonText"] = "#AFFFFFFF";
                App.Current.Resources["Selectedbg"] = "#EF000500";
            }
            else
            {
                App.Current.Resources["MainBackGround"] = Color.DarkSeaGreen;
                App.Current.Resources["FontColor"] = Color.Black;
                App.Current.Resources["NormalBackGround"] = Color.Transparent;
                App.Current.Resources["Buttonbg"] = Color.Honeydew;
                App.Current.Resources["Borderc"] = Color.Black;
                App.Current.Resources["ButtonText"] = Color.Black;
                App.Current.Resources["Selectedbg"] = Color.DarkSeaGreen;
            }
        }
        private async Task Construct()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                beerlist = await Readfile.GetJson();
                WorkingSQL();
            }

            else
            {
                var jsonString = Application.Current.Properties["Everybeer"].ToString();
                beerlist = Readfile.LocalJsonData(jsonString);
                WorkingSQL();
            }

        }

        private void WorkingSQL()
        {
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

        private void beername_Completed(object sender, EventArgs e)
        {

            if (beername.Text != null)
            {
                if (beername.Text.EndsWith(" "))
                {
                    string newname = beername.Text.Remove(beername.Text.Length - 1);

                    switch (searchby.SelectedIndex)
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
                else
                {
                    switch (searchby.SelectedIndex)
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
                mainlabel.Text = "Not enough characters";
            }
        }

        private async void ToRecommend_Clicked(object sender, EventArgs e)
        { 
            BeerPOJO.ChangeVisible(beerlist);
            await Navigation.PushAsync(new Recommend(beerlist));
        }

        private async void Favorites_Clicked(object sender, EventArgs e)
        {
            BeerPOJO.ChangeVisible(beerlist);

            await Navigation.PushAsync(new Favorites(beerlist));
        }
        private async void ToListbeers_Clicked(object sender, EventArgs e)
        {
            BeerPOJO.ChangeVisible(beerlist);

            await Navigation.PushAsync(new Listbeers(beerlist));
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
            Preferences.Set("darkmode", IsDark);
        }


    }
}

