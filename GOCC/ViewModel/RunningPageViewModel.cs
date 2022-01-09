using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
<<<<<<< Updated upstream
=======
using GOCC.Messages;
using GOCC.Utils;
using Android.OS;
using Xamarin.Forms.Xaml;
>>>>>>> Stashed changes

namespace GOCC.ViewModel
{
    internal class RunningPageViewModel : BindableObject
    {
        private string _time;
        private string _distance;
<<<<<<< Updated upstream
        private string _unit;
=======
        readonly ILocationConsent locationConsent;
>>>>>>> Stashed changes
        public RunningPageViewModel()
        {
            _time = "00:00:00";
            _distance = "0000";
<<<<<<< Updated upstream
            _unit = "km";
=======
            Start();
            HandleReceivedMassages();
            ValidateStatus();
        }
        void Start()
        {
            var message = new StartServiceMessage();
            MessagingCenter.Send(message, "ServiceStarted");
            SecureStorage.SetAsync(Constants.SERVICE_STATUS_KEY, "1");
        }
        public void ValidateStatus()
        {
            var status = SecureStorage.GetAsync(Constants.SERVICE_STATUS_KEY).Result;
            if(status != null && status.Equals("1"))
            {
                Start();
            }
>>>>>>> Stashed changes
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged("Time"); }
        }
        public string Distance
        {
            get { return _distance; }
            set { _distance = value; OnPropertyChanged("Distance"); }
        }
        public string Unit
        {
<<<<<<< Updated upstream
            get { return _unit; }
            set { _unit = value; OnPropertyChanged("Unit"); }
=======
            MessagingCenter.Subscribe<LocalizationMessage>(this, "Distance", message => {
                Device.BeginInvokeOnMainThread(() => {
                    if (message.Distance > 1)
                    {
                        Distance = $"{Math.Round(message.Distance,2)} km";
                    }
                    else
                    {
                        Distance = $"{Math.Round(message.Distance * 1000)} m";
                    }
                });
            });
            MessagingCenter.Subscribe<TimeMessage>(this, "Time", message =>
              {
                  Device.BeginInvokeOnMainThread(() =>
                  {
                      Time = message.Time;
                  });
              });
>>>>>>> Stashed changes
        }
    }
}
