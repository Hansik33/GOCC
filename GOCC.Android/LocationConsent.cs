using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;
using GOCC.Droid;
using GOCC;

[assembly: Xamarin.Forms.Dependency(typeof(LocationConsent))]
namespace GOCC.Droid
{
    public class LocationConsent : ILocationConsent
    {
        public async Task GetLocationConsent()
        {
            await Permissions.RequestAsync<Permissions.LocationAlways>();
        }
    }
}