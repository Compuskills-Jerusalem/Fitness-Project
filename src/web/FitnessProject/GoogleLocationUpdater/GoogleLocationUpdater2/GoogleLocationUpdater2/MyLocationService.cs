using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GoogleLocationUpdater2
{
    [BroadcastReceiver]
    public class MyLocationService : BroadcastReceiver
    {
        public static string ACTION_PROCESS_LOCATION = "GoogleLocationUpdater2.UPDATE_LOCATION";

        public override void OnReceive(Context context, Intent intent)
        {
            if(intent != null)
            {
                string action = intent.Action;
                if(action.Equals(ACTION_PROCESS_LOCATION))
                {
                    LocationResult result = LocationResult.ExtractResult(intent);
                    if(result != null)
                    {
                        var location = result.LastLocation;
                        var location_string = new StringBuilder("" + location.Latitude)
                            .Append("/").Append(location.Longitude).ToString();
                        try
                        {
                            //When app in foreground and background
                            MainActivity.GetInstance().UpdateTextView(location_string);
                        }
                        catch (Exception)
                        {
                            //When app killed
                            Toast.MakeText(context, location_string, ToastLength.Short).Show();
                        }
                    }
                }
            }
        }
    }
}