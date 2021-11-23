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

        private void CheckCorrectnessTextEntryRegex(object sender, TextChangedEventArgs e)
        {
            var isValid = Regex.IsMatch(e.NewTextValue,
                "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż]+$");

            if (e.NewTextValue.Length > 0) ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
        }

        private void CheckCorrectnessPostcodeRegex(object sender, TextChangedEventArgs e)
        {
            var isValid = Regex.IsMatch(e.NewTextValue,
                "^[0123456789-]+$");

            if (e.NewTextValue.Length > 0) ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
        }

        private void ChooseOnlineCheckBox(object sender, CheckedChangedEventArgs e)
        {
            if (RunningCheckBoxOnline.IsChecked)
            {
                RunningCheckBoxOffline.IsEnabled = false;
                RunningCheckBoxOffline.Color = Color.FromHex("#4D4D4D");

                if (Postcode.IsReadOnly)
                {
                    Postcode.IsReadOnly = false;
                    Postcode.PlaceholderColor = Color.White;
                }

                if (Address.IsReadOnly)
                {
                    Address.IsReadOnly = false;
                    Address.PlaceholderColor = Color.White;
                }

                if (HouseNumber.IsReadOnly)
                {
                    HouseNumber.IsReadOnly = false;
                    HouseNumber.PlaceholderColor = Color.White;
                }

                if (ApartmentNumber.IsReadOnly)
                {
                    ApartmentNumber.IsReadOnly = false;
                    ApartmentNumber.PlaceholderColor = Color.White;
                }

            }

            else
            {
                RunningCheckBoxOffline.IsEnabled = true;
                RunningCheckBoxOffline.Color = Color.Default;

                if (!(Postcode.IsReadOnly))
                {
                    Postcode.Text = String.Empty;
                    Postcode.IsReadOnly = true;
                    Postcode.PlaceholderColor = Color.FromHex("#4D4D4D");
                }

                if (!(Address.IsReadOnly))
                {
                    Address.Text = String.Empty;
                    Address.IsReadOnly = true;
                    Address.PlaceholderColor = Color.FromHex("#4D4D4D");
                }

                if (!(HouseNumber.IsReadOnly))
                {
                    HouseNumber.Text = String.Empty;
                    HouseNumber.IsReadOnly = true;
                    HouseNumber.PlaceholderColor = Color.FromHex("#4D4D4D");
                }

                if (!(ApartmentNumber.IsReadOnly))
                {
                    ApartmentNumber.Text = String.Empty;
                    ApartmentNumber.IsReadOnly = true;
                    ApartmentNumber.PlaceholderColor = Color.FromHex("#4D4D4D");
                }
            }
        }

        private void ChooseOfflineCheckBox(object sender, CheckedChangedEventArgs e)
        {
            if (RunningCheckBoxOffline.IsChecked)
            {
                RunningCheckBoxOnline.IsEnabled = false;
                RunningCheckBoxOnline.Color = Color.FromHex("#4D4D4D");
            }
            else
            {
                RunningCheckBoxOnline.IsEnabled = true;
                RunningCheckBoxOnline.Color = Color.Default;
            }
        }

        private void MoveToRegulations(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegulationsPage());
        }

        private void ConfirmData(object sender, EventArgs e)
        {

        }

        /* private void ConfirmData(object sender, EventArgs e)
        {
            UserDataModel userdata = new UserDataModel(FirstName.Text, LastName.Text, PhoneNumber.Text, Email.Text, Place.Text, Date.Date.Day.ToString(), Date.Date.Year.ToString(), Date.Date.Month.ToString());
            //DisplayAlert("TITLE", $"{userdata.Name}, {userdata.LastName}, {userdata.PhoneNumber}, {userdata.Email}, {userdata.City}, {userdata.Day},{userdata.Month},{userdata.Year}", "OK");
            //TUTAJ BĘDZIE KOD WYSYŁAJĄCY DANE DO SERWERA
            Navigation.PopAsync();
        } */

    }
}