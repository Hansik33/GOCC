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
        public bool Stopping;

        public LocalizationTask()
        {
            
        }

        public async Task Run(CancellationToken token)
        {
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

        
    }
}
