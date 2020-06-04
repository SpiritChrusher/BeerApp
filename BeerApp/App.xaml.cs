using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerApp
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(string filepath)
        {
            InitializeComponent();
            FilePath = filepath;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
