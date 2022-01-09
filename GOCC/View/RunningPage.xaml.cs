using System;
using GOCC.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Threading;
using Android.Views;
using GOCC.Messages;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunningPage : ContentPage
    {
        public Stopwatch stopwatch = new Stopwatch();
        RunningPageViewModel viewModel = new RunningPageViewModel();
        public double totaldistance = 0;
        public bool isdoing = true;

        public RunningPage()
        {
            PermissionsAccept();
<<<<<<< Updated upstream
            Thread TimeThread = new Thread(() => TimeCalculatorTask());
            Thread DistanceThread = new Thread(() => DistanceCalculatorTask());
=======
>>>>>>> Stashed changes
            BindingContext = viewModel;
            TimeThread.Start();
            DistanceThread.Start();
            InitializeComponent();
        }

        private async void Stop_clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("UWAGA","Czy napewno chcesz już zakończyć bieg i wysłać wynik?","Ok","Anuluj");
            if (result == true)
            {
                isdoing = false;
                totaldistance = Math.Round(totaldistance,2);
                if (Connector.Send($"{stopwatch.Elapsed.Hours.ToString()}:{stopwatch.Elapsed.Minutes.ToString()}:{stopwatch.Elapsed.Seconds.ToString()} ", totaldistance.ToString()))
                {
                    await DisplayAlert("Gratulacje!",$"Udało ci się przejść: {totaldistance} km","Ok");
                    Application.Current.MainPage = new MainFlyoutPage();
                }
                else
                {
                    await DisplayAlert("Błąd", Connector.lastError.ToString(), "OK");
                }
            }
            else
            {
                
            }
            
        }
        public async void PermissionsAccept()
        {
            Location Perrmisions = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
        }
        public async void DistanceCalculatorTask()
        {
            Location prevlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
            await Task.Delay(500);
            while (isdoing)
            {
                try
                {
                Location newlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));//pobranie danych
                newdistance = Location.CalculateDistance(newlocation, prevlocation, DistanceUnits.Kilometers);//obliczenie dystansu
                distanceToCheck = newdistance * 1000;

                if (distanceToCheck >= 10)//sprawdza czy nie ma błędu wynikającego z GPS
                {
                    totaldistance += 0.002;
                    if (totaldistance < 1)
                    {
                        viewModel.Distance = $"{Math.Round(totaldistance * 1000)}";
                        viewModel.Unit = "m";
                    }
                    else
                    {
                        viewModel.Distance = $"{Math.Round(totaldistance)}";
                        viewModel.Unit = "km";
                    }
                }
                else
                {
                    totaldistance = totaldistance + newdistance;//dodanie do wyniku
                    if(totaldistance < 1)
                    {
                        viewModel.Distance = $"{Math.Round(totaldistance * 1000)}";
                        viewModel.Unit = "m";
                    }
                    else
                    {
                        viewModel.Distance = $"{Math.Round(totaldistance)}";
                        viewModel.Unit = "km";
                    }
                    
                }

                prevlocation = newlocation;
                await Task.Delay(500);
                }
                catch
                {

                }  
            }
        }
        async void TimeCalculatorTask()
        {
            stopwatch.Start();
            while (isdoing)
            {
                viewModel.Time = $"{stopwatch.Elapsed.Hours.ToString()}:{stopwatch.Elapsed.Minutes.ToString()}:{stopwatch.Elapsed.Seconds.ToString()}";
                await Task.Delay(1000);
            }
        }

        private async void StopRunningButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Uwaga!", "Czy chcesz zakończyć już bieg? Nie będziesz mógł już go powtórzyć!", "Zakończ bieg", "Anuluj");
            if (result)
            {
                if (Connector.Send(viewModel.Time.ToString(), viewModel.Distance.ToString()))
                {
                    var message = new StopServiceMessage();
                    MessagingCenter.Send(message, "ServiceStoped");
                    await DisplayAlert("Brawo!",$"Udało ci się przebiec {viewModel.Distance}, wynik został zapisany!","Ok");
                    Application.Current.MainPage = new MainFlyoutPage();
                }
                else
                {
                    await DisplayAlert("Błąd",Connector.lastError,"ok");
                }
            }
            
        }
    }
}