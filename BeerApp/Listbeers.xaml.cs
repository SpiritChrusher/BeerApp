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

        private List<BeerPOJO> list;

        public Listbeers(List<BeerPOJO> lista)
        {
            InitializeComponent();
            list = lista;
            _rootobj = new ObservableCollection<BeerPOJO>(lista.OrderBy(x => x.name).ToList());
            MyListView.ItemsSource = _rootobj;
            
        }

        private void checker_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            for (int x = 0; x < _rootobj.Count; x++)
            {
                _rootobj[x].IsChecked = e.Value;
            }
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            new MainPage(list);
            base.OnBackButtonPressed();
            return false;
        }
    }
}
