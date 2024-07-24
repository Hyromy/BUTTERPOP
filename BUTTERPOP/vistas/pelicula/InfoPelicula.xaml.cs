using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using BUTTERPOP.crud.lista;
using BUTTERPOP.crud.contiene;
using BUTTERPOP.Vistas.listas;
using static BUTTERPOP.utils.ImageResourceExtension;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
       
        //Propiedades de la clase Tablas
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
        private Table.Lista lista;
        private CRUD_Lista crudLista = new CRUD_Lista();
        private CRUD_Contiene crudContiene = new CRUD_Contiene();
   

        public InfoPelicula(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            //Referenciar propiedad con parametros
            this.cliente = cliente;
            this.pelicula = pelicula;

            addNavBack();
            //addTapList();

            // el metodo nunca usa await
            LlenarPickerAsync();

            btn_rent.Clicked += ToRent;
            film_poster.Source = ImageHelper.ConvertByteArrayToImage(pelicula.imagen);
            BindingContext = pelicula;
            

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

        // Llenar los elementos del picker
        public async Task LlenarPickerAsync()
        {
            var nombresListas = await crudLista.GetNombresListasPorCorreoAsync(cliente.correo);
            pickerLista.ItemsSource = nombresListas;
        }

        //picker para añadir a una lista
        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreListaSeleccionada = pickerLista.SelectedItem.ToString();
            int idLista = await crudContiene.GetIdListaByNombreAsync(nombreListaSeleccionada);

            db.Table.Contiene contiene = new db.Table.Contiene
            {
                id_lista = idLista,
                id_pelicula = 20,
            };

            await crudContiene.SaveContieneAsync(contiene);
            await DisplayAlert("Registro", "Lista guardada en tu interfaz", "OK");
        }
        /*
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
        */

        private void ToRent(object sender, EventArgs e)
        {
            // enviar el usuario y la pelicula rescatados de la vista previa
            Navigation.PushAsync(new vistas.renta.FormRenta(cliente, pelicula));
        }

        
    }
}