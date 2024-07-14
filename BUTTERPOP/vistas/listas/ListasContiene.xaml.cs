using BUTTERPOP.crud.lista;
using BUTTERPOP.Modelo;
using BUTTERPOP.Vistas.listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BUTTERPOP.db.Table.Contiene;
using BUTTERPOP.crud.contiene;
using BUTTERPOP.db;
using static BUTTERPOP.utils.ImageResourceExtension;
using BUTTERPOP.vistas;

namespace BUTTERPOP.Vistas.listas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListasContiene : ContentPage
	{
        private CRUD_Contiene crud = new CRUD_Contiene();

        public ListasContiene()
        {
            InitializeComponent();
            llenarDatos();
        }

        public ListasContiene(string nombre, string descripcion, byte[] imagen) : this()
        {

            BindingContext = new ListaViewModel(nombre, descripcion, imagen);
            imgContiene.Source = ImageHelper.ConvertByteArrayToImage(imagen);
        }

        public void si()
        {
            Perfil verll = new Perfil();
        }
        public async void llenarDatos()
        {
            var contieneList = await crud.GetContieneAsync();
            if (contieneList != null)
            {
                lstContiene.ItemsSource = contieneList;
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
           /* 
            var contiene = await crud.GetContieneByIdAsync(obj.Id_contiene);
            if (contiene != null)
            {
                await crud.DeleteContieneAsync(contiene);
                await DisplayAlert("Aviso", "Se elimino la pelicula de la lista", "OK");
                llenarDatos();
            }
           */
        }

        private async void btnSimula_Clicked(object sender, EventArgs e)
        {
             db.Table.Contiene contiene = new db.Table. Contiene
            {
                Id_lista = 20,
                Id_pelicula = 20,
            };
            await crud.SaveContieneAsync(contiene);
            await DisplayAlert("Registro", "Lista guardada en tu interfaz", "OK");
            llenarDatos();

        }

        public async void lstContiene_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (db.Table.Contiene)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.Id_contiene.ToString()))
            {
                var lista = await crud.GetContieneByIdAsync(obj.Id_contiene);

            }
            
        }
    }

}
