using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;
using BUTTERPOP.modelo;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private bool IsTurnX;
        private bool IsTurnY;
        private double valueX;
        private double valueY;
        private bool selection1Active;
        private bool selection2Active;

        public LoginPage()
        {
            InitializeComponent();

            IsTurnX = false;
            IsTurnY = false;
            valueX = 0;
            valueY = 0;
            selection1Active = true;
            selection2Active = false;


            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            if (selection1Active)
            {
                txt1.TextColor = Color.White;
                txt2.TextColor = Color.Black;
                runningFrame.TranslateTo(runningFrame.X, 0, 120);
                loginForm.IsVisible = true;
                registerForm.IsVisible = false;

            }
            else if (selection2Active)
            {
                txt1.TextColor = Color.Black;
                txt2.TextColor = Color.White;
                runningFrame.TranslateTo(runningFrame.X + 86, 0, 120);
                loginForm.IsVisible = false;
                registerForm.IsVisible = true;
            }
        }

        public void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var x = e.TotalX;
            var y = e.TotalY;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Debug.WriteLine("Started");
                    break;
                case GestureStatus.Running:
                    Debug.WriteLine("Running");

                    if ((x >= 5 || x <= -5) && !IsTurnX && !IsTurnY)
                    {
                        IsTurnX = true;
                    }

                    if ((y >= 5 || y <= -5) && !IsTurnY && !IsTurnX)
                    {
                        IsTurnY = true;
                    }


                    if (IsTurnX && !IsTurnY)
                    {
                        if (x <= valueX)
                        {

                            if (selection2Active)
                            {
                                selection1Active = true;
                                selection2Active = false;
                                UpdateButtonColors();
                            }
                        }

                        if (x >= valueX)
                        {

                            if (selection1Active)
                            {
                                selection1Active = false;
                                selection2Active = true;
                                UpdateButtonColors();
                            }
                        }




                    }
                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Completed");

                    valueX = x;
                    valueY = y;

                    IsTurnX = false;
                    IsTurnY = false;
                    break;
                case GestureStatus.Canceled:
                    Debug.WriteLine("Canceled");
                    break;
            }
        }

        private void OnText1Tapped(object sender, EventArgs e)
        {
            if (!selection1Active)
            {
                selection1Active = true;
                selection2Active = false;
                UpdateButtonColors();
            }
        }

        private void OnText2Tapped(object sender, EventArgs e)
        {
            if (!selection2Active)
            {
                selection1Active = false;
                selection2Active = true;
                UpdateButtonColors();
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatosRegistro())
            {

                if (validarPassword())
                {
                    Usuarios usuario = new Usuarios

                    {
                        correo = txtEmailR.Text,
                        usuario = txtUsername.Text,
                        password = txtPassR.Text,

                    };
                    await App.SQLiteDB.SaveUsuarioAsync(usuario);
                    txtEmailR.Text = "";
                    txtPassR.Text = "";
                    txtUsername.Text = "";
                    txtPassRCheck.Text = "";

                    await DisplayAlert("Registro Exitoso", "Te has registrado correctamente, por favor inicia sesión", "Aceptar");

                } else
                {
                    await DisplayAlert("Advertencia", "Las contraseñas no coinciden", "Aceptar");
                }

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos", "Aceptar");
            }
        }


        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (validarDatosInicioSesion())
            {

             

                

                var usuario = await App.SQLiteDB.GetUsuariosByCorreo(txtEmailI.Text);


                    if(usuario != null)
                    {
                        if (usuario.password == txtPassI.Text)
                        {
                            await DisplayAlert("Inicio de Sesión Exitoso", "Has iniciado sesión correctamente", "Aceptar");

                        Application.Current.MainPage = new NavigationPage(new HomePage(usuario.usuario, usuario.correo, usuario.password));
                       
                    }
                        else
                        {
                            await DisplayAlert("Error", "La contraseña es incorrecta", "Aceptar");
                        }

                    } else
                    {
                        await DisplayAlert("Error", "No se encontró un usuario con ese correo", "Aceptar");
                    }

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos para continuar", "Aceptar");
            }
        }

        public bool validarDatosRegistro()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtEmailR.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPassR.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtUsername.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPassRCheck.Text))
            {
                respuesta = false;
            } else
            {
                respuesta = true;
            }
            return respuesta;
        }

        public bool validarPassword()
        {
            bool respuesta;

            if(txtPassR.Text == txtPassRCheck.Text)
            {
                respuesta=true;
            } else
            {
                respuesta = false;
            }
            return respuesta;

        }


        public bool validarDatosInicioSesion()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtEmailI.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPassI.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private void btnVerPassword_Clicked(object sender, EventArgs e)
        {
            btnVerPassword.IsVisible = false;
            btnOcultarPassword.IsVisible = true;
            txtPassI.IsPassword = false;
        }

        private void btnOcultarPassword_Clicked(object sender, EventArgs e)
        {
            btnVerPassword.IsVisible = true;
            btnOcultarPassword.IsVisible = false;
            txtPassI.IsPassword = true;
        }

        private void btnVerPassword2_Clicked(object sender, EventArgs e)
        {
            btnVerPassword2.IsVisible = false;
            btnOcultarPassword2.IsVisible = true;
            txtPassR.IsPassword = false;
        }

        private void btnOcultarPassword2_Clicked(object sender, EventArgs e)
        {
            btnVerPassword2.IsVisible = true;
            btnOcultarPassword2.IsVisible = false;
            txtPassR.IsPassword = true;
        }

        private void btnVerPassword3_Clicked(object sender, EventArgs e)
        {
            btnVerPassword3.IsVisible = false;
            btnOcultarPassword3.IsVisible = true;
            txtPassRCheck.IsPassword = false;
        }

        private void btnOcultarPassword3_Clicked(object sender, EventArgs e)
        {
            btnVerPassword3.IsVisible = true;
            btnOcultarPassword3.IsVisible = false;
            txtPassRCheck.IsPassword = true;
        }
    }
}