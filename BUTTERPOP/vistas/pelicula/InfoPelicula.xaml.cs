﻿using System;
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
using BUTTERPOP.crud.renta;
using SQLite;
using BUTTERPOP.crud.usuario;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
        
        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
        private ObservableCollection<Table.Comenta> TablaComentario;

        private CRUD_Comentario crudCOMENTA = new CRUD_Comentario();


        public InfoPelicula(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.pelicula = pelicula;
            LoadCom();
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
                CRUD_Usuario crud2 = new CRUD_Usuario();
                Table.Comenta Comentario = new Table.Comenta
                {
                    correo = this.cliente.correo,
                    Comentario = txtComentario.Text,
                    Puntuacion = puntuacion


                };
                CRUD_Comentario crud = new CRUD_Comentario();
                await crud.InsertComentario(Comentario);

                await DisplayAlert("Confirmación", "Comentario ingresado", "ok");
                limpiarFormulario();
            }

        }
        public async Task LoadCom()
        {
            CRUD_Comentario crud = new CRUD_Comentario();
            var coments = await crud.GetComentariosAsync();
            ListaComentarios.ItemsSource = coments;
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

            /*
             * 
             *             if (!string.IsNullOrEmpty(actId.Text))
            {
                Lista lista = new Lista()
                {
                    id_lista = Convert.ToInt32(actId.Text),
                    nombre = actNombre.Text,
                    descripcion = actDesc.Text,
                    imagen = ImageHelper.ConvertImageToByteArray(imgEditar.Source),

                };
                await crud2.SaveListaAsync(lista);
                frameEditar.IsVisible = false;
                await DisplayAlert("Actualización", "Lista actualizada", "OK");
                llenarDatosListas();

            }
            try
            {
                Navigation.PushAsync(new V_Detalle(ID, com, pun));
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async override void OnAppearing()
        {
            CRUD_Comentario crud = new CRUD_Comentario();
            var ResulRegistros = await crud.Table<Table.Comenta>().ToListAsync();
            TablaContacto = new ObservableCollection<T_Contacto>(ResulRegistros);
            ListaContactos.ItemsSource = TablaContacto;
            base.OnAppearing();
        }
    
            */
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