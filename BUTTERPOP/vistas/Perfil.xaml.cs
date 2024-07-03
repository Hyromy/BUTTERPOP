using BUTTERPOP.modelo;
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
        private Usuarios _currentUser;
        public Perfil()
        {
            InitializeComponent();

        }


        public Perfil(string usuario, string correo, string password) : this()
        {
            InitializeComponent();
            BindingContext = new PerfilViewModel(usuario, correo, password);
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

        private bool ValidarDatosActualizacion()
        {
            return !string.IsNullOrEmpty(txtNombreUsuario.Text) &&
                   !string.IsNullOrEmpty(txtContra.Text);
        }

        private async void btnCambiarUser_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatosActualizacion())
            {
                _currentUser.usuario = txtNombreUsuario.Text;

                await App.SQLiteDB.UpdateUsuarioAsync(_currentUser);

                bool confirmacion = await DisplayAlert("Advertencia", "¿Estas seguro que deseas actualizar tu nombre de usuario?", "Confirmar", "Cancelar");

                if (confirmacion)
                {
                    await DisplayAlert("Actualización Exitosa", "Tu usuario ha sido actualizado correctamente", "Aceptar");
                } 
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos para continuar", "Aceptar");
            }
        }

        private async void btnCambiarPass_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatosActualizacion())
            {
                _currentUser.password = txtContra.Text;

                await App.SQLiteDB.UpdateUsuarioAsync(_currentUser);

                bool confirmacion = await DisplayAlert("Advertencia", "¿Estas seguro que deseas actualizar tu contraseña?", "Confirmar", "Cancelar");

                if (confirmacion)
                {
                    await DisplayAlert("Actualización Exitosa", "Tu contraseña ha sido actualizada correctamente", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos para continuar", "Aceptar");
            }
        }

        private async void btnEliminarCuenta_Clicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas eliminar tu cuenta?", "Confirmar", "Cancelar");

            if (confirmacion)
            {
                await App.SQLiteDB.DeleteUsuarioAsync(_currentUser);
                await DisplayAlert("Cuenta Eliminada", "Tu cuenta ha sido eliminada correctamente", "Aceptar");

                
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
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