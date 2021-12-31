using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassworldPage : ContentPage
    {
        string email;
        public ForgotPassworldPage()
        {
            InitializeComponent();
        }

        private async void forgot_password_click(object sender, EventArgs e)
        {
            email = Email_entry.Text;
            if (Connector.Reset(email))
            {
                await DisplayAlert("Uwaga!","Wysłano kod z linkiem resetującym hasło","Ok");
            }
            else
            {
                await DisplayAlert("Uwaga!", Connector.lastError, "Ok");
            }
        }
    }
}