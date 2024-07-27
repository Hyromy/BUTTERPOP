using BUTTERPOP.crud.comentario;
using BUTTERPOP.crud.contiene;
using BUTTERPOP.crud.lista;
using BUTTERPOP.crud.usuario;
using BUTTERPOP.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BUTTERPOP.utils.ImageResourceExtension;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPeliculaRentada : ContentPage
    {
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
        private CRUD_Lista crudLista = new CRUD_Lista();
        private CRUD_Contiene crudContiene = new CRUD_Contiene();
        private CRUD_Comentario crudCOMENTA = new CRUD_Comentario();
        private CRUD_Usuario crudCliente = new CRUD_Usuario();
        private int selectedRating = 0;

        public InfoPeliculaRentada(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();
            
            this.cliente = cliente;
            this.pelicula = pelicula;
       
            LoadComments();
            addNavBack();
            LlenarPickerAsync();

            btn_rent.Clicked += ToRent;
            film_poster.Source = ImageHelper.ConvertByteArrayToImage(pelicula.imagen);
            BindingContext = pelicula;

            foreach (var star in ratingStars.Children.OfType<Image>())
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    var tappedStar = s as Image;
                    var starIndex = ratingStars.Children.IndexOf(tappedStar) + 1;
                    SetStarRating(starIndex);
                };
                star.GestureRecognizers.Add(tapGestureRecognizer);
            }

            
        }


        private void addNavBack()
        {
            TapGestureRecognizer navBack = new TapGestureRecognizer();
            navBack.Tapped += (s, e) =>
            {
                Navigation.PopAsync();
            };

            nav_back.GestureRecognizers.Add(navBack);
        }

        public async Task LlenarPickerAsync()
        {
            var nombresListas = await crudLista.GetNombresListasPorCorreoAsync(cliente.correo);
            pickerLista.ItemsSource = nombresListas;
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreListaSeleccionada = pickerLista.SelectedItem.ToString();
            int idLista = await crudContiene.GetIdListaByNombreAsync(nombreListaSeleccionada);

            Table.Contiene contiene = new Table.Contiene
            {
                id_lista = idLista,
                id_pelicula = pelicula.id_pelicula,
            };

            await crudContiene.SaveContieneAsync(contiene);
            await DisplayAlert("Registro", "Lista guardada en tu interfaz", "OK");
        }

        private void ToRent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.renta.FormRenta(cliente, pelicula));
        }






        private void SetStarRating(int rating)
        {
            // Si la calificación actual es igual a la calificación seleccionada, deselecciona todas las estrellas
            if (selectedRating == rating)
            {
                selectedRating = 0;
                foreach (var star in ratingStars.Children.OfType<Image>())
                {
                    star.Source = "star_empty.png";
                }
            }
            else
            {
                selectedRating = rating;
                for (int i = 0; i < ratingStars.Children.Count; i++)
                {
                    var star = ratingStars.Children[i] as Image;
                    if (i < rating)
                    {
                        star.Source = "star_fill.png";
                    }
                    else
                    {
                        star.Source = "star_empty.png";
                    }
                }
            }
        }

        private async void btnEnviarComentario_Clicked(object sender, EventArgs e)
        {
            if (selectedRating == 0)
            {
                await DisplayAlert("Error", "Por favor, selecciona una calificación.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(commentEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, ingresa un comentario.", "OK");
                return;
            }

            Table.Comenta nuevoComentario = new Table.Comenta
            {
                correo = cliente.correo,
                id_pelicula = pelicula.id_pelicula,
                Comentario = commentEntry.Text,
                Puntuacion = selectedRating
            };

            await crudCOMENTA.InsertComentario(nuevoComentario);
            await DisplayAlert("Comentario enviado", "Gracias por tu comentario.", "OK");

            commentEntry.Text = string.Empty;
            SetStarRating(0);
        }

        private async void LoadComments()
        {
            // Limpiar la sección de comentarios
            commentsSection.Children.Clear();

            // Crear el encabezado
            var header = new Label
            {
                Text = "Comentarios",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Añadir el encabezado a la sección de comentarios
            commentsSection.Children.Add(header);

            // Obtener los comentarios
            List<Table.Comenta> comentarios = await crudCOMENTA.GetCommentsByMovieIdAsync(pelicula.id_pelicula);

            foreach (var comentario in comentarios)
            {
                var cliente = await crudCliente.GetUsuariosByCorreo(comentario.correo);

                var gridLayout = new Grid
                {
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 0, 0, 10),
                    BackgroundColor = Color.FromHex("#3a3a3a"),
                    ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            }
                };

                var labelUsuario = new Label
                {
                    Text = cliente != null ? cliente.nombre : "Desconocido",
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center
                };

                var labelTexto = new Label
                {
                    Text = comentario.Comentario,
                    TextColor = Color.White
                };

                var labelPuntuacion = new Label
                {
                    Text = new string('★', comentario.Puntuacion),
                    TextColor = Color.Gold,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Center
                };

                gridLayout.Children.Add(labelUsuario, 0, 0);
                gridLayout.Children.Add(labelPuntuacion, 1, 0);
                gridLayout.Children.Add(labelTexto, 0, 1);
                Grid.SetColumnSpan(labelTexto, 2);

                commentsSection.Children.Add(gridLayout);
            }
        }

    }
}
