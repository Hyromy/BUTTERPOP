using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;

        public InfoPelicula(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.pelicula = pelicula;

            addNavBack();
            addTapList();

            btn_rent.Clicked += ToRent;
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

        private void addTapList()
        {
            TapGestureRecognizer tapList = new TapGestureRecognizer();
            tapList.Tapped += (s, e) =>
            {
                // acciones para agregar a lista
                DisplayAlert("Listas", "Función aun no disponible", "OK");
            };

            add_list.GestureRecognizers.Add(tapList);
        }

        private void ToRent(object sender, EventArgs e)
        {
            // enviar el usuario y la pelicula rescatados de la vista previa
            Navigation.PushAsync(new vistas.renta.FormRenta(cliente, pelicula));
        }
    }
}