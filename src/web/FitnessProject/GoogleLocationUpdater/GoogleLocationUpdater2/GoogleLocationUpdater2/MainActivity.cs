using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Location;
using Com.Karumi.Dexter;
using Android;
using Com.Karumi.Dexter.Listener.Single;
using Com.Karumi.Dexter.Listener;
using System;
using Android.Support.V4.App;
using Android.Content;

namespace GoogleLocationUpdater2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IPermissionListener
    {
        LocationRequest locationRequest;
        FusedLocationProviderClient fusedLocationProviderClient;
        TextView txt_location;

        static MainActivity Instance;

        public static MainActivity GetInstance()
        {
            return Instance;
        }

        public void OnPermissionDenied(PermissionDeniedResponse p0)
        {
            Toast.MakeText(this, "You must accept this permission", ToastLength.Short).Show();
        }

        public void OnPermissionGranted(PermissionGrantedResponse p0)
        {
            UpdateLocation();
        }

       

        public void OnPermissionRationaleShouldBeShown(PermissionRequest p0, IPermissionToken p1)
        {

        }

        private void UpdateLocation()
        {
            BuildLocationRequest();
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted) 
                return;
            fusedLocationProviderClient.RequestLocationUpdates(locationRequest, GetPendingIntent());
        }

        private PendingIntent GetPendingIntent()
        {
            Intent intent = new Intent(this, typeof(MyLocationService));
            intent.SetAction(MyLocationService.ACTION_PROCESS_LOCATION);
            return PendingIntent.GetBroadcast(this, 0, intent, PendingIntentFlags.UpdateCurrent);
        }

        private void BuildLocationRequest()
        {
            locationRequest = new LocationRequest();
            locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequest.SetInterval(5000);
            locationRequest.SetFastestInterval(3000);
            locationRequest.SetSmallestDisplacement(10f);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Instance = this;

            txt_location = FindViewById<TextView>(Resource.Id.txt_location);

            Dexter.WithActivity(this)
                .WithPermission(Manifest.Permission.AccessFineLocation)
                .WithListener(this)
                .Check();
        }

        public void UpdateTextView(string text)
        {
            RunOnUiThread(() =>
           {
               txt_location.Text = text;
           });
        }
    }
}