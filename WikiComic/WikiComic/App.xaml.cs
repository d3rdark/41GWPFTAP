using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WikiComic.Views;

namespace WikiComic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PersonajesView();
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
