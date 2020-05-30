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

        /*  public Listbeers(List<BeerPOJO> lista)
          {
              lists = lista;
          }
        */

        List<BeerPOJO> GetJsonData()
        {
            string jsonfilename = "Allbeers.json";

            var assembly = typeof(Listbeers).GetTypeInfo().Assembly;

            List<BeerPOJO> Beerslist = new List<BeerPOJO>();

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonfilename}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                Beerslist = JsonConvert.DeserializeObject<List<BeerPOJO>>(jsonString);

            }

            return Beerslist;

        }
        public Listbeers(List<BeerPOJO> lista)
        {
            InitializeComponent();

            _rootobj = new ObservableCollection<BeerPOJO>(lista);
                MyListView.ItemsSource = _rootobj;
            
        }






    }
}
