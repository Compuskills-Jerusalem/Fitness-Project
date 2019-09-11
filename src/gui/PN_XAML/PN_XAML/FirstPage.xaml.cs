using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections;
//using System;
//using System.Collections.Generic;
//using Xamarin.Essentials;
//using Xamarin.Forms;
//using System.Collections;
using System.Net.Mail;
using System.Net.Sockets;
//using Org.Apache.Http.Protocol;
using System.Net.Http.Headers;
using System.Net.Http;
//using Org.Apache.Http.Protocol;

namespace PN_XAML
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                
                //Location jrusalem = new Location(31.7683, 35.2137);
                //double distance = Xamarin.Essentials.Location.CalculateDistance(location, jrusalem, DistanceUnits.Kilometers);
                if (location != null)
                {
                    //Ben can change the first perameter to the projects server so it recieves the http message
                    PostRequest("http://10.0.2.2:55588/MobileGPS/RelayMessage", location.Latitude.ToString(), location.Longitude.ToString());

                    //    lblLatitude.Text = "Your Latitude: " + location.Latitude.ToString();
                    //    lblLongitude.Text = "Your Longitude:" + location.Longitude.ToString();
                    //}
                    //if (jrusalem != null)
                    //{
                    //    jrlblLatitude.Text = "Jr Latitude: " + jrusalem.Latitude.ToString();
                    //    jrlblLongitude.Text = "Jr Longitude:" + jrusalem.Longitude.ToString();
                    //}

                    //if (distance < 25)
                    //{
                    //    lblAlert.Text = ("you are being alerted because your distance from Jeruselum is less than 25 km, your current distance from jr is "+ Math.Round(distance)+" km");
                    lblConfirmation.Text = "You are not set up to recieve notification";

                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }

        }
        async static void PostRequest(string url, string latitude, string longitude)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                {new KeyValuePair<string, string>(key: "Latitude", value: latitude) },
                {new KeyValuePair<string, string>(key: "Longitude", value: longitude) }
            };
            FormUrlEncodedContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        Console.WriteLine(myContent);
                    }
                }
            }
        }
    }
}
