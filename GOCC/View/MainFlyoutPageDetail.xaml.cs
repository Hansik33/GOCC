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
        public MainFlyoutPageDetail()
        {
            InitializeComponent();
        }

        private void register_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataFormPage());
        }
    }
}