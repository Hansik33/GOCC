using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;
using System.Threading.Tasks;

namespace GOCC.Services
{
    public class LocalizationTask
    {
        public double totaldistance = 0;
        double distanceToCheck = 0;
        double newdistance = 0;
<<<<<<< Updated upstream
        public bool Stopping;
=======

        public bool Stopping = true;
>>>>>>> Stashed changes

        public LocalizationTask()
        {
            
        }

        public async Task Run(CancellationToken token)
        {
<<<<<<< Updated upstream
            await Task.Run( async () =>
            {
                Location prevlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
                await Task.Delay(500);

                while (Stopping)
                {
                    token.ThrowIfCancellationRequested();

                    try
                    {
                        Location newlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));//pobranie danych
                        newdistance = Location.CalculateDistance(newlocation, prevlocation, DistanceUnits.Kilometers);//obliczenie dystansu
                        distanceToCheck = newdistance * 1000;

                        if (distanceToCheck >= 10)//sprawdza czy nie ma błędu wynikającego z GPS
                        {
                            totaldistance += 0.002;

                            if (totaldistance < 1)
                            {

                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            totaldistance = totaldistance + newdistance;//dodanie do wyniku
                            if (totaldistance < 1)
                            {

                            }
                            else
                            {

                            }

                        }

                        prevlocation = newlocation;
                        await Task.Delay(500);
                    }
                }
            }
        }

        
=======
            await Task.Run(async () =>
           {
               Location prevlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
               await Task.Delay(1000);
               while (Stopping)
               {

                       token.ThrowIfCancellationRequested();
                       Location newlocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));//pobranie danych
                       newdistance = Location.CalculateDistance(newlocation, prevlocation, DistanceUnits.Kilometers);//obliczenie dystansu
                       distanceToCheck = newdistance * 1000;

                       if (distanceToCheck >= 11)//sprawdza czy nie ma błędu wynikającego z GPS
                       {
                           totaldistance += 0.003;//dodanie wartości poprawiającej po GPS ERROR
                           var massage = new LocalizationMessage { Distance = totaldistance };
                           Device.BeginInvokeOnMainThread(() =>
                           {
                               MessagingCenter.Send<LocalizationMessage>(massage, "Distance");
                           });
                       }
                       else
                       {
                           totaldistance = totaldistance + newdistance;//dodanie do wyniku
                           var massage = new LocalizationMessage { Distance = totaldistance };
                           Device.BeginInvokeOnMainThread(() =>
                           {
                               MessagingCenter.Send<LocalizationMessage>(massage, "Distance");
                           });
                       }
                       prevlocation = newlocation;
                       await Task.Delay(1000);
               }
           },token);
        }   
>>>>>>> Stashed changes
    }
}
