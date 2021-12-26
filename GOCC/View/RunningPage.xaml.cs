using System;
using GOCC.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;


namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunningPage : ContentPage
    {

        RunningPageViewModel viewModel = new RunningPageViewModel();
        public RunningPage()
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        private void Stop_clicked(object sender, EventArgs e)
        {
            
        }
    }
}