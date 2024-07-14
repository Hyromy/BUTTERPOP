using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUTTERPOP.crud.lista;
using BUTTERPOP.crud.usuario;
using BUTTERPOP.Modelo;
using BUTTERPOP.vistas;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BUTTERPOP.db.Table;
using static BUTTERPOP.utils.ImageResourceExtension;
using static BUTTERPOP.modelo.PerfilViewModel;
using BUTTERPOP.modelo;

namespace BUTTERPOP.Vistas.listas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroListas : ContentPage
    {
        private CRUD_Lista crud = new CRUD_Lista();
        private CRUD_Usuario crud2 = new CRUD_Usuario();
        public RegistroListas()
        {
            InitializeComponent();
            llenarDatosListas();
            LlenarDatos();
        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                byte[] imagebytes = ImageHelper.ConvertImageToByteArray(ImagenLista.Source);
                Lista lista = new Lista
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDesc.Text,
                    imagen = imagebytes,
                    
                };
                await crud.SaveListaAsync(lista);
                txtNombre.Text = "";
                txtDesc.Text = "";
                ImagenLista.Source = "";
                await DisplayAlert("Registro", "Lista guardada en tu interfaz", "OK");
                await Navigation.PushAsync(new Perfil());
                
            }
            else
            {
                string mensajeError = "Por favor, ingresa los siguientes datos:\n";
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    mensajeError += "- Nombre\n";
                }
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    mensajeError += "- Descripción\n";
                }
                if (ImagenLista.Source.IsEmpty)
                {
                    mensajeError += "- Imagen\n";
                }
                await DisplayAlert("Error", mensajeError, "OK");
            }
        }

        public bool validarDatos()
        {

            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDesc.Text))
            {
                respuesta = false;
            }
            else if (ImagenLista.Source.IsEmpty)
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
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

                    ImagenLista.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
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
        public async void llenarDatosListas()
        {
            var listaList = await crud.GetListasAsync();
        }
        public async void LlenarDatos()
        {
            //Metodo que permite llenar los datos al realizar un update o select
            var usuarioEncontrado = await crud2.GetUsuariosAsync();
        }
    }

}
