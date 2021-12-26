using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace GOCC.ViewModel
{
    internal class RunningPageViewModel : BindableObject
    {
        private string _time;
        private string _distance;
        public RunningPageViewModel()
        {
            _time = "00:00:00";
            _distance = "0000";
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
    }
}
