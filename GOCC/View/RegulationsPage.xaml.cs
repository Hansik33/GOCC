using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using GOCC.Controls;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegulationsPage : ContentPage
    {
        string url = "https://drive.google.com/file/d/1PkHjIS2jrzWic3-c2jKQwWjF02mxqmkQ/view";
        public RegulationsPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                pdfView.Uri = url;
                pdfView.On<Android>().EnableZoomControls(true);
                pdfView.On<Android>().DisplayZoomControls(false);
            }
            else
            {
                pdfView.Source = url;
            }
        }
    }
}