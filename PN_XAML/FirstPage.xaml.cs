using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections;


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
                
                Location jrusalem = new Location(31.7683, 35.2137);
                double distance = Xamarin.Essentials.Location.CalculateDistance(location, jrusalem, DistanceUnits.Kilometers);
                if (location != null)
                {
                    lblLatitude.Text = "Your Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Your Longitude:" + location.Longitude.ToString();
                }
                if (jrusalem != null)
                {
                    jrlblLatitude.Text = "Jr Latitude: " + jrusalem.Latitude.ToString();
                    jrlblLongitude.Text = "Jr Longitude:" + jrusalem.Longitude.ToString();
                }

                if (distance < 25)
                {
                    lblAlert.Text = ("you are being alerted because your distance from Jeruselum is less than 25 km, your current distance from jr is "+ Math.Round(distance)+" km");
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
    }
}
