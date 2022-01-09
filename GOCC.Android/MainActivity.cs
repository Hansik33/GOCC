using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
<<<<<<< Updated upstream
=======
using GOCC.Droid.Services;
using GOCC.Messages;
using Android.Views;
>>>>>>> Stashed changes

namespace GOCC.Droid
{
    [Activity(Label = "Bieg z sercem WOŚP", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Icon = "@mipmap/appicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
<<<<<<< Updated upstream
=======

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            ToggleScreenLock();
            serviceintent = new Intent(this, typeof(LocationService));
            serviceintent2 = new Intent(this, typeof(TimeService));
            WireUpLongRuningTasks();
            var mPowerManager = (PowerManager)GetSystemService(Context.PowerService);
            var mWakeLock = mPowerManager.NewWakeLock(WakeLockFlags.Partial, "X");
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M && !Android.Provider.Settings.CanDrawOverlays(this))
            {
                var intent = new Intent(Android.Provider.Settings.ActionManageOverlayPermission);
                intent.SetFlags(ActivityFlags.NewTask);
                this.StartActivity(intent);
            }
>>>>>>> Stashed changes
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
<<<<<<< Updated upstream
=======
        void WireUpLongRuningTasks()
        {
            MessagingCenter.Subscribe<StartServiceMessage>(this, "ServiceStarted", message =>
             {
                 if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                 {
                     StartForegroundService(serviceintent);
                     StartForegroundService(serviceintent2);
                 }
                 else
                 {
                     StartService(serviceintent);
                     StartService(serviceintent2);
                 }
             });
            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStoped", message =>
              {
                    StopService(serviceintent);
                    StopService(serviceintent2);
              });
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RequestCode)
            {
                if (Android.Provider.Settings.CanDrawOverlays(this))
                {

                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
        public void ToggleScreenLock()
        {
            DeviceDisplay.KeepScreenOn = true;
        }
>>>>>>> Stashed changes
    }
}