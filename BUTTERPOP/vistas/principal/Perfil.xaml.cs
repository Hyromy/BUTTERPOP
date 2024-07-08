using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.crud.usuario;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        private CRUD_Usuario crud = new CRUD_Usuario();

        public Perfil()
        {
            InitializeComponent();
            LlenarDatos();

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

        private async void btnEliminarCuenta_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas eliminar tu cuenta?", "Confirmar", "Cancelar");

                var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                if (confirmacion)
                {
                    if (usuario != null)
                    {
                        await crud.DeleteUsuarioAsync(usuario);
                        await DisplayAlert("Cuenta Eliminada", "Tu cuenta ha sido eliminada correctamente", "Aceptar");


                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido eliminar la cuenta. Usuario no encontrado.", "Aceptar");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al eliminar la cuenta: {ex.Message}", "Aceptar");
            }



        }

        private async void btnCambiarUser_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas cambiar tu nombre a "+txtNombreUsuario.Text+"?", "Confirmar", "Cancelar");

                var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                if (confirmacion)
                {
                    if (usuario != null)
                    {

                        usuario.usuario = txtNombreUsuario.Text;

                        await crud.UpdateUsuarioAsync(usuario);
                        await DisplayAlert("Actualización Exitosa", "Tu nombre se ha actualizado correctamente", "Aceptar");
                        LlenarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido eliminar la cuenta. Usuario no encontrado.", "Aceptar");
                    }
                }
            
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al actualizar la cuenta: {ex.Message}", "Aceptar");
            }


        }

        private async void btnCambiarPass_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas cambiar tu contraseña?", "Confirmar", "Cancelar");

                var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                if (confirmacion)
                {
                    if (usuario != null)
                    {

                        if (!ValidarCaracteresPassword(txtContra.Text))
                        {
                            await DisplayAlert("Advertencia", "La contraseña debe tener al menos 8 caracteres, incluir al menos una letra minúscula, una letra mayúscula, un número y un símbolo (@$!%*?&).", "Aceptar");
                            return;
                        }

                        usuario.password = txtContra.Text;

                        await crud.UpdateUsuarioAsync(usuario);
                        await DisplayAlert("Actualización Exitosa", "Tu contraseña se ha actualizado correctamente", "Aceptar");
                        LlenarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido eliminar la cuenta. Usuario no encontrado.", "Aceptar");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al actualizar la cuenta: {ex.Message}", "Aceptar");
            }
        }



        public async void LlenarDatos()
        {
            //Metodo que permite llenar los datos al realizar un update o select
            var usuarioEncontrado = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);
            //Si la lista no está vacia, entonces mostrarla
            if (usuarioEncontrado != null)
            {
                welcomeUserName.Text = usuarioEncontrado.usuario;
                txtNombreUsuario.Text = usuarioEncontrado.usuario;
                txtContra.Text = usuarioEncontrado.password;
            }
        }


        public bool ValidarCaracteresPassword(string password)
        {
            // Definir la RegulaciónDeExpresiones
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            return regex.IsMatch(txtContra.Text);
        }

        private void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}