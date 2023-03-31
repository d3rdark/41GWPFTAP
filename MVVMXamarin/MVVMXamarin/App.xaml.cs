using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMXamarin.Views;

namespace MVVMXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListaAlumnosView();
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
