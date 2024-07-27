using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using BUTTERPOP.crud.pelicula;
using System.IO;
using BUTTERPOP.vistas.pelicula;

using System.Collections.ObjectModel;


namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();



        private Table.Cliente cliente;
        private Table.Pelicula pelicula;

        private CRUD_Pelicula crud_pelicula = new CRUD_Pelicula();

        public Home(Table.Cliente cliente)
        {
            InitializeComponent();
            CargarPeliculas();

            this.cliente = cliente;

            /*imageSources.Add("shrek_portada.jpg");
            imageSources.Add("pelicula_poster.png");
            imageSources.Add("shrek_portada.jpg");
            imageSources.Add("shrek_portada.jpg");
            imageSources.Add("shrek_portada.jpg");

            imgSlider.Images = imageSources;*/

            /*
            // Crear un evento tipo click para el frame
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Rent();
            };

            // Asignar el evento al frame
            film1.GestureRecognizers.Add(tapGestureRecognizer);
            //film2.GestureRecognizers.Add(tapGestureRecognizer);
            */
        }

        /*
        private void Rent()
        {
            // extraer la informacion de la pelicula seleccionada
            this.pelicula = new Table.Pelicula
            {
                id_pelicula = 1
            };

            Navigation.PushAsync(new vistas.pelicula.InfoPelicula(this.cliente, this.pelicula));
        }
        */

        private async void CargarPeliculas()
        {
            List<Table.Pelicula> peliculasList = await crud_pelicula.GetPeliculasAsync();

            if (peliculasList != null)
            {
                int row = 0, column = 0;

                foreach (var pelicula in peliculasList)
                {
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

                    // Crear el Frame para contener la imagen
                    var imageFrame = new Frame
                    {
                        Content = imageButton,
                        CornerRadius = 12, // Ajusta el valor del radio de las esquinas
                        HasShadow = false, // Opcional: elimina la sombra si no la quieres
                        Padding = 0,
                        Margin = 0,
                        BackgroundColor = Color.Transparent // Asegúrate de que el color de fondo sea transparente si deseas solo el borde redondeado
                    };

                    // Crear la etiqueta para el título
                    Label label = new Label
                    {
                        Text = pelicula.titulo,
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 5, 0, 0),
                        FontFamily = "Nunito_SemiBold",
                        FontSize = 12,
                    };

                    // Crear el StackLayout para el contenido
                    StackLayout stack = new StackLayout
                    {
                        Padding = 0,
                        Margin = 0,
                        Children = { imageFrame, label }
                    };

                    // Crear el Frame que contendrá el StackLayout
                    var frame = new Frame
                    {
                        HeightRequest = 200,
                        CornerRadius = 20,
                        Margin = new Thickness(2),
                        BackgroundColor = Color.Transparent,
                        Content = stack
                    };

                    // Agregar el Frame a la cuadrícula
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

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            var imageButton = (ImageButton)sender;
            var pelicula = (Table.Pelicula)imageButton.BindingContext;

            // Lógica que deseas implementar al hacer clic en el ImageButton
            //DisplayAlert("Película seleccionada", $"Título: {pelicula.titulo}", "OK");
            await Navigation.PushAsync(new InfoPelicula(this.cliente, pelicula));
        }
    }
}