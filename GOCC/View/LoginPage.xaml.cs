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

        private async void Login_btn_click(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Uwaga!", "Zamierzasz rozpocząć bieg. Udział w biegu jest możliwy tylko raz. Jesteś pewien?", "Zacznij bieg","Anuluj");
            if (result)
            {
            if (Connector.LogIn(Email_entry.Text,Passworld_entry.Text))
            {
                await DisplayAlert("Kilka dodatkowych informacji","Niestety aplikacja nie działa w tle, dlatego prosimy nie gasić telefonu ani nie minimalizować tej aplikacji w czasie biegu.","Zrozumiałem i zaczynam bieg!");
                Application.Current.MainPage = new RunningPage();
            }
            else
            {
                await DisplayAlert("Błąd",Connector.lastError.ToString(),"Ok");
            }
            }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        }

        private void Forgot_passworld_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassworldPage());
        }
    }
}