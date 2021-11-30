using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOCC.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPageDetail : ContentPage
    {
        DateTime data = DateTime.Now;
        
        public MainFlyoutPageDetail()
        {
            InitializeComponent();
            if (data.Year == 2022 && data.Day <= 29)
            {
                StartEventButton.IsVisible = true;
            }
            else
            {
                StartEventButton.IsVisible = false;
            }
        }

        private void register_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataFormPage());
        }

        private void start_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}