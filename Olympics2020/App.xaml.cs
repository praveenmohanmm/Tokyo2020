using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Olympics2020
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new NavigationPage(new HomePage());
            page.BarBackgroundColor = Color.White;
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
