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
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            InitializeComponent();

            

        }

       


        private void btnPeliculas_Clicked(object sender, EventArgs e)
        {
            btnPeliculas.BackgroundColor = Color.FromHex("#C80000");
            btnPeliculas.TextColor = Color.White;

            // Mostrar contenido relevante y ocultar el resto
            stckPeliculas.IsVisible = true;
            stckListas.IsVisible = false;
            stckDatos.IsVisible = false;

            // Resetear colores de los otros botones
            btnListas.BackgroundColor = Color.FromHex("#3A3A3A");
            btnListas.TextColor = Color.White;
            btnDatos.BackgroundColor = Color.FromHex("#3A3A3A");
            btnDatos.TextColor = Color.White;
        }
        private void btnListas_Clicked(object sender, EventArgs e)
        {
            // Cambiar color del botón
            btnListas.BackgroundColor = Color.FromHex("#C80000");
            btnListas.TextColor = Color.White;

            // Mostrar contenido relevante y ocultar el resto
            stckPeliculas.IsVisible = false;
            stckListas.IsVisible = true;
            stckDatos.IsVisible = false;

            // Resetear colores de los otros botones
            btnPeliculas.BackgroundColor = Color.FromHex("#3A3A3A");
            btnPeliculas.TextColor = Color.White;
            btnDatos.BackgroundColor = Color.FromHex("#3A3A3A");
            btnDatos.TextColor = Color.White;
        }

        private void btnDatos_Clicked(object sender, EventArgs e)
        {
            btnDatos.BackgroundColor = Color.FromHex("#C80000");
            btnDatos.TextColor = Color.White;

            // Mostrar contenido relevante y ocultar el resto
            stckPeliculas.IsVisible = false;
            stckListas.IsVisible = false;
            stckDatos.IsVisible = true;

            // Resetear colores de los otros botones
            btnPeliculas.BackgroundColor = Color.FromHex("#3A3A3A");
            btnPeliculas.TextColor = Color.White;
            btnListas.BackgroundColor = Color.FromHex("#3A3A3A");
            btnListas.TextColor = Color.White;
        }

   

        private void btnEliminarCuenta_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCambiarUser_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCambiarPass_Clicked(object sender, EventArgs e)
        {

        }

        private void btnVerPassword_Clicked(object sender, EventArgs e)
        {
            btnVerPassword.IsVisible = false;
            btnOcultarPassword.IsVisible = true;
            txtContra.IsPassword = false;
           
            
        }

        private void btnOcultarPassword_Clicked(object sender, EventArgs e)
        {
            btnVerPassword.IsVisible = true;
            btnOcultarPassword.IsVisible = false;
            txtContra.IsPassword = true;
        }
    }
}