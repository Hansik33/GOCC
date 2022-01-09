using Android.App;
using Android.Content;
using System.Threading.Tasks;
using Android.OS;
using System.Threading;
using Xamarin.Forms;
using Android.Runtime;
using GOCC.Services;
using GOCC.Messages;
using GOCC.Droid.Helpers;
using Android.Util;

namespace GOCC.Droid.Services
{
    [Service]
    public class LocationService : Service
    {
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        CancellationTokenSource _cts;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent,StartCommandFlags flags, int startId)
        {

                _cts = new CancellationTokenSource();
                Notification notif = DependencyService.Get<INotification>().ReturnNotif();
                StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notif);
                
                Task.Run(() =>
                {
                    try
                    {
                        var DistanceTask = new LocalizationTask();
                        DistanceTask.Run(_cts.Token).Wait();
                    }
                    catch (OperationCanceledException)
                    {
                        
                    }
                    finally
                    {
                        if (_cts.IsCancellationRequested)
                        {
                            var message = new StopServiceMessage();
                            Device.BeginInvokeOnMainThread(
                              () =>  MessagingCenter.Send(message, "ServiceStoped")
                            );
                        }
                    }
                }, _cts.Token);
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            if(_cts != null)
            {
                _cts.Token.ThrowIfCancellationRequested();
                _cts.Cancel();
            }

            base.OnDestroy();
        }
    }
}