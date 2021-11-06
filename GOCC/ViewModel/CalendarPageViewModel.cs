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
        public ObservableCollection<TableCalendarData> TableData { get; set; }
        public CalendarPageViewModel()
        {
            TableData = new ObservableCollection<TableCalendarData>()
            {
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"},
                new TableCalendarData() {Time = "asdasd", Name = "asdasd", Localization = "asdasdsadasd"}
            };
        }

    }
}
