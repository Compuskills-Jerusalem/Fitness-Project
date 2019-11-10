using DatabaseConn;
using FitnessProject.Web.Notifications;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace FitnessProject.Web.Calc
{
    public static class LocationCalc
    {
        public static void CalcPlace(IEnumerable<NoGoZone> NoGoUsers, Location User)
        {
            foreach (var DeathZoneItem in NoGoUsers)
            {
                Location DZone = new Location(DeathZoneItem.Laditude, DeathZoneItem.Longitude);
                var distance = Location.CalculateDistance(User, DZone, DistanceUnits.Kilometers);
                if (distance < 0.1)

                {
                    EMailNotification n = new EMailNotification();
                    MessageData messageData = new MessageData()
                    {
                        EMail = "ykosbie@compuskills.org",
                        MsgBody = string.Format("The Latitude is {0} and the Longitude is {1}.", User.Latitude, User.Longitude),
                        MsgHeader = "Test is Working",
                        TelNr = "972586846003"
                    };
                    n.Send(messageData);
                    SMSNotification s = new SMSNotification();
                    s.Send(messageData);


                }
            }


       // static void Main(string[] args)
       // {
       //     Location Jerusalem = new Location(31.7683, 35.2137);

       //     Location BeitShemesh = new Location(31.7470, 34.9881);
       //     Location BS2 = new Location(31.7470, 34.9881);

       //     Location TelAviv = new Location(32.0853, 34.7818);
           
       //     Location CompuskillsJerusalem = new Location(31.7903, 35.2013);
       //     Location CJ2 = new Location(31.7903, 35.2013);

            

       //     List<KeyValuePair<double, double>> DeathZones = new List<KeyValuePair<double, double>>()
       // {
       // new KeyValuePair<double, double>( Jerusalem.Latitude, Jerusalem.Longitude),
       // new KeyValuePair<double, double>( TelAviv.Latitude, TelAviv.Longitude),
       ////new KeyValuePair<double, double>( BS2.Latitude, BS2.Longitude),
       //// new KeyValuePair<double, double>(CompuskillsJerusalem.Latitude, CompuskillsJerusalem.Longitude),
       // new KeyValuePair<double, double>(CJ2.Latitude, CJ2.Longitude)
       // };

       //     CalcPlace(CompuskillsJerusalem, DeathZones);



       //     Console.ReadKey();

       //     // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
       // }
    }
}
