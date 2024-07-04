using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

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
            Navigation.PushAsync(new vistas.pelicula.InfoPelicula());
        }
    }
}