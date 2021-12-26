using System;
using GOCC.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Threading;


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
            Thread TimeThread = new Thread(() => TimeCalculatorTask());
            Thread DistanceThread = new Thread(() => DistanceCalculatorTask());
            BindingContext = viewModel;
            TimeThread.Start();
            DistanceThread.Start();
            InitializeComponent();
        }

        private void Stop_clicked(object sender, EventArgs e)
        {
            isdoing = false;
        }
        public async void DistanceCalculatorTask()
        {
            var prevlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
            await Task.Delay(500);
            while (isdoing)
            {
                var newlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1)));//pobranie danych
                newdistance = Location.CalculateDistance(newlocation, prevlocation, DistanceUnits.Kilometers);//obliczenie dystansu
                distanceToCheck = newdistance * 1000;
                /*if (distanceToCheck >= 5)//sprawdza czy nie ma błędu wynikającego z GPS
                {
                    totaldistance += 0.002;
                    viewModel.Distance = $"{totaldistance * 1000}";
                }
                else*/
                //{
                    totaldistance = totaldistance + newdistance;//dodanie do wyniku
                    viewModel.Distance = $"{Math.Round(totaldistance * 1000)}";
                //}

                prevlocation = newlocation;
                await Task.Delay(500);
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
    }
}