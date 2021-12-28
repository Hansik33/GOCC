using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOCC.View;
using GOCC.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_btn_click(object sender, EventArgs e)
        {
            if (Connector.LogIn(Email_entry.Text,Passworld_entry.Text))
            {
                Application.Current.MainPage = new RunningPage();
            }
            else
            {
                DisplayAlert("BLĄD",Connector.lastError.ToString(),"OK");
            }
        }

        private void Forgot_passworld_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassworldPage());
        }
    }
}