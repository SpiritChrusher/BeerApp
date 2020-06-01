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
    public partial class Favorites : ContentPage
    {
        private List<BeerPOJO> favoritelist;

        public Favorites()
        {
            InitializeComponent();
        }

        public Favorites(List<BeerPOJO> favoritelist)
        {
            this.favoritelist = favoritelist;
        }
    }
}