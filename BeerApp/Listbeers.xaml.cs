using Newtonsoft.Json;
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
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listbeers : ContentPage
    {
        private ObservableCollection<BeerPOJO> _rootobj;

        public Listbeers(List<BeerPOJO> lista)
        {
            InitializeComponent();

            _rootobj = new ObservableCollection<BeerPOJO>(lista.OrderBy(x => x.name).ToList());
            MyListView.ItemsSource = _rootobj;
            
        }






    }
}
