using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOCC.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            BindingContext = new CalendarPageViewModel();
            InitializeComponent();
        }
    }
}