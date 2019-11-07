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
        //instance property must be static
        //public User CurrentUser { get; set; }
        public async void SignInProcedure(object sender, EventArgs e)
        {
            /*PN_XAML.Models.User user*/
            LoginManager.CurrentUser = new User(Username: Entry_Username.Text, Password: Entry_Password.Text);
            if (LoginManager.CurrentUser.CheckInformation())
            {
                var client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    {"name",LoginManager.CurrentUser.Username },
                    //{"name", "bob" }
                    //{"Password", LoginManager.CurrentUser.Password }
                };
                var content = new FormUrlEncodedContent(values);
                var a = new HttpClient();
                var response = await a.PostAsync("http://10.0.2.2:55587/user/login", content);
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