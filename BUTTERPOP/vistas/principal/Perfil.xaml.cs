using BUTTERPOP.modelo;
using BUTTERPOP.vistas.tarjeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BUTTERPOP.crud.usuario;
using BUTTERPOP.crud.lista;
using BUTTERPOP.Modelo;
using static BUTTERPOP.utils.ImageResourceExtension;
using BUTTERPOP.Vistas.listas;
using static BUTTERPOP.db.Table;
using BUTTERPOP.db;
using System.IO;
using Xamarin.Essentials;



namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        private CRUD_Usuario crud = new CRUD_Usuario();
        private CRUD_Lista crud2 = new CRUD_Lista();

        private Table.Cliente cliente;

        public Perfil(Table.Cliente cliente)
        {
            InitializeComponent();
            DatosRecuperados(cliente);
            llenarDatosListas();

            this.cliente = cliente;

           

        }

        public Perfil()
        {
            InitializeComponent();
            LlenarDatos();
            llenarDatosListas();
            
        }

        public Perfil(string Nombre, string Descipcion, byte[] Imagen)
        {
            BindingContext = new ListaViewModel(Nombre, Descipcion, Imagen);
            var si = ImageHelper.ConvertByteArrayToImage(Imagen);
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

                        usuario.nombre = txtNombreUsuario.Text;

                        await crud.UpdateUsuarioAsync(usuario);
                        await DisplayAlert("Actualización Exitosa", "Tu nombre se ha actualizado correctamente", "Aceptar");
                        LlenarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido realizar los cambios en tu cuenta. Usuario no encontrado.", "Aceptar");
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


        public async void DatosRecuperados(Table.Cliente cliente)
        {
           

            lblCorreo.Text = cliente.correo;
            welcomeUserName.Text = cliente.nombre;
            txtNombreUsuario.Text = cliente.nombre;
            txtCorreoElec.Text = cliente.correo;
            txtApaternoUsuario.Text = cliente.apaterno;
            txtAmaternoUsuario.Text = cliente.amaterno;
            txtContra.Text = cliente.password;
        }


        public async void LlenarDatos()
        {
            //Metodo que permite llenar los datos al realizar un update o select
            var usuarioEncontrado = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);
            //Si la lista no está vacia, entonces mostrarla
            if (usuarioEncontrado != null)
            {
                welcomeUserName.Text = usuarioEncontrado.nombre;
                txtNombreUsuario.Text = usuarioEncontrado.nombre;
                txtContra.Text = usuarioEncontrado.password;
            }
        }
        


        public bool ValidarCaracteresPassword(string password)
        {
            // Definir la RegulaciónDeExpresiones
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            return regex.IsMatch(txtContra.Text);
        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas cerrar sesión?", "Confirmar", "Cancelar");

            if (confirmacion)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }

            
        }

        private async void btnCambiarApaterno_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas cambiar tu apellido paterno a " + txtApaternoUsuario.Text + "?", "Confirmar", "Cancelar");

                var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                if (confirmacion)
                {
                    if (usuario != null)
                    {

                        usuario.apaterno = txtApaternoUsuario.Text;

                        await crud.UpdateUsuarioAsync(usuario);
                        await DisplayAlert("Actualización Exitosa", "Tu apellido paterno se ha actualizado correctamente", "Aceptar");
                        LlenarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido realizar los cambios en tu cuenta. Usuario no encontrado.", "Aceptar");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al actualizar la cuenta: {ex.Message}", "Aceptar");
            }
        }

        private async void btnCambiarAmaterno_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Advertencia", "¿Estás seguro de que deseas cambiar tu apellido materno a " + txtAmaternoUsuario.Text + "?", "Confirmar", "Cancelar");

                var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                if (confirmacion)
                {
                    if (usuario != null)
                    {

                        usuario.amaterno = txtAmaternoUsuario.Text;

                        await crud.UpdateUsuarioAsync(usuario);
                        await DisplayAlert("Actualización Exitosa", "Tu apellido materno se ha actualizado correctamente", "Aceptar");
                        LlenarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se ha podido realizar los cambios en tu cuenta. Usuario no encontrado.", "Aceptar");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al actualizar la cuenta: {ex.Message}", "Aceptar");
            }
        }

        private async void btnAgregarMetodoPago_Clicked(object sender, EventArgs e)
        {
            var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);
            await Navigation.PushAsync(new vistas.tarjeta.BillingPage(usuario));
            

     


        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            frameEditar.IsVisible = false;
        }

        private async void confirmarEdicion_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(actId.Text))
            {
                Lista lista = new Lista()
                {
                    id_lista = Convert.ToInt32(actId.Text),
                    nombre = actNombre.Text,
                    descripcion = actDesc.Text,
                    imagen = ImageHelper.ConvertImageToByteArray(imgEditar.Source),

                };
                await crud2.SaveListaAsync(lista);
                frameEditar.IsVisible = false;
                await DisplayAlert("Actualización", "Lista actualizada", "OK");
                llenarDatosListas();

            }

        }

        private async void lstListas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Lista)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id_lista.ToString()))
            {

                var lista = await crud2.GetListaByIdAsync(obj.id_lista);
                if (lista != null)
                {
                    actId.Text = lista.id_lista.ToString();
                    actNombre.Text = lista.nombre;
                    actDesc.Text = lista.descripcion;
                    imgEditar.Source = ImageHelper.ConvertByteArrayToImage(lista.imagen);

                }


            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var lista = await crud2.GetListaByIdAsync(Convert.ToInt32(actId.Text));
            if (lista != null)
            {
                await crud2.DeleteListaAsync(lista);
                await DisplayAlert("Aviso", "Se elimino la lista", "OK");
                llenarDatosListas();
            }

        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ListaContiene());
            var lista = await crud2.GetListaByIdAsync(Convert.ToInt32(actId.Text));
            Navigation.PushAsync(new ListasContiene(lista.nombre, lista.descripcion, lista.imagen));

        }

        private void btnNueva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroListas(this.cliente));

        }
        public async void llenarDatosListas()
        {
            var listaList = await crud2.GetListasAsync();
            if (listaList != null)
            {
                lstListas.ItemsSource = listaList;
                lblListas.IsVisible = false;
            }
            else if(listaList==null)
            {
                lblListas.IsVisible = true;
                lstListas.IsVisible = false;
            }
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            frameEditar.IsVisible = true;
        }

        private async void btnImagen_Clicked(object sender, EventArgs e)
        {
            await SolicitarPermisos();

            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Selecciona una imagen"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);

                    imgEditar.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo cargar la imagen: " + ex.Message, "OK");
            }

        }

        private async Task SolicitarPermisos()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
            }
        }

    }
}