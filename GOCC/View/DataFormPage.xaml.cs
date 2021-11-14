using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GOCC.Model;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataFormPage : ContentPage
    {
        public DataFormPage()
        {
            InitializeComponent();
        }

        private void CheckCorrectnessRegex(object sender, TextChangedEventArgs e)
        {
            var isValid = Regex.IsMatch(e.NewTextValue, "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż]+$");

            if (e.NewTextValue.Length > 0)
            {
                ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
        }

        private void ConfirmData(object sender, EventArgs e)
        {
            UserDataModel userdata = new UserDataModel(FirstName.Text,LastName.Text,PhoneNumber.Text,Email.Text,Place.Text, Date.Date.Day.ToString(),Date.Date.Year.ToString(),Date.Date.Month.ToString());
            //DisplayAlert("TITLE",$"{userdata.Name}, {userdata.LastName}, {userdata.PhoneNumber}, {userdata.Email}, {userdata.City}, {userdata.Day},{userdata.Month},{userdata.Year}","OK");
            //TUTAJ BĘDZIE KOD WYSYŁAJĄCY DANE DO SERWERA
            Navigation.PopAsync();
        }

        private void MoveToRegulations(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegulationsPage());
        }
    }
}