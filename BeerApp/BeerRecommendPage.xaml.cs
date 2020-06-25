using BeerApp;
using BeerApp.Backend;
using Mobeer.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobeer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeerRecommendPage : ContentPage
    {
        private ObservableCollection<BeerPOJO> obslist { get; set; }
        private List<BeerPOJO> list;
        public BeerRecommendPage(List<BeerPOJO> lista)
        {
            list = lista;
            InitializeComponent();
            //  Dictionary<string, bool> dict = list.ToDictionary(x => x.taste.ToString(), x => x.IsVisible);
            obslist = new ObservableCollection<BeerPOJO>(list.Select(x => new BeerPOJO { taste = x.taste, IsVisible = x.IsVisible }));
            MyListView.ItemsSource = obslist;

        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (list[e.ItemIndex].IsVisible == false)
            {
                list[e.ItemIndex].IsVisible = true;
            }
            else
            {
                list[e.ItemIndex].IsVisible = false;
            }
        }

        //legalább 2őt választania kelljen, különben ne lehessen keresni
        private void Recommend_Clicked(object sender, EventArgs e)
        {
            //igazából ehelyett a lista helyett kell egy sima list, amiben fel van sorolva az összes íz
            List<string> between = list.Where(x => x.IsVisible == true).Select(x => x.taste[0]).ToList();

            string[] recommendedbeers = Recommending.RecommendBeers(Recommendbeer.BeertoRecommend(between, list), list).
                OrderByDescending(y => y.Value).Select(x => x.name).ToArray();
        }
    }
}