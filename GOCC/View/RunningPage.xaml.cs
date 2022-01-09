using System;
using GOCC.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Threading;
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
        double distanceToCheck = 0;
        double newdistance = 0;
        public RunningPage()
        {
            PermissionsAccept();
            //Thread TimeThread = new Thread(() => TimeCalculatorTask());
            //Thread DistanceThread = new Thread(() => DistanceCalculatorTask());
            //TimeThread.Start();
            //DistanceThread.Start();
            BindingContext = viewModel;
            InitializeComponent();
        }
        public async void PermissionsAccept()
        {
            Location Perrmisions = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
        }
        /*public async void DistanceCalculatorTask()
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
        }*/
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
            bool result = await DisplayAlert("UWAGA!", "Czy napewno chcesz zakończyć bieg?", "Zakończ", "Biegnij dalej");
            if (result)
            {
                if (Connector.Send(viewModel.Time.ToString(), viewModel.Distance.ToString()))
                {
                    var message = new StopServiceMessage();
                    MessagingCenter.Send(message, "ServiceStoped");
                    await DisplayAlert("Brawo!", $"Udało ci się przebiec {viewModel.Distance}, wynik zapisano!", "Ok");
                    Application.Current.MainPage = new MainFlyoutPage();
                }
                else
                {
                    await DisplayAlert("Uwaga!", Connector.lastError, "Ok");
                }
            }
        }
    }
}