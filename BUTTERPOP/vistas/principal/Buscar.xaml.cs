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
            moviesGrid.Children.Clear();
            moviesGrid.RowDefinitions.Clear();

            string searchText = searchPelicula.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
                return;

            try
            {
                var peliculasList = await crud_pelicula.GetPeliculasByNombre(searchText);

                if (peliculasList != null && peliculasList.Any())
                {
                    int totalRows = (int)Math.Ceiling((double)peliculasList.Count / 3);
                    for (int i = 0; i < totalRows; i++)
                    {
                        moviesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    }

                    int row = 0, column = 0;

                    foreach (var pelicula in peliculasList)
                    {
                        var imageButton = new ImageButton
                        {
                            Source = ImageSource.FromStream(() => new MemoryStream(pelicula.imagen)),
                            Aspect = Aspect.AspectFill,
                            HeightRequest = 166, // Mantén este tamaño según el diseño que prefieras
                            WidthRequest = 150,  // Ajusta este valor según el tamaño deseado
                            BindingContext = pelicula,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        };

                        imageButton.Clicked += OnImageButtonClicked;

                        var imageFrame = new Frame
                        {
                            Content = imageButton,
                            CornerRadius = 15,
                            HasShadow = false,
                            Padding = 0,
                            Margin = 0,
                            BackgroundColor = Color.Transparent,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        };

                        Label label = new Label
                        {
                            Text = pelicula.titulo,
                            TextColor = Color.White,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Start,
                            Margin = new Thickness(0, 5, 0, 0),
                            FontFamily = "Nunito_SemiBold",
                            FontSize = 12
                        };

                        var grid = new Grid
                        {
                            RowSpacing = 0,
                            ColumnSpacing = 0,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        };
                        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                        grid.Children.Add(imageFrame, 0, 0);
                        grid.Children.Add(label, 0, 1);

                        var frame = new Frame
                        {
                            HeightRequest = 240,  // Ajusta este valor si es necesario
                            WidthRequest = 150,  // Asegúrate de que este ancho sea consistente con el ancho de la columna
                            CornerRadius = 20,
                            Margin = new Thickness(2),
                            BackgroundColor = Color.Transparent,
                            Content = grid,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        };

                        moviesGrid.Children.Add(frame, column, row);

                        column++;
                        if (column > 1)
                        {
                            column = 0;
                            row++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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