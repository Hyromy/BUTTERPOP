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
            Application.Current.MainPage = new NavigationPage(new LoginPage()); 
        }
    }
}