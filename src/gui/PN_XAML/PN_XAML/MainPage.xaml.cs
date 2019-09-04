using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PN_XAML
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void onCheckBoxCheckedChange(object sender, CheckedChangedEventArgs e)
        {
            if (phoneSelect.IsChecked == true)
            {
                fridgeSelect.IsChecked = false;
                DoorSelect.IsChecked = false;
            }
            if (fridgeSelect.IsChecked == true)
            {
                phoneSelect.IsChecked = false;
                DoorSelect.IsChecked = false;
            }
            if (DoorSelect.IsChecked == true)
            {
                phoneSelect.IsChecked = false;
                fridgeSelect.IsChecked = false;

            }
        }
        private async void NavigationButton_OnCliced(object sender, EventArgs e)
        {
            if (phoneSelect.IsChecked == true)
            {
                await Navigation.PushAsync(new FirstPage());
            }
            if (fridgeSelect.IsChecked == true)
            {
                await Navigation.PushAsync(new SecondPage());
            }
            if(DoorSelect.IsChecked == true)
            {
                await Navigation.PushAsync(new ThirdPage());
            }

        }
    }
}
