using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private Table.Cliente cliente;

        public Home(/*Table.Cliente cliente*/)
        {
            InitializeComponent();

            //this.cliente = cliente;

            // Crear un evento tipo click para el frame
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Rent();
            };

            // Asignar el evento al frame
            film1.GestureRecognizers.Add(tapGestureRecognizer);
            film2.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void Rent()
        {
            // extraer la informacion de cliente activo
            Table.Cliente cliente = new Table.Cliente
            {
                correo = "ejemplo@ejemplo.com",
                nombre = "Ejemplo",
                password = "12345$Hf"
            };

            // extraer la informacion de la pelicula seleccionada
            Table.Pelicula pelicula = new Table.Pelicula
            {
                id_pelicula = 1
            };

            Navigation.PushAsync(new vistas.pelicula.InfoPelicula(cliente, pelicula));
        }
    }
}