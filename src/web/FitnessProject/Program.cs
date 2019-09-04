using GeoCode.GeoCoding_Art;
using Newtonsoft.Json; //added JSON.NET with Nuget
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GeoCode
{
    class Program
    {

        const string Api = "AIzaSyCGjbtWwQsoYkzDDlubpVmikMunNIa2NyA";
        static string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        static string url2= "&key=" + Api+"&sensor=false";
        static void Main(string[] args)
        {
            string GeoCoding(string Address)
            {



                var Result = new WebClient().DownloadString(url + Address + url2);
                Response jsonResult = JsonConvert.DeserializeObject<Response>(Result);
                string status = jsonResult.status;
                string location = string.Empty;
                if (status == "OK")
                {
                    for (int i = 0; i < jsonResult.results.Length;i++)
                    {
                        location += "Latitude" + jsonResult.results[i].geometry.location.lat +
                             "/Longitude" + jsonResult.results[i].geometry.location.lng;
                       
                    }

                    return location;
                }
                else
                
                    return status;
                }
            Console.WriteLine("Enter a address");
            string input = Console.ReadLine();
            Console.WriteLine(GeoCoding(input));
            Console.ReadKey();
        }
          
        }
           
           
    }

