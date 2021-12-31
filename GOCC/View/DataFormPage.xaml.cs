using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GOCC.Model;
using Xamarin.CommunityToolkit.Extensions;


namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataFormPage : ContentPage
    {
        readonly TextInfo TextInformation = new CultureInfo("pl-PL", false).TextInfo;

        // DATA
        public string FirstDisciplineValue;
        public string FirstDisciplineValueToDisplay;
        public string SecondDisciplineValue;
        public string SecondDisciplineValueToDisplay;
        public string FirstNameValue;
        public string LastNameValue;
        public string PlaceValue;
        public string PostcodeValue;
        public string AddressValue;
        public string HouseNumberValue;
        public string ApartmentNumberValue;
        public string PostcodeValueToDisplay;
        public string AddressValueToDisplay;
        public string HouseNumberValueToDisplay;
        public string ApartmentNumberValueToDisplay;
        public string PhoneNumberValue;
        public string EmailValue;
        public string PasswordValue;
        public string BirthDateValue;
        public string RunHourValue;
        public string RunHourValueToDisplay;

        public string ServerOption1;
        //*

        public DataFormPage()
        {
            InitializeComponent();
        }

        private void CheckCorrectnessTextEntryRegex(object sender, TextChangedEventArgs e)
        {
            var GivenObject = sender as Entry;

            var ObjectName = GivenObject.StyleId;

            if (GivenObject.Text != null)
            {
                if (ObjectName == "FirstName" || ObjectName == "LastName")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-zĄąĆćĘęŁłŃńOoÓóŚśŹźŻż]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Place")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-zĄąĆćĘęŁłŃńOoÓóŚśŹźŻż ]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Postcode" || ObjectName == "PhoneNumber")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[0123456789-]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Address")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-zĄąĆćĘęŁłŃńOoÓóŚśŹźŻż ]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "HouseNumber")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-z0123456789]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Email")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-z0123456789!@#$%&'*+/=?^_`{|}~.]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text =
                            isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Password")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[A-Za-z0123456789~`!@#$%^&*()_+={[}|:;'<,>.?/ ]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }
            }
        }

        private void ChooseDisciplineCheckBox(object sender, CheckedChangedEventArgs e)
        {
            var GivenObject = sender as CheckBox;

            var ObjectName = GivenObject.StyleId;

            if (ObjectName == "RunningCheckBoxOnline")
            {
                if (RunningCheckBoxOnline.IsChecked)
                {
                    if (RunningCheckBoxOffline.IsChecked) RunningCheckBoxOffline.IsChecked = false;

                    RunningCheckBoxOffline.Style = Resources["DefaultCheckBoxStyle"] as Style;

                    DataFormPageHiddenSection.IsVisible = true;

                    if (CyclingCheckBox.Style == Resources["EmptyCheckBoxStyle"])
                        CyclingCheckBox.Style = Resources["DefaultCheckBoxStyle"] as Style;

                    HoursRadioButtons.IsVisible = false;
                }

                else
                {
                    RunningCheckBoxOffline.Style = Resources["DefaultCheckBoxStyle"] as Style;

                    DataFormPageHiddenSection.IsVisible = false;
                    Postcode.Text = null;
                    Address.Text = null;
                    HouseNumber.Text = null;
                    ApartmentNumber.Text = null;
                }
            }

            else if (ObjectName == "RunningCheckBoxOffline")
            {
                if (RunningCheckBoxOffline.IsChecked)
                {
                    RunningCheckBoxOnline.Style = Resources["DefaultCheckBoxStyle"] as Style;
                    if (RunningCheckBoxOnline.IsChecked) RunningCheckBoxOnline.IsChecked = false;

                    DataFormPageHiddenSection.IsVisible = false;
                    Postcode.Text = null;
                    Address.Text = null;
                    HouseNumber.Text = null;
                    ApartmentNumber.Text = null;

                    HoursRadioButtons.IsVisible = true;
                }

                else
                {
                    HoursRadioButtons.IsVisible = false;
                    FirstOptionHourRadioButton.IsChecked = false;
                    SecondOptionHourRadioButton.IsChecked = false;
                    ThirdOptionHourRadioButton.IsChecked = false;
                }

                if (CyclingCheckBox.Style == Resources["EmptyCheckBoxStyle"])
                    CyclingCheckBox.Style = Resources["DefaultCheckBoxStyle"] as Style;
            }

            else if (ObjectName == "CyclingCheckBox")
            {
                if (RunningCheckBoxOnline.Style == Resources["EmptyCheckBoxStyle"]
                    || RunningCheckBoxOffline.Style == Resources["EmptyCheckBoxStyle"])
                {
                    RunningCheckBoxOnline.Style = Resources["DefaultCheckBoxStyle"] as Style;
                    RunningCheckBoxOffline.Style = Resources["DefaultCheckBoxStyle"] as Style;
                }
            }

            if (GivenObject.Style == Resources["EmptyCheckBoxStyle"])
                GivenObject.Style = Resources["DefaultCheckBoxStyle"] as Style;
        }

        private void ChooseHourRadioButton(object sender, CheckedChangedEventArgs e)
        {
            FirstOptionHourRadioButton.Style = Resources["DefaultRadioButtonStyle"] as Style;
            SecondOptionHourRadioButton.Style = Resources["DefaultRadioButtonStyle"] as Style;
            ThirdOptionHourRadioButton.Style = Resources["DefaultRadioButtonStyle"] as Style;
        }

        private void RestoreDefaultStyleEntry(object sender, FocusEventArgs e)
        {
            var GivenObject = sender as Entry;

            if (GivenObject.Style == Resources["EmptyEntryStyle"])
                GivenObject.Style = Resources["DefaultEntryStyle"] as Style;
        }

        private void RestoreDefaultStyleCheckBox(object sender, FocusEventArgs e)
        {
            var GivenObject = sender as CheckBox;

            if (GivenObject.Style == Resources["EmptyCheckBoxStyle"])
                GivenObject.Style = Resources["DefaultCheckBoxStyle"] as Style;
        }

        private void SelectDate(object sender, DateChangedEventArgs e)
        {
            if (DateDatePicker.Date != DateDatePicker.MaximumDate)
                BirthDateLabel.TextColor = Color.LightGray;
        }

        private void MoveToRegulations(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegulationPages());
        }

        public bool IsPostcodeCorrect()
        {
            bool isCorrect = true;

            if (Postcode.Text.Length == 6)
            {
                int[] Numbers = new int[5] { 0, 1, 3, 4, 5 };

                for (int i = 0; i < Numbers.Length; i++)
                    if (!(Char.IsDigit(Postcode.Text[Numbers[i]]))) isCorrect = false;
                if (Postcode.Text[2] != '-') isCorrect = false;
            }
            else isCorrect = false;

            return isCorrect;
        }

        public bool IsPhoneNumberCorrect()
        {
            bool isCorrect = true;

            if (PhoneNumber.Text.Length == 11)
            {
                int[] Numbers = new int[9] { 0, 1, 2, 4, 5, 6, 8, 9, 10 };

                for (int i = 0; i < Numbers.Length; i++)
                    if (!(Char.IsDigit(PhoneNumber.Text[Numbers[i]]))) isCorrect = false;
                if (PhoneNumber.Text[3] != '-' && PhoneNumber.Text[7] != '-') isCorrect = false;
            }
            else isCorrect = false;

            return isCorrect;
        }

        public bool IsEmailCorrect()
        {
            bool isCorrect = true;

            if (Email.Text.Contains('@'))
            {
                if (!(Email.Text.Contains(".com")) && !(Email.Text.Contains(".pl")))
                    isCorrect = false;
            }
            else isCorrect = false;

            return isCorrect;
        }

        public bool IsHouseNumberCorrect()
        {
            bool isCorrect = true;

            if (HouseNumber.Text.Length > 0)
            {
                if (!(Char.IsDigit(HouseNumber.Text[0])) || HouseNumber.Text[0] == '0') isCorrect = false;
                else if (Char.IsDigit(HouseNumber.Text[0]) && HouseNumber.Text[0] != '0')
                {
                    var DoesAddressContainLetter = HouseNumber.Text.Any(x => char.IsLetter(x));

                    if (DoesAddressContainLetter)
                    {
                        if (HouseNumber.Text.Length == 3)
                            if (Char.IsLetter(HouseNumber.Text[1])
                            && Char.IsLetter(HouseNumber.Text[2]))
                                isCorrect = false;
                    }
                }
            }

            return isCorrect;
        }

        public bool AreAllDataFilled()
        {
            bool Result = true;

            if (!(RunningCheckBoxOnline.IsChecked)
                && !(RunningCheckBoxOffline.IsChecked)
                && !(CyclingCheckBox.IsChecked))
            {
                Result = false;

                RunningCheckBoxOnline.Style = Resources["EmptyCheckBoxStyle"] as Style;
                RunningCheckBoxOffline.Style = Resources["EmptyCheckBoxStyle"] as Style;
                CyclingCheckBox.Style = Resources["EmptyCheckBoxStyle"] as Style;
            }

            if (RunningCheckBoxOffline.IsChecked)
            {
                if (!(FirstOptionHourRadioButton.IsChecked)
                    && !(SecondOptionHourRadioButton.IsChecked)
                    && !(ThirdOptionHourRadioButton.IsChecked))
                {
                    Result = false;
                    FirstOptionHourRadioButton.Style = Resources["EmptyRadioButtonStyle"] as Style;
                    SecondOptionHourRadioButton.Style = Resources["EmptyRadioButtonStyle"] as Style;
                    ThirdOptionHourRadioButton.Style = Resources["EmptyRadioButtonStyle"] as Style;
                }
            }

            if (FirstName.Text == null)
            {
                Result = false;
                FirstName.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else FirstName.Text = TextInformation.ToTitleCase(FirstName.Text);

            if (LastName.Text == null)
            {
                Result = false;
                LastName.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else LastName.Text = TextInformation.ToTitleCase(LastName.Text);

            if (Place.Text == null)
            {
                Result = false;
                Place.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else Place.Text = TextInformation.ToTitleCase(Place.Text);

            if (RunningCheckBoxOnline.IsChecked)
            {
                if (Postcode.Text == null)
                {
                    Result = false;
                    Postcode.Style = Resources["EmptyEntryStyle"] as Style;
                }
                else if (!(IsPostcodeCorrect()))
                {
                    Result = false;
                    Postcode.Text = null;
                    Postcode.Style = Resources["EmptyEntryStyle"] as Style;
                }

                if (Address.Text == null)
                {
                    Result = false;
                    Address.Style = Resources["EmptyEntryStyle"] as Style;
                }
                else Address.Text = TextInformation.ToTitleCase(Address.Text);

                if (HouseNumber.Text == null)
                {
                    Result = false;
                    HouseNumber.Style = Resources["EmptyEntryStyle"] as Style;
                }
                else if (!(IsHouseNumberCorrect()))
                {
                    Result = false;
                    HouseNumber.Text = null;
                    HouseNumber.Style = Resources["EmptyEntryStyle"] as Style;
                }
            }

            if (PhoneNumber.Text == null)
            {
                Result = false;
                PhoneNumber.Text = null;
                PhoneNumber.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else if (!(IsPhoneNumberCorrect()))
            {
                Result = false;
                PhoneNumber.Text = null;
                PhoneNumber.Style = Resources["EmptyEntryStyle"] as Style;
            }

            if (Email.Text == null)
            {
                Result = false;
                Email.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else if (!(IsEmailCorrect()))
            {
                Result = false;
                Email.Text = null;
                Email.Style = Resources["EmptyEntryStyle"] as Style;
            }

            if (Password.Text == null || Password.Text.Length < 8)
            {
                Result = false;
                Password.Text = null;
                Password.Style = Resources["EmptyEntryStyle"] as Style;
            }

            if (DateDatePicker.Date == DateDatePicker.MaximumDate)
            {
                Result = false;
                BirthDateLabel.TextColor = Color.Yellow;
            }

            if (!(AcceptanceRegulationsCheckBox.IsChecked))
            {
                Result = false;
                AcceptanceRegulationsCheckBox.Style = Resources["EmptyCheckBoxStyle"] as Style;
            }

            return Result;
        }

        public void SetValuesToVariables()
        {
            if (RunningCheckBoxOnline.IsChecked)
            {
                FirstDisciplineValue = "1";
                FirstDisciplineValueToDisplay = "Bieg wirtualny";
                RunHourValue = "0";
                RunHourValueToDisplay = "N/A";
                ServerOption1 = "true";
                if (CyclingCheckBox.IsChecked)
                {
                    SecondDisciplineValue = "true";
                    SecondDisciplineValueToDisplay = "Rowerem dla WOŚP";
                }
                else
                {
                    SecondDisciplineValue = "false";
                    SecondDisciplineValueToDisplay = "N/A";
                }
            }

            if (RunningCheckBoxOffline.IsChecked)
            {
                FirstDisciplineValue = "2";
                FirstDisciplineValueToDisplay = "Bieg stacjonarny";
                ServerOption1 = "true";

                if (CyclingCheckBox.IsChecked)
                {
                    SecondDisciplineValue = "true";
                    SecondDisciplineValueToDisplay = "Rowerem dla WOŚP";
                }

                else
                {
                    SecondDisciplineValue = "false";
                    SecondDisciplineValueToDisplay = "N/A";
                }

                if (FirstOptionHourRadioButton.IsChecked)
                {
                    RunHourValue = "1";
                    RunHourValueToDisplay = "12:00 - 14:00";
                }

                else if (SecondOptionHourRadioButton.IsChecked)
                {
                    RunHourValue = "2";
                    RunHourValueToDisplay = "14:00 - 16:00";
                }

                else if (ThirdOptionHourRadioButton.IsChecked)
                {
                    RunHourValue = "3";
                    RunHourValueToDisplay = "16:00 - 18:00";
                }
            }

            if (CyclingCheckBox.IsChecked
                && !(RunningCheckBoxOnline.IsChecked)
                && !(RunningCheckBoxOffline.IsChecked))
            {
                RunHourValue = "0";
                RunHourValueToDisplay = "N/A";
                FirstDisciplineValue = "0";
                FirstDisciplineValueToDisplay = "Rowerem dla WOŚP";
                SecondDisciplineValue = "true";
                SecondDisciplineValueToDisplay = "N/A";
                ServerOption1 = "false";
            }

            FirstNameValue = FirstName.Text;
            LastNameValue = LastName.Text;
            PlaceValue = Place.Text;

            if (Postcode.Text != null)
            {
                PostcodeValue = Postcode.Text;
                PostcodeValueToDisplay = PostcodeValue;
            }

            else
            {
                PostcodeValue = String.Empty;
                PostcodeValueToDisplay = "N/A";
            }

            if (Address.Text != null)
            {
                AddressValue = Address.Text;
                AddressValueToDisplay = AddressValue;
            }

            else
            {
                AddressValue = String.Empty;
                AddressValueToDisplay = "N/A";
            }

            if (HouseNumber.Text != null)
            {
                HouseNumberValue = HouseNumber.Text.ToString();
                HouseNumberValueToDisplay = HouseNumberValue;
            }

            else
            {
                HouseNumberValue = String.Empty;
                HouseNumberValueToDisplay = "N/A";
            }

            if (ApartmentNumber.Text != null)
            {
                ApartmentNumberValue = ApartmentNumber.Text.ToString();
                ApartmentNumberValueToDisplay = ApartmentNumberValue;
            }

            else
            {
                ApartmentNumberValue = String.Empty;
                ApartmentNumberValueToDisplay = "N/A";
            }
            PhoneNumberValue = PhoneNumber.Text;
            EmailValue = Email.Text;
            PasswordValue = Password.Text;
            BirthDateValue = DateDatePicker.Date.ToString("yyyy-MM-dd") + "r.";
        }

        public async Task<bool> DisplayAlertWithUserData()
        {
            var Contents =
                "\nImię: " + FirstNameValue
                + "\n\nNazwisko: " + LastNameValue
                + "\n\nData urodzenia: " + BirthDateValue
                + "\n\nPierwsza dyscyplina: " + FirstDisciplineValueToDisplay
                + "\n\nWybrana Godzina: " + RunHourValueToDisplay
                + "\n\nDruga dyscyplina: " + SecondDisciplineValueToDisplay
                + "\n\nMiejscowość: " + PlaceValue
                + "\n\nKod pocztowy: " + PostcodeValueToDisplay
                + "\n\nUlica: " + AddressValueToDisplay
                + "\n\nNumer domu: " + HouseNumberValueToDisplay
                + "\n\nNumer lokalu: " + ApartmentNumberValueToDisplay
                + "\n\nNumer telefonu: " + PhoneNumberValue
                + "\n\nE-mail: " + EmailValue;

            bool result = await DisplayAlert("Podane informacje użytkownika: ", Contents, "Ok", "Anuluj");
            return result;
        }

        private async void SendData(object sender, EventArgs e)
        {
            if (AreAllDataFilled())
            {
                SetValuesToVariables();

                Task<bool> Alert = DisplayAlertWithUserData();
                bool result = await Alert;
                if (result)
                {
                    if (Connector.Register(RunHourValue, FirstDisciplineValue, SecondDisciplineValue, FirstNameValue, LastNameValue, BirthDateValue, EmailValue, PasswordValue, PhoneNumberValue, PlaceValue, AddressValue + " " + HouseNumberValue + " " + ApartmentNumberValue + " " + PostcodeValue))
                    {
                        await Navigation.PopAsync();
                        await DisplayAlert("Brawo!", "Zostałeś zarejestrowany!", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Błąd!", Connector.lastError.ToString(), "OK");
                    }
                }
            }
            else await this.DisplayToastAsync("Nie wszystkie wymagane pola są wypełnione prawidłowo!", 3000);
        }
    }
}