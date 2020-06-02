using BeerApp.Backend;
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

        /*  private void checker_CheckedChanged(object sender, CheckedChangedEventArgs e)
          {
        CheckedChanged="checker_CheckedChanged"
              var checkbox = (CheckBox)sender;
              var obj = checkbox.BindingContext as BeerPOJO;
          }*/


        protected override bool OnBackButtonPressed()
        {
            new MainPage(list);
            base.OnBackButtonPressed();
            return false;
        }
    }
}
