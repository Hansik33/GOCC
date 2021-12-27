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
        public string SecondDisciplineValue = "N/A";
        public string FirstNameValue;
        public string LastNameValue;
        public string PlaceValue;
        public string PostcodeValue = "N/A";
        public string AddressValue = "N/A";
        public string HouseNumberValue = "N/A";
        public string ApartmentNumberValue = "N/A";
        public string PhoneNumberValue;
        public string EmailValue;
        public string PasswordValue;
        public string BirthDateValue;
        public string serveroption1;
        public string RunHourOption;
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

                    if (Postcode.IsReadOnly)
                        Postcode.Style = Resources["DefaultEntryStyle"] as Style;

                    if (Address.IsReadOnly)
                        Address.Style = Resources["DefaultEntryStyle"] as Style;

                    if (HouseNumber.IsReadOnly)
                        HouseNumber.Style = Resources["DefaultEntryStyle"] as Style;

                    if (ApartmentNumber.IsReadOnly)
                        ApartmentNumber.Style = Resources["DefaultEntryStyle"] as Style;

                    if (CyclingCheckBox.Style == Resources["EmptyCheckBoxStyle"])
                        CyclingCheckBox.Style = Resources["DefaultCheckBoxStyle"] as Style;
                    HoursRadioButtons.IsVisible = false;
                }

                else
                {
                    RunningCheckBoxOffline.Style = Resources["DefaultCheckBoxStyle"] as Style;

                    if (!(Postcode.IsReadOnly))
                    {
                        Postcode.Text = null;
                        Postcode.Style = Resources["DisabledEntryStyle"] as Style;
                    }

                    if (!(Address.IsReadOnly))
                    {
                        Address.Text = null;
                        Address.Style = Resources["DisabledEntryStyle"] as Style;
                    }

                    if (!(HouseNumber.IsReadOnly))
                    {
                        HouseNumber.Text = null;
                        HouseNumber.Style = Resources["DisabledEntryStyle"] as Style;
                    }

                    if (!(ApartmentNumber.IsReadOnly))
                    {
                        ApartmentNumber.Text = null;
                        ApartmentNumber.Style = Resources["DisabledEntryStyle"] as Style;
                    }
                    HoursRadioButtons.IsVisible=true;
                }
            }

            else if (ObjectName == "RunningCheckBoxOffline")
            {
                if (RunningCheckBoxOffline.IsChecked)
                {
                    HoursRadioButtons.IsVisible = true;
                    RunningCheckBoxOnline.Style = Resources["DefaultCheckBoxStyle"] as Style;
                    if (RunningCheckBoxOnline.IsChecked) RunningCheckBoxOnline.IsChecked = false;
                }else HoursRadioButtons.IsVisible = false;

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

        public bool AreAllEntriesFilled()
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
                hour12_radiobtn.IsChecked = false;
                hour14_radiobtn.IsChecked = false;
                hour16_radiobtn.IsChecked = false;
                FirstDisciplineValue = "2";
                RunHourOption = "0";
                serveroption1 = "true";
                if (CyclingCheckBox.IsChecked) SecondDisciplineValue = "true"; else SecondDisciplineValue = "false";
            }
            if (RunningCheckBoxOffline.IsChecked)
            {
                FirstDisciplineValue = "1";
                serveroption1 = "true";
                if (CyclingCheckBox.IsChecked) SecondDisciplineValue = "true"; else SecondDisciplineValue = "false";
                if (hour12_radiobtn.IsChecked) RunHourOption = "1"; else if (hour14_radiobtn.IsChecked) RunHourOption = "2"; else if (hour16_radiobtn.IsChecked) RunHourOption = "3";
            }
            if (CyclingCheckBox.IsChecked
                && !(RunningCheckBoxOnline.IsChecked)
                && !(RunningCheckBoxOffline.IsChecked))
            {
                FirstDisciplineValue = "1";
                SecondDisciplineValue = "true";
                serveroption1 = "false";
            }

            FirstNameValue = FirstName.Text;
            LastNameValue = LastName.Text;
            PlaceValue = Place.Text;
            if (Postcode.Text != null) PostcodeValue = Postcode.Text; else PostcodeValue = "";
            if (Address.Text != null) AddressValue = Address.Text; else AddressValue = "";
            if (HouseNumber.Text != null) HouseNumberValue = HouseNumber.Text.ToString(); else HouseNumberValue = "";
            if (ApartmentNumber.Text != null) ApartmentNumberValue = ApartmentNumber.Text.ToString(); else ApartmentNumberValue = "";
            PhoneNumberValue = PhoneNumber.Text;
            EmailValue = Email.Text;
            PasswordValue = Password.Text;
            BirthDateValue = DateDatePicker.Date.ToString("d") + "r.";
        }

        public async Task<bool> DisplayAlertWithUserData()
        {
            string FirstDisciplineName, SecondDisciplineName,Hour;
            if(FirstDisciplineValue == "1")
            {
                FirstDisciplineName = "Bieg Stacjonarny";
            }
            else
            {
                FirstDisciplineName = "Bieg Wirtualny";
            }
            if (SecondDisciplineValue == "true")
            {
                SecondDisciplineName = "Rajd Rowerowy";
            }
            else
            {
                SecondDisciplineName = "Nie wybrano";
            }
            if (hour12_radiobtn.IsChecked) Hour = "12:00 - 14:00"; else if (hour14_radiobtn.IsChecked) Hour = "14:00 - 16:00"; else if (hour16_radiobtn.IsChecked) Hour = "16:00 - 18:00"; else Hour = "---------";
            var Contents =
                "\nImię: " + FirstNameValue
                + "\n\nNazwisko: " + LastNameValue
                + "\n\nData urodzenia: " + BirthDateValue
                + "\n\nPierwsza dyscyplina: " + FirstDisciplineName
                + "\n\n Wybrana Godzina: " + Hour
                + "\n\nDruga dyscyplina: " + SecondDisciplineName
                + "\n\nMiejscowość: " + PlaceValue
                + "\n\nKod pocztowy: " + PostcodeValue
                + "\n\nUlica: " + AddressValue
                + "\n\nNumer domu: " + HouseNumberValue
                + "\n\nNumer lokalu: " + ApartmentNumberValue
                + "\n\nNumer telefonu: " + PhoneNumberValue
                + "\n\nE-mail: " + EmailValue;

            bool result = await DisplayAlert("Podane informacje użytkownika: ", Contents, "Ok","Anuluj");
            return result;
        }

        private async void SendData(object sender, EventArgs e)
        {
            if (AreAllEntriesFilled())
            {

                SetValuesToVariables();

                Task<bool> Alert = DisplayAlertWithUserData();
                bool result = await Alert;
                if (result)
                {
                    if (Connector.Register(FirstDisciplineValue,SecondDisciplineValue,serveroption1,FirstNameValue, LastNameValue, BirthDateValue, EmailValue, PasswordValue, PhoneNumberValue, PlaceValue, AddressValue + " " + HouseNumberValue + " " + ApartmentNumberValue + " " + PostcodeValue))
                    {
                        await Navigation.PopAsync();
                        await DisplayAlert("Brawo!", "Zostałeś zarejestrowany!", "OK");
                    }
                    else if(Connector.lastError.ToString() == "1" || Connector.lastError.ToString() == "2")
                    {
                        await DisplayAlert("Błąd", "Jest już taki użytkownik", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Błąd",Connector.lastError.ToString(),"OK");
                    }
                }
            }
            else await this.DisplayToastAsync("Nie wszystkie wymagane pola są wypełnione prawidłowo!", 3000);
        }
    }
}