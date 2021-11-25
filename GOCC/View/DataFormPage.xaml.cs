﻿using System;
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
        TextInfo TextInformation = new CultureInfo("pl-PL", false).TextInfo;

        // DATA
        public string FirstDisciplineValue;
        public string SecondDisciplineValue;
        public string FirstNameValue;
        public string LastNameValue;
        public string TownValue;
        public string PostcodeValue;
        public string AddressValue;
        public string HouseNumberValue;
        public string ApartmentNumberValue;
        public string PhoneNumberValue;
        public string EmailValue;
        public string PasswordValue;
        public string BirthDateValue;
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
                        "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż]+$");

                    if (e.NewTextValue.Length > 0)
                        GivenObject.Text
                            = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (ObjectName == "Town")
                {
                    var isValid = Regex.IsMatch(e.NewTextValue,
                        "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż ]+$");

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
                        "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż ]+$");

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
                        "^[A-Za-z~`!@#$%^&*()_+={[}|:;'<,>.?/ ]+$");

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
                    RunningCheckBoxOffline.Style = Resources["DisabledCheckBoxStyle"] as Style;

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
                }
            }

            else if (ObjectName == "RunningCheckBoxOffline")
            {
                if (RunningCheckBoxOffline.IsChecked)
                    RunningCheckBoxOnline.Style = Resources["DisabledCheckBoxStyle"] as Style;
                else RunningCheckBoxOnline.Style = Resources["DefaultCheckBoxStyle"] as Style;

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
            Navigation.PushAsync(new RegulationsPage());
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

            if (Town.Text == null)
            {
                Result = false;
                Town.Style = Resources["EmptyEntryStyle"] as Style;
            }
            else Town.Text = TextInformation.ToTitleCase(Town.Text);

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
                FirstDisciplineValue = "VII. Bieg z sercem WOŚP (Online)";
                if (CyclingCheckBox.IsChecked) SecondDisciplineValue = "Rowerem dla WOŚP";
                else SecondDisciplineValue = "Nie dotyczy";
            }
            if (RunningCheckBoxOffline.IsChecked)
            {
                FirstDisciplineValue = "VII. Bieg z sercem WOŚP (Offline)";
                if (CyclingCheckBox.IsChecked) SecondDisciplineValue = "Rowerem dla WOŚP";
                else SecondDisciplineValue = "Nie dotyczy";
            }
            if (CyclingCheckBox.IsChecked
                && !(RunningCheckBoxOnline.IsChecked)
                && !(RunningCheckBoxOffline.IsChecked))
            {
                FirstDisciplineValue = "Rowerem dla WOŚP";
                SecondDisciplineValue = "Nie dotyczy";
            }
            FirstNameValue = FirstName.Text;
            LastNameValue = LastName.Text;
            TownValue = Town.Text;
            if (Postcode.Text != null) PostcodeValue = Postcode.Text;
            else PostcodeValue = "Nie dotyczy";
            if (Address.Text != null) AddressValue = Address.Text;
            else AddressValue = "Nie dotyczy";
            if (HouseNumber.Text != null) HouseNumberValue = HouseNumber.Text;
            else HouseNumberValue = "Nie dotyczy";
            if (ApartmentNumber.Text != null) ApartmentNumberValue = ApartmentNumber.Text;
            else ApartmentNumberValue = "Nie dotyczy";
            PhoneNumberValue = PhoneNumber.Text;
            EmailValue = Email.Text;
            PasswordValue = Password.Text;
            BirthDateValue = DateDatePicker.Date.ToString("d");

            //       /*
            Console.WriteLine("Pierwsza dyscyplina" + FirstDisciplineValue);
            Console.WriteLine("Druga dyscyplina: " + SecondDisciplineValue);
            Console.WriteLine("Imię: " + FirstNameValue);
            Console.WriteLine("Nazwisko: " + LastNameValue);
            Console.WriteLine("Miasto: " + TownValue);
            Console.WriteLine("Kod pocztowy: " + PostcodeValue);
            Console.WriteLine("Ulica: " + AddressValue);
            Console.WriteLine("Numer domu: " + HouseNumberValue);
            Console.WriteLine("Numer lokalu: " + ApartmentNumberValue);
            Console.WriteLine("Numer telefonu: " + PhoneNumberValue);
            Console.WriteLine("E-mail: " + EmailValue);
            Console.WriteLine("Hasło: " + PasswordValue);
            Console.WriteLine("Data urodzenia: " + BirthDateValue);
            //       */
        }

        private async void SendData(object sender, EventArgs e)
        {
            if (AreAllEntriesFilled())
            {
                SetValuesToVariables();

                await Navigation.PopAsync();
            }
            else await this.DisplayToastAsync("Nie wszystkie wymagane pola są wypełnione prawidłowo!", 3000);
        }
    }
}