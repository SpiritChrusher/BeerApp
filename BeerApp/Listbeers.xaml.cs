using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listbeers : ContentPage
    {
        private List<BeerPOJO> lists;

        public ObservableCollection<BeerPOJO> Items { get; set; } = new ObservableCollection<BeerPOJO>();

        private ObservableCollection<BeerPOJO> _rootobj;

        public Listbeers(List<BeerPOJO> lista)
        {
            this.lists = lista;
        }
        public Listbeers()
        {
            InitializeComponent();
            BindingContext = this;

            foreach (var item in lists)
            {          
            _rootobj = new ObservableCollection<BeerPOJO>(lists);
                MyListView.ItemsSource = _rootobj;
            }
        }






    }
}
