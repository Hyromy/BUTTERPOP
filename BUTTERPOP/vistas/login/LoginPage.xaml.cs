using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using BUTTERPOP.modelo;
using Xamarin.Essentials;
using BUTTERPOP.vistas.tarjeta;

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
                                var duration = TimeSpan.FromSeconds(0.2);
                                Vibration.Vibrate(duration);
                            }
                        }

                        if (x >= valueX)
                        {

                            if (selection1Active)
                            {
                                selection1Active = false;
                                selection2Active = true;
                                UpdateButtonColors();
                                var duration = TimeSpan.FromSeconds(0.2);
                                Vibration.Vibrate(duration);
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
                var duration = TimeSpan.FromSeconds(0.2);
                Vibration.Vibrate(duration);
            }
        }

        private void OnText2Tapped(object sender, EventArgs e)
        {
            if (!selection2Active)
            {
                selection1Active = false;
                selection2Active = true;
                UpdateButtonColors();
                var duration = TimeSpan.FromSeconds(0.2);
                Vibration.Vibrate(duration);
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatosRegistro())
            {

                var usuarioExistente = await App.SQLiteDB.GetUsuariosByCorreo(txtEmailR.Text);

                if (usuarioExistente != null && usuarioExistente.correo == txtEmailR.Text)
                {
                    await DisplayAlert("Advertencia", "El correo electrónico ya ha sido registrado. Porfavor, intenta con otro.", "Aceptar");
                    return;
                }

                if (!ValidarCaracteresPassword(txtPassR.Text))
                {
                    await DisplayAlert("Advertencia", "La contraseña debe tener al menos 8 caracteres, incluir al menos una letra minúscula, una letra mayúscula, un número y un símbolo (@$!%*?&).", "Aceptar");
                    return;
                }


                if (!IsValidEmailR())
                {
                    await DisplayAlert("Advertencia", "Por favor ingresa un correo electrónico válido.", "Aceptar");
                    return;
                }

               
                    Usuarios usuario = new Usuarios

                    {
                        correo = txtEmailR.Text,
                        nombre = txtNombre.Text,
                        apaterno = txtApaterno.Text,
                        amaterno = txtAmaterno.Text,
                        password = txtPassR.Text,

                    };

                    await App.SQLiteDB.SaveUsuarioAsync(usuario);
                    txtEmailR.Text = "";
                    txtPassR.Text = "";
                    txtNombre.Text = "";
                    txtApaterno.Text = "";
                    txtAmaterno.Text = "";
                    

                    await DisplayAlert("Registro Exitoso", "Te has registrado correctamente, por favor inicia sesión", "Aceptar");


                    selection1Active = true;
                    selection2Active = false;
                    UpdateButtonColors();
                    var duration = TimeSpan.FromSeconds(0.2);
                    Vibration.Vibrate(duration);

               

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
                if (!IsValidEmail())
                {
                    await DisplayAlert("Advertencia", "Por favor ingresa un correo electrónico válido.", "Aceptar");
                    return;
                }

                var usuario = await App.SQLiteDB.GetUsuariosByCorreo(txtEmailI.Text);


                    if(usuario != null)
                    {
                        if (usuario.password == txtPassI.Text)
                        {
                            // Paso de parametros recibidos al constructor de HomePage
                            Application.Current.MainPage = new NavigationPage(new HomePage(usuario.nombre, usuario.apaterno, usuario.amaterno, usuario.correo, usuario.password));

                            var bilingpage = new BillingPage(usuario.nombre, usuario.apaterno, usuario.amaterno, usuario.correo, usuario.password);
                            
                        var duration = TimeSpan.FromSeconds(0.2);
                            Vibration.Vibrate(duration);

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
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApaterno.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtAmaterno.Text))
            {
                respuesta = false;

            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        /*public bool validarPassword()
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

        }*/

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

        /*private void btnVerPassword3_Clicked(object sender, EventArgs e)
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
        }*/

        public bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmailI.Text))
                return false;

            try
            {
                
                var addr = new System.Net.Mail.MailAddress(txtEmailI.Text);

                
                return addr.Address == txtEmailI.Text;
            }
            catch
            {
                
                return false;
            }
        }

        public bool IsValidEmailR()
        {
            if (string.IsNullOrWhiteSpace(txtEmailR.Text))
                return false;

            try
            {
                
                var addr = new System.Net.Mail.MailAddress(txtEmailR.Text);

                
                return addr.Address == txtEmailR.Text;
            }
            catch
            {
                
                return false;
            }
        }


        public bool ValidarCaracteresPassword(string password)
        {
            
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            return regex.IsMatch(txtPassR.Text);
        }








    }
}