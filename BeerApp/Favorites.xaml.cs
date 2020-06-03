using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
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
            Favoriteslist = new ObservableCollection<BeerPOJO>(favoritelist.Where(x => x.IsChecked == true));
            MyListView.ItemsSource = Favoriteslist;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
          //  using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
        }
    }
}