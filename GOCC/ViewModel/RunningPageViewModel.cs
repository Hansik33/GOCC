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
        private string _unit;
        public RunningPageViewModel()
        {
            _time = "00:00:00";
            _distance = "0000";
            _unit = "km";
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
            get { return _unit; }
            set { _unit = value; OnPropertyChanged("Unit"); }
        }
    }
}
