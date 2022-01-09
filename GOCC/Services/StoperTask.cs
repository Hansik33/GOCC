using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GOCC.Messages;

namespace GOCC.Services
{
    public class StoperTask
    {
        bool isdoing = true;
        Stopwatch stopwatch = new Stopwatch();
        public StoperTask()
        {

        }
        public async Task Run(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                stopwatch.Start();
                while (isdoing)
                {
                    token.ThrowIfCancellationRequested();
                    var message = new TimeMessage { Time = $"{stopwatch.Elapsed.Hours.ToString()}:{stopwatch.Elapsed.Minutes.ToString()}:{stopwatch.Elapsed.Seconds.ToString()}" };
                    //Console.WriteLine("TIMER DZIAŁA");
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send<TimeMessage>(message, "Time");
                    });
                    await Task.Delay(1000);
                }
            },token);
        }
    }
}
