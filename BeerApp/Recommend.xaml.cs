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
        public Recommend()
        {
            InitializeComponent();
        }

        private void beernames_Completed(object sender, EventArgs e)
        {
            List<BeerPOJO> completedlist = Search.RecommendBeers(beernames.Text);

            recommendedlabel.Text = "Here is the list: ";

            foreach (var item in completedlist)
            {
                recommendedlabel.Text += $"\n {item}";
            }

        }
    }
}