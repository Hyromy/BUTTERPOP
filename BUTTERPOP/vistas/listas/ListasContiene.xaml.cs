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
using System.ComponentModel;
using static BUTTERPOP.db.Table;
using System.Collections;
namespace BUTTERPOP.Vistas.listas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListasContiene : ContentPage
	{
        private CRUD_Contiene crud = new CRUD_Contiene();
        private Table.Lista lista;
        Table.Cliente cliente;
        public ListasContiene()
        {
            InitializeComponent();
            
        }

        //llenado de la vista por lista
        public ListasContiene(int id_lista, string nombre, string descripcion, byte[] imagen, Table.Cliente cliente) : this()
        {
            this.cliente = cliente;
            BindingContext = new ListaViewModel(id_lista, nombre, descripcion, imagen);
            imgContiene.Source = ImageHelper.ConvertByteArrayToImage(imagen);
            llenarDatos(id_lista);
        }

        
        
        //Aqui debe mostrar las pelicula de cada lista
        public async void llenarDatos(int idLista)
        {
            
                List<Table.Contiene> contieneList = await crud.GetPeliculasByListasAsync(idLista);
                if (contieneList != null)
                {
                    lstContiene.ItemsSource = contieneList;
                }
            
        }


        //Pendiente eliminar
        public async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var contiene = await crud.GetContieneByIdAsync(Convert.ToInt32(lblIdContiene.Text));
            if (contiene != null)
            {
                var result = await DisplayAlert("Confirmación", "¿Estás segur@ de eliminar la pelicula de la lista?", "Sí", "No");
                if (result)
                {
                    await crud.DeleteContieneAsync(contiene);
                    await DisplayAlert("Aviso", "Se elimino la lista", "OK");
                    Navigation.PushAsync(new Perfil(cliente));
                }
                else
                {
                    // El usuario hizo clic en "No"
                }
                
            }
        }

        //Esto arroja datos de cada pelicula de la lista

        public async void lstContiene_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (db.Table.Contiene)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.id_contiene.ToString()))
            {
                var contiene = await crud.GetContieneByIdAsync(obj.id_contiene);
                if (contiene != null)
                {
                    lblIdContiene.Text = contiene.id_contiene.ToString();

                }
            }
        }

        
    }

}
