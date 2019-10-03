using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace FitnessProject.Web.Calc
{
    class Program
    {
        static void CalcPlace(Location User, List<KeyValuePair<double, double>> DeathZones)
        {
            foreach (var DeathZoneItem in DeathZones)
            {
                Location DZone = new Location(DeathZoneItem.Key, DeathZoneItem.Value);
                var distance = Location.CalculateDistance(User, DZone, DistanceUnits.Kilometers);
                if (distance < 0.1)
                {
                    Console.WriteLine("You are about to commit suicide stuffing your face with bad food. SAVE YOURSELF.");
                }

            }
        }


        static void Main(string[] args)
        {
            Location Jerusalem = new Location(31.7683, 35.2137);

            Location BeitShemesh = new Location(31.7470, 34.9881);
            Location BS2 = new Location(31.7470, 34.9881);

            Location TelAviv = new Location(32.0853, 34.7818);
           
            Location CompuskillsJerusalem = new Location(31.7903, 35.2013);
            Location CJ2 = new Location(31.7903, 35.2013);

            

            List<KeyValuePair<double, double>> DeathZones = new List<KeyValuePair<double, double>>()
        {
        new KeyValuePair<double, double>( Jerusalem.Latitude, Jerusalem.Longitude),
        new KeyValuePair<double, double>( TelAviv.Latitude, TelAviv.Longitude),
       //new KeyValuePair<double, double>( BS2.Latitude, BS2.Longitude),
       // new KeyValuePair<double, double>(CompuskillsJerusalem.Latitude, CompuskillsJerusalem.Longitude),
        new KeyValuePair<double, double>(CJ2.Latitude, CJ2.Longitude)
        };

            CalcPlace(CompuskillsJerusalem, DeathZones);



            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
