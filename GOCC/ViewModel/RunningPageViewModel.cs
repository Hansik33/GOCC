using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using GOCC.Messages;
using GOCC.Utils;
using Android.OS;

namespace GOCC.ViewModel
{
    internal class RunningPageViewModel : BindableObject
    {
        private string _time;
        private string _distance;
        public Command StopCommand { get; }
        readonly ILocationConsent locationConsent;
        public RunningPageViewModel()
        {
            locationConsent = DependencyService.Get<ILocationConsent>();
            _time = "00:00:00";
            _distance = "0000";
            Start();
            HandleReceivedMassages();
            StopCommand = new Command(() => OnStopClick());
            ValidateStatus();
        }
        void Start()
        {
            var message = new StartServiceMessage();
            MessagingCenter.Send(message, "ServiceStarted");
            SecureStorage.SetAsync(Constants.SERVICE_STATUS_KEY, "1");
        }
        public void OnStopClick()
        {
            var message = new StopServiceMessage();
            MessagingCenter.Send(message, "ServiceStoped");
        }
        public void ValidateStatus()
        {
            var status = SecureStorage.GetAsync(Constants.SERVICE_STATUS_KEY).Result;
            if(status != null && status.Equals("1"))
            {
                Start();
            }
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
        void HandleReceivedMassages()
        {
            MessagingCenter.Subscribe<LocalizationMessage>(this, "Distance", message => {
                Device.BeginInvokeOnMainThread(() => {
                    if (message.Distance >= 1)
                    {
                        Distance = $"{message.Distance} m";
                    }
                    else
                    {
                        Distance = $"{message.Distance} km";
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
        }
    }
}
