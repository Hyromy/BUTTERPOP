﻿using BUTTERPOP.modelo;
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
using BUTTERPOP.crud.renta;
using BUTTERPOP.crud.pelicula;
using BUTTERPOP.vistas.pelicula;



namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        private CRUD_Usuario crud = new CRUD_Usuario();
        private CRUD_Lista crud2 = new CRUD_Lista();
        private CRUD_Renta crud_renta = new CRUD_Renta();
        private CRUD_Pelicula crud_pelicula = new CRUD_Pelicula();

        private Table.Cliente cliente;
        
        public Perfil(Table.Cliente cliente)
        {
            InitializeComponent();
            DatosRecuperados(cliente);

            this.cliente = cliente;

            btnPeliculas_Clicked(null, null);
            
        }

        /*
        public Perfil(int Id_lista, string Nombre, string Descipcion, byte[] Imagen)
        {
            BindingContext = new ListaViewModel(Id_lista, Nombre, Descipcion, Imagen);
            var si = ImageHelper.ConvertByteArrayToImage(Imagen);
        }
        */

        private async void btnPeliculas_Clicked(object sender, EventArgs e)
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
            // Obtener todas las rentas para el cliente actual
            List<Table.Renta> rentasList = await crud_renta.GetRentasByCorreo(cliente.correo);

            if (rentasList == null || !rentasList.Any())
            {
                // Mostrar mensaje cuando no haya rentas
                lblPeliculas.IsVisible = true;
                moviesGrid.IsVisible = false;
            }
            else
            {
                // Ocultar mensaje y mostrar las películas rentadas
                lblPeliculas.IsVisible = false;
                moviesGrid.IsVisible = true;

                List<Table.Pelicula> peliculasList = new List<Table.Pelicula>();
                foreach (var renta in rentasList)
                {
                    if (renta.fin_fecha_renta > DateTime.Now)
                    {
                        var pelicula = await crud_pelicula.GetPeliculasByIdAsync(renta.id_pelicula);
                        if (pelicula != null)
                        {
                            peliculasList.Add(pelicula);
                        }
                    }
                }

                // Limpiar la cuadrícula antes de agregar nuevos elementos
                moviesGrid.Children.Clear();
                moviesGrid.RowDefinitions.Clear();
                moviesGrid.ColumnDefinitions.Clear();

                // Crear una fila por cada renta
                foreach (var renta in rentasList.Where(r => r.fin_fecha_renta >= DateTime.Now))
                {
                    // Obtener la película asociada con la renta
                    var pelicula = await crud_pelicula.GetPeliculasByIdAsync(renta.id_pelicula);
                    if (pelicula != null)
                    {
                        // Agregar una fila a la cuadrícula
                        moviesGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) }); // Altura fija

                        // Crear el ImageButton
                        var imageButton = new ImageButton
                        {
                            Source = ImageSource.FromStream(() => new MemoryStream(pelicula.imagen)),
                            Aspect = Aspect.AspectFill,
                            HeightRequest = 166,
                            WidthRequest = 112,
                            BindingContext = pelicula
                        };

                         imageButton.Clicked += OnImageButtonClicked;

                        Label titleLabel = new Label
                        {
                            Text = pelicula.titulo ?? "Título no disponible",
                            TextColor = Color.White,
                            FontFamily = "Nunito_ExtraBold",
                            FontSize = 14,
                            Margin = new Thickness(0, 5, 0, 0)
                        };

                        // Crear la etiqueta para las semanas de renta
                        Label weeksLabel = new Label
                        {
                            Text = $"Semanas de renta: {renta.semanas_renta}",
                            TextColor = Color.White,
                            FontFamily = "Nunito_SemiBold",
                            FontSize = 12
                        };

                        // Crear la etiqueta para el cobro de renta
                        Label rentalChargeLabel = new Label
                        {
                            Text = $"Cobro renta: ${renta.cobro_renta:F2}",
                            TextColor = Color.White,
                            FontFamily = "Nunito_SemiBold",
                            FontSize = 12
                        };

                        // Crear la etiqueta para la fecha y hora de renta
                        Label rentalDateTimeLabel = new Label
                        {
                            Text = $"Inicio de la renta: {renta.fecha_renta.ToString("dd/MM/yyyy HH:mm")}",
                            TextColor = Color.White,
                            FontFamily = "Nunito_SemiBold",
                            FontSize = 12
                        };

                        // Crear la etiqueta para la fecha y hora de fin de renta
                        Label endRentalDateTimeLabel = new Label
                        {
                            Text = $"Termino de la renta: {renta.fin_fecha_renta.ToString("dd/MM/yyyy HH:mm")}",
                            TextColor = Color.White,
                            FontFamily = "Nunito_SemiBold",
                            FontSize = 12
                        };

                        // Crear un StackLayout para los detalles a la derecha de la imagen
                        StackLayout detailsStack = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Margin = new Thickness(10, 0),
                            Children = { titleLabel, weeksLabel, rentalChargeLabel, rentalDateTimeLabel, endRentalDateTimeLabel }
                        };

                        // Crear el Grid para contener la imagen y los detalles
                        Grid itemGrid = new Grid
                        {
                            ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(130) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    },
                            RowDefinitions = { new RowDefinition { Height = GridLength.Auto } }
                        };

                        // Agregar la imagen y los detalles a la cuadrícula
                        itemGrid.Children.Add(imageButton, 0, 0);
                        itemGrid.Children.Add(detailsStack, 1, 0);

                        // Agregar el Grid a la cuadrícula principal
                        moviesGrid.Children.Add(itemGrid, 0, rentasList.IndexOf(renta));
                    }
                }
            }
        }

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            var imageButton = (ImageButton)sender;
            var pelicula = (Table.Pelicula)imageButton.BindingContext;

            // Lógica que deseas implementar al hacer clic en el ImageButton
            //DisplayAlert("Película seleccionada", $"Título: {pelicula.titulo}", "OK");
            await Navigation.PushAsync(new InfoPeliculaRentada(this.cliente, pelicula));
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

            llenarDatosListas();

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
            if (!string.IsNullOrEmpty(actId.Text) &&
        !string.IsNullOrEmpty(actNombre.Text) &&
        !string.IsNullOrEmpty(actDesc.Text))
            {
                Lista lista = new Lista()
                {
                    id_lista = Convert.ToInt32(actId.Text),
                    nombre = actNombre.Text,
                    descripcion = actDesc.Text,
                    imagen = ImageHelper.ConvertImageToByteArray(imgEditar.Source),
                    correo = cliente.correo
                };

                await crud2.SaveListaAsync(lista);
                frameEditar.IsVisible = false;
                await DisplayAlert("Actualización", "Lista actualizada", "OK");
                llenarDatosListas();
            }
            else
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
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
                var result = await DisplayAlert("Confirmación", "¿Estás segur@ la lista?", "Sí", "No");
                if (result)
                {
                    await crud2.DeleteListaAsync(lista);
                    await DisplayAlert("Aviso", "Se elimino la lista", "OK");
                    llenarDatosListas();
                }
                else
                {
                    // El usuario hizo clic en "No"
                }
            }

        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ListaContiene());
            var lista = await crud2.GetListaByIdAsync(Convert.ToInt32(actId.Text));
            await Navigation.PushAsync(new ListasContiene(lista.id_lista, lista.nombre, lista.descripcion, lista.imagen, this.cliente));
        }

        private void btnNueva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroListas(this.cliente));

        }
        public async void llenarDatosListas()
        {
            List<Table.Lista> listaList = await crud2.GetListasByCorreoAsync(cliente.correo);
            

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