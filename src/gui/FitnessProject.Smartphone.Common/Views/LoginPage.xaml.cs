using PN_XAML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace PN_XAML.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public User CurrentUser { get; set; }
        public async void SignInProcedure(object sender, EventArgs e)
        {
            /*PN_XAML.Models.User user*/
            CurrentUser = new User(Username: Entry_Username.Text, Password: Entry_Password.Text);
            if (CurrentUser.CheckInformation())
            {
                var client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    {"Username",CurrentUser.Username },
                    {"Password", CurrentUser.Password }
                };
                var content = new FormUrlEncodedContent(values);
                var a = new HttpClient();
                var response = await a.PostAsync("https://ptsv2.com/t/z0u0o-1573035817/post", content);
                var responseString = await response.Content.ReadAsStringAsync();

                await DisplayAlert("Login", "Login Success", "Ok");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login", "Login Success", "Ok");
            }
        }


    }
}