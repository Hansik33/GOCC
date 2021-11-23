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
        public RegulationsPage()
        {
            InitializeComponent();
        }
    }
}