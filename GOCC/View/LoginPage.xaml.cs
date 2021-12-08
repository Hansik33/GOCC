using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOCC.View;
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
            string email = Email_entry.Text;
            string passworld = Passworld_entry.Text;
            
            //Sprawdzenie prawdziwości podanych danych na serwerze

            Navigation.PushAsync(new RunningPage());
        }

        private void Forgot_passworld_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassworldPage());
        }
    }
}