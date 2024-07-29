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

             LoadComments();
        }

        private async void LoadComments()
        {
            commentsSection.Children.Clear();

            var header = new Label
            {
                Text = "Comentarios",
                FontFamily = "Nunito_ExtraBold",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            commentsSection.Children.Add(header);

            List<Table.Comenta> comentarios = await crudCOMENTA.GetCommentsByMovieIdAsync(pelicula.id_pelicula);

            foreach (var comentario in comentarios)
            {
                var clienteComentario = await crudCliente.GetUsuariosByCorreo(comentario.correo);

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
                    Text = clienteComentario != null ? clienteComentario.nombre : "Desconocido",
                    TextColor = Color.White,
                    FontFamily = "Nunito_Bold",
                    FontSize = 16,
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
                    FontFamily = "Nunito_Regular",
                    TextColor = Color.Gold,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Center
                };

                gridLayout.Children.Add(labelUsuario, 0, 0);
                gridLayout.Children.Add(labelPuntuacion, 1, 0);
                gridLayout.Children.Add(labelTexto, 0, 1);
                Grid.SetColumnSpan(labelTexto, 2);

                if (comentario.correo == cliente.correo)
                {
                    var btnEditar = new Button
                    {
                        Text = "Editar",
                        TextColor = Color.White,
                        BackgroundColor = Color.Transparent,
                        HorizontalOptions = LayoutOptions.End,
                        CommandParameter = comentario
                    };
                    btnEditar.Clicked += btnEditarComentario_Clicked;

                    var btnEliminar = new Button
                    {
                        Text = "Eliminar",
                        TextColor = Color.White,
                        BackgroundColor = Color.Transparent,
                        HorizontalOptions = LayoutOptions.End,
                        CommandParameter = comentario
                    };
                    btnEliminar.Clicked += btnEliminarComentario_Clicked;

                    var buttonStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Children = { btnEditar, btnEliminar }
                    };

                    gridLayout.Children.Add(buttonStack, 0, 2);
                    Grid.SetColumnSpan(buttonStack, 2);
                }

                commentsSection.Children.Add(gridLayout);
            }
        }

        private async void btnEditarComentario_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var comentario = button?.CommandParameter as Table.Comenta;
            if (comentario == null) return;

            // Crear un StackLayout para las estrellas
            var starLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };

            // Inicializar puntuación actual
            int currentRating = comentario.Puntuacion;

            // Crear estrellas
            for (int i = 1; i <= 3; i++)
            {
                var star = new Image
                {
                    Source = i <= currentRating ? "star_fill.png" : "star_empty.png",
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Margin = new Thickness(5)
                };

                int rating = i; // Capture the loop variable
                star.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        currentRating = rating;
                        // Actualizar las estrellas visualmente
                        for (int j = 0; j < starLayout.Children.Count; j++)
                        {
                            var s = starLayout.Children[j] as Image;
                            s.Source = j < currentRating ? "star_fill.png" : "star_empty.png";
                        }
                    })
                });

                starLayout.Children.Add(star);
            }

            // Crear una entrada para el comentario
            var comentarioEntry = new Entry
            {
                Text = comentario.Comentario,
                TextColor = Color.White,
                Placeholder = "Modifica tu comentario",
                Margin = new Thickness(10)
            };

            // Mostrar un botón de confirmación
            var confirmButton = new Button
            {
                Text = "Guardar",
                CornerRadius = 20,
                BackgroundColor = Color.FromHex("#c80000"),
                TextColor = Color.White,
                Margin = new Thickness(10)
            };

            confirmButton.Clicked += async (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(comentarioEntry.Text))
                {
                    await DisplayAlert("Error", "El comentario no puede estar vacío.", "OK");
                    return;
                }

                comentario.Comentario = comentarioEntry.Text;
                comentario.Puntuacion = currentRating;

                await crudCOMENTA.UpdateComentarioAsync(comentario);
                LoadComments(); // Recargar comentarios

                await DisplayAlert("Éxito", "Comentario actualizado con éxito.", "OK");
            };

            // Crear el diseño principal
            var layout = new StackLayout
            {
                Children = { comentarioEntry, starLayout, confirmButton },
                BackgroundColor = Color.FromHex("#1c1c1c"),
                Padding = new Thickness(10)
            };

            // Mostrar la página de edición
            await Navigation.PushAsync(new ContentPage
            {
                Title = "Editar Comentario",
                Content = layout
            });
        }

        private async void btnEliminarComentario_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var comentario = button?.CommandParameter as Table.Comenta;
            if (comentario == null) return;

            bool confirm = await DisplayAlert("Eliminar comentario", "¿Estás seguro de que deseas eliminar este comentario?", "Sí", "No");
            if (!confirm) return;

            await crudCOMENTA.DeleteComentarioByIDAsync(comentario.id_comentario);
            LoadComments();
        }
    }
}


    

