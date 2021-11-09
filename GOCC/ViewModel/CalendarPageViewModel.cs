using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using GOCC.Model;

namespace GOCC.ViewModel
{
    class CalendarPageViewModel : BindableObject
    {
        public ObservableCollection<TableCalendarData> TableData1 { get; set; }
        public ObservableCollection<TableCalendarData> TableData2 { get; set; }
        public CalendarPageViewModel()
        {
            TableData1 = new ObservableCollection<TableCalendarData>()
            {
                new TableCalendarData() {Time = "10:00 - 18:00", Name = "Pływamy z WOŚP", Localization = " MORiS pl. Powstańców Śląskich 1"},
                new TableCalendarData() {Time = "12:00 - 14:00", Name = "Rowerem z WOŚP", Localization = "Ulice miasta Chorzów"},
                new TableCalendarData() {Time = "16:00 - 20:00", Name = "Niebieskie Disco-Lodowisko", Localization = "Lodowisko Chorzów Rynek"},

            };
            TableData2 = new ObservableCollection<TableCalendarData>()
            {
                new TableCalendarData() {Time = "9:00 - 12:00", Name = "Bieg dzieci dla WOŚP", Localization = "MORiS ul. Lompy 10 A"},
                new TableCalendarData() {Time = "12:00 - 18:00", Name = "VII. Bieg z sercem WOŚP", Localization = "MORiS ul. Lompy 10 A"},
                new TableCalendarData() {Time = "12:00 - 18:00", Name = "Mecz hokeja", Localization = "Lodowisko Chorzów Rynek"},
                new TableCalendarData() {Time = "14:00 - 18:00", Name = "Muzyczny WOŚP", Localization = "MORiS ul. Dąbrowskiego 113"},
                new TableCalendarData() {Time = "17:00 - 20:00", Name = "V. WOŚP w rytmie Zumby", Localization = "ZST nr 1 ul. Sportowa 23"},
            };
        }

    }
}