using BUTTERPOP.crud.pelicula;
using BUTTERPOP.crud.usuario;
using BUTTERPOP.db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using static BUTTERPOP.utils.ImageResourceExtension;
using static BUTTERPOP.db.Table;

namespace BUTTERPOP.vistas.admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GestionPeliculas : ContentPage
    {
        private CRUD_Pelicula crud_pelicula = new CRUD_Pelicula();

        public GestionPeliculas()
        {
            InitializeComponent();
        }

        private async void btnGuardarPelicula_Clicked(object sender, EventArgs e)
        {
            if (validarDatosPelicula())
            {
                byte[] imagebytesPelicula = ImageHelper.ConvertImageToByteArray(imgPelicula.Source);
                Table.Pelicula pelicula = new Table.Pelicula

                {
                    imagen = imagebytesPelicula,
                    titulo = txtTitulo.Text,
                    descripcion = txtDescripcion.Text,
                    genero = generoPicker.SelectedItem.ToString(),
                    clasificacion = clasificacionPicker.SelectedItem.ToString(),
                    duracion = int.Parse(txtDuracion.Text),
                    precio = decimal.Parse(txtPrecio.Text),

                };

                await crud_pelicula.SavePeliculaAsync(pelicula);

                imgPelicula.Source = null;
                generoPicker.SelectedItem = null;
                clasificacionPicker.SelectedItem = null;
                txtTitulo.Text = "";
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                txtDuracion.Text = "";


                await DisplayAlert("Registro Exitoso", "La nueva película se ha registrado correctamente", "Aceptar");

                /*
                 * 
                 * Por favor, terminar el mostrar listas, y que se vean acomodadas, sobre todo en esta parte del admin
                 * 
                 * 
                /*List<Table.Pelicula> peliculasList = await crud_pelicula.GetPeliculasAsync();


                if (peliculasList != null)
                {
                    lsPeliculas.ItemsSource = peliculasList;
                    
                }*/
               


            } else
            {
                await DisplayAlert("Registro Fallido", "No se pudo registrar la nueva película", "Aceptar");
            }
        }

        private async void btnSeleccionarImagen_Clicked(object sender, EventArgs e)
        {
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

                    imgPelicula.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo cargar la imagen: " + ex.Message, "OK");
            }

        }

        public bool validarDatosPelicula()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDuracion.Text))
            {
                respuesta = false;
            }
            else if (imgPelicula.Source == null)
            {
                respuesta = false;
            }
            else if (generoPicker.SelectedItem ==  null)
            {
                respuesta = false;

            }
            else if (clasificacionPicker.SelectedItem == null) 
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private void btnVerPeliculas_Clicked(object sender, EventArgs e)
        {

        }
    }
}