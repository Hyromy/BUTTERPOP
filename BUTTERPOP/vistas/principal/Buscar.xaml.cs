using BUTTERPOP.crud.pelicula;
using BUTTERPOP.db;
using BUTTERPOP.vistas.pelicula;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Buscar : ContentPage
    {
        private Table.Pelicula pelicula;
        private Table.Cliente cliente;

        private CRUD_Pelicula crud_pelicula = new CRUD_Pelicula();

        public Buscar(Table.Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }


        private async void searchPelicula_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Limpiar la cuadrícula antes de agregar nuevos elementos
            moviesGrid.Children.Clear();
            moviesGrid.RowDefinitions.Clear();
            moviesGrid.ColumnDefinitions.Clear();

            // Asegúrate de que hay texto para buscar
            if (string.IsNullOrEmpty(searchPelicula.Text))
                return;

            try
            {
                var peliculasList = await crud_pelicula.GetPeliculasByNombre(searchPelicula.Text);

                if (peliculasList != null && peliculasList.Any())
                {
                    // Definir columnas y filas de la cuadrícula
                    for (int i = 0; i < 3; i++)
                    {
                        moviesGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    }

                    int totalRows = (int)Math.Ceiling((double)peliculasList.Count / 3);
                    for (int i = 0; i < totalRows; i++)
                    {
                        moviesGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
                    }

                    int row = 0, column = 0;

                    foreach (var pelicula in peliculasList)
                    {
                        var imageButton = new ImageButton
                        {
                            Source = ImageSource.FromStream(() => new MemoryStream(pelicula.imagen)),
                            Aspect = Aspect.AspectFill,
                            HeightRequest = 150,
                            WidthRequest = 180,
                            BindingContext = pelicula
                        };

                        imageButton.Clicked += OnImageButtonClicked;

                        var label = new Label
                        {
                            Text = pelicula.titulo,
                            TextColor = Color.White,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 5, 0, 0)
                        };

                        var stack = new StackLayout
                        {
                            Padding = 0,
                            Margin = 0,
                            Children = { imageButton, label }
                        };

                        var frame = new Frame
                        {
                            HeightRequest = 200,
                            CornerRadius = 20,
                            Margin = new Thickness(2),
                            BackgroundColor = Color.Transparent,
                            Content = stack
                        };

                        moviesGrid.Children.Add(frame, column, row);

                        column++;
                        if (column > 2) // Limitar a 3 columnas
                        {
                            column = 0;
                            row++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes usar algún método de logging o mostrar un mensaje)
                await DisplayAlert("Error", "No se pudieron cargar las películas: " + ex.Message, "OK");
            }
        }

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            var imageButton = (ImageButton)sender;
            var pelicula = (Table.Pelicula)imageButton.BindingContext;

            // Lógica que deseas implementar al hacer clic en el ImageButton
            await Navigation.PushAsync(new InfoPelicula(this.cliente, pelicula));
        }










    }
}