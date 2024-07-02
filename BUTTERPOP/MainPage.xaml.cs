using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BUTTERPOP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            andrea.Clicked += Andrea;
            emanuel.Clicked += Emanuel;
            jesus.Clicked += Jesus;
            joel.Clicked += Joel;
            julian.Clicked += Julian;
        }

        private void Andrea(object sender, EventArgs e)
        {
            // elimina esta linea y redirecciona esta pantalla a tu caso de uso o interfaz
            DisplayAlert("Andrea", "Caso de uso aún no disponible", "OK");
        }

        private void Emanuel(object sender, EventArgs e)
        {
            // elimina esta linea y redirecciona esta pantalla a tu caso de uso o interfaz
            DisplayAlert("Emanuel", "Caso de uso aún no disponible", "OK");
        }

        private void Jesus(object sender, EventArgs e)
        {
            // elimina esta linea y redirecciona esta pantalla a tu caso de uso o interfaz
            DisplayAlert("Jesus", "Caso de uso aún no disponible", "OK");
        }

        private void Joel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.testRenta());
        }

        private void Julian(object sender, EventArgs e)
        {
            // elimina esta linea y redirecciona esta pantalla a tu caso de uso o interfaz
            DisplayAlert("Julian", "Caso de uso aún no disponible", "OK");
        }
    }
}