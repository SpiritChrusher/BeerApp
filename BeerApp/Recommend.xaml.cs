using BeerApp.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recommend : ContentPage
    {
        private List<BeerPOJO> beerlist;

        public Recommend(List<BeerPOJO> beerlista)
        {
            InitializeComponent();
            beerlist = beerlista;
        }

        private void beernames_Completed(object sender, EventArgs e)
        {
            List<BeerPOJO> completedlist = Recommending.RecommendBeers(beernames.Text, beerlist);

            recommendedlabel.Text = "Here is the list: \n\n";

            foreach (var item in completedlist)
            {
                recommendedlabel.Text += $"\n {item.name}";
            }

        }
    }
}