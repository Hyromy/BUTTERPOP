using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            StartTimer();
        }

        private async void StartTimer()
        {
            await Task.Delay(3000);
            var loginPage = new LoginPage();
            var navigationPage = new NavigationPage(loginPage);
            Application.Current.MainPage = navigationPage;
            await Task.Delay(10);
            await loginPage.Content.FadeTo(0, 0); 
            await loginPage.Content.FadeTo(1, 500); 
        }
    }
}