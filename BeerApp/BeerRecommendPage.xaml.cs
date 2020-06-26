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
        private ObservableCollection<TastePOJO> obslist { get; set; }
        private List<BeerPOJO> list;
        public BeerRecommendPage(List<BeerPOJO> lista)
        {
            list = lista;
            InitializeComponent();
            obslist = new ObservableCollection<TastePOJO>(BeerTypes.Alltaste.Select( x => new TastePOJO(x)));
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
            List<string> between = obslist.Where(x => x.Visible == true).Select(x => x.Taste).ToList();

            string[] recommendedbeers = Recommending.RecommendBeers(Recommendbeer.BeertoRecommend(between, list), list).
                OrderByDescending(y => y.Value).Select(x => x.name).ToArray();
        }
    }
}