using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GOCC.View;

namespace GOCC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RunningPage();

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
