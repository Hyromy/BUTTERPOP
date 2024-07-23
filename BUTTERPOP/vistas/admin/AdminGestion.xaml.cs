using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BUTTERPOP.db.Table;

namespace BUTTERPOP.vistas.admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminGestion : ContentPage
    {
        public AdminGestion()
        {
            InitializeComponent();
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas salir?", "Confirmar", "Cancelar");

            if (confirmacion)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }

        }

        private void btnUsuarios_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.admin.GestionUsuarios());
        }

        private void btnPeliculas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.admin.GestionPeliculas());

        }
    }
}