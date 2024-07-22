using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using System.Security.Cryptography;
using BUTTERPOP.crud.comentario;
using System.Collections.ObjectModel;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
        private ObservableCollection<Table.Comenta> TablaComentario;
        

        public InfoPelicula(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.pelicula = pelicula;
            ListaComentarios.ItemSelected += ListaComentarios_ItemSelected;


            addNavBack();
            addTapList();

            btn_rent.Clicked += ToRent;
            btnGuardar.Clicked += BtnGuardar_Clicked;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {

            string puntuacion = ObtenerPuntuacionSeleccionada();
            if (string.IsNullOrEmpty(txtComentario.Text))
            {
                await DisplayAlert("ERROR", "El comentario no puede estar vacío", "OK");
            }
            else if (string.IsNullOrWhiteSpace(puntuacion))
            {
                await DisplayAlert("ERROR", "Debe seleccionar al menos una puntuación", "OK");
            }
            else
            {


                Table.Comenta Comentario = new Table.Comenta
                {

                    Comentario = txtComentario.Text,
                    Puntuacion = puntuacion

                };
                CRUD_Comentario crud = new CRUD_Comentario();
                await crud.InsertComentario(Comentario);
                await DisplayAlert("Confirmación", "Comentario ingresado", "ok");
                limpiarFormulario();
            }
        }
        private string ObtenerPuntuacionSeleccionada()
        {
            if (rb0.IsChecked)
            {
                return "0";
            }
            else if (rb1.IsChecked)
            {
                return "1";
            }
            else if (rb2.IsChecked)
            {
                return "2";
            }
            else if (rb3.IsChecked)
            {
                return "3";
            }
            else
            {
                return string.Empty;
            }
        }
        void limpiarFormulario()
        {
            txtComentario.Text = "";
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;

        }
        private void ListaComentarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Table.Comenta)e.SelectedItem;
            var item = obj.id_comentario.ToString();
            var com = obj.Comentario;
            var pun = obj.Puntuacion.ToString();
            var ID = Convert.ToInt32(item);


        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await db.Table<Table.Comenta>().ToListAsync();
            TablaComentario = new ObservableCollection<Table.Comenta>(ResulRegistros);
            ListaComentarios.ItemsSource = TablaComentario;
            base.OnAppearing();
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