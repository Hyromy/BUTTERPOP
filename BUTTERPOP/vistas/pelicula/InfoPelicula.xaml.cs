using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using static BUTTERPOP.utils.ImageResourceExtension;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
       
        //Propiedades de la clase Tablas
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
   

        public InfoPelicula(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            //Referenciar propiedad con parametros
            this.cliente = cliente;
            this.pelicula = pelicula;

           
            addTapList();

            btn_rent.Clicked += ToRent;

            BindingContext = pelicula;


            film_poster.Source = ImageHelper.ConvertByteArrayToImage(pelicula.imagen);
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