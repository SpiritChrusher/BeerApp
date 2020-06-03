using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        private ObservableCollection<BeerPOJO> Favoriteslist { get; set; }

        private List<BeerPOJO> allbeers;

       
        public Favorites(List<BeerPOJO> favoritelist)
        {
            allbeers = favoritelist;
            InitializeComponent();
            Favoriteslist = new ObservableCollection<BeerPOJO>(favoritelist.Where(x => x.IsVisible == true));
            MyListView.ItemsSource = Favoriteslist;
        }


    }
}