using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;
using System.Threading.Tasks;
using GOCC.Messages;

namespace GOCC.Services
{
    public class LocalizationTask
    {
        public double totaldistance = 0;
        double distanceToCheck = 0;
        double newdistance = 0;

        public readonly bool Stopping = true;

        public LocalizationTask()
        {

        }

        public async Task Run(CancellationToken token)
        {
            await Task.Run(async () =>
           {
               Location prevlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
               await Task.Delay(500);

               while (Stopping)
               {
                   try
                   {
                       token.ThrowIfCancellationRequested();
                       Location newlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));//pobranie danych
                       newdistance = Location.CalculateDistance(newlocation, prevlocation, DistanceUnits.Kilometers);//obliczenie dystansu
                       distanceToCheck = newdistance * 1000;

                       if (distanceToCheck >= 6)//sprawdza czy nie ma błędu wynikającego z GPS
                       {//dodanie wartości poprawiającej po GPS ERROR
                           totaldistance += 0.002;

                           var massage = new LocalizationMessage { Distance = totaldistance };
                           Device.BeginInvokeOnMainThread(() =>
                           {
                               MessagingCenter.Send<LocalizationMessage>(massage, "Distance");
                               Console.WriteLine(massage.Distance);
                           });

                       }
                       else//poprawne dodawanie wyniku
                       {
                           totaldistance = totaldistance + newdistance;//dodanie do wyniku
                           
                           var massage = new LocalizationMessage { Distance = totaldistance };
                           Device.BeginInvokeOnMainThread(() =>
                           {
                               MessagingCenter.Send<LocalizationMessage>(massage, "Distance");
                           });
                       }

                       prevlocation = newlocation;
                       await Task.Delay(500);
                   }
                   catch
                   {

                   }
               }

               /*try
               {
                   await Task.Delay(2000);

                   var request = new GeolocationRequest(GeolocationAccuracy.Best,TimeSpan.FromMinutes(1));
                   var location = await Geolocation.GetLocationAsync(request);
                   if (location != null)
                   {
                       var message = new LocalizationMessage
                       {
                           Latitude = location.Latitude,
                           Longitude = location.Longitude
                       };

                       Device.BeginInvokeOnMainThread(() =>
                       {
                           MessagingCenter.Send<LocalizationMessage>(message, "Location");
                       });
                   }
               }
               catch
               {
                   return;
               }*/
           },token);
        }   
    }
}
