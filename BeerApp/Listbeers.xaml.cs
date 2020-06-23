using BeerApp.Backend;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listbeers : ContentPage
    {
        private ObservableCollection<BeerPOJO> _rootobj;

        private List<BeerPOJO> list;

        public Listbeers(List<BeerPOJO> lista)
        {
            InitializeComponent();
            list = lista;
            _rootobj = new ObservableCollection<BeerPOJO>(list.OrderBy(x => x.name).ToList());
            MyListView.ItemsSource = _rootobj;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.DropTable<BeerSQL>();
                conn.CreateTable<BeerSQL>();

                foreach (var item in list)
                {
                    if (item.IsChecked)
                    {
                        BeerSQL tosql = new BeerSQL(item.name);
                        conn.Insert(tosql);
                    }
                }
            }
        }
    }
}
