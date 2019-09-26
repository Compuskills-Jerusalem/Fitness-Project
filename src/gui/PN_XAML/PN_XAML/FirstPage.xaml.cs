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
using System.Threading;

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

            lblConfirmation.Text = "You are not set up to recieve notification";

            while (true)
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();


                    if (location != null)
                    {
                        int userID = 1;

                        PostRequest("http://t/3b1jh-1569316876/post", location.Latitude.ToString(), location.Longitude.ToString(), userID.ToString());
                        
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
            Thread.Sleep(10000);
            }


            
        }
        async static void PostRequest(string url, string latitude, string longitude, string userId)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                {new KeyValuePair<string, string>(key: "Latitude", value: latitude) },
                {new KeyValuePair<string, string>(key: "Longitude", value: longitude) },
                {new KeyValuePair<string, string>(key: "UserId", value: userId) }
            };
            FormUrlEncodedContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, q))
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
