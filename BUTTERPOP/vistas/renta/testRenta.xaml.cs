using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.crud.renta;
using BUTTERPOP.modelo.rentar;
using BUTTERPOP.db;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class testRenta : ContentPage
    {
        CRUD_Renta crudRenta = new CRUD_Renta();

        int idRenta, idPelicula;
        String correo, fechaRenta;

        public testRenta()
        {
            InitializeComponent();

            addNavBack();

            clear.Clicked += (sender, e) =>
            {
                inputIdRent.Text = "";
                inputCorreo.Text = "";
                inputIdPeli.Text = "";
                inputFRenta.Text = "";
            };

            insert.Clicked += Insert;
            read.Clicked += Read;
            readBy.Clicked += ReadBy;
            readAll.Clicked += ReadAll;
            countLogs.Clicked += CountLogs;
            update.Clicked += Update;
            delete.Clicked += Delete;

            isActiveRent.Clicked += Active;

            
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

        private async void Insert(object sender, EventArgs e)
        {
            try
            {
                correo = inputCorreo.Text.Trim();
                idPelicula = int.Parse(inputIdPeli.Text);
            }
            catch
            {
                correo = null;
                idPelicula = 0;
            }

            if ((correo != null || correo != "") &&
                idPelicula > 0)
            {
                Table.Renta renta = new Table.Renta
                {
                    correo = correo,
                    id_pelicula = idPelicula
                };

                await crudRenta.InsertRenta(renta);

                inputIdRent.Text = renta.id_renta.ToString();
                inputCorreo.Text = renta.correo;
                inputIdPeli.Text = renta.id_pelicula.ToString();
                inputFRenta.Text = renta.fecha_renta.ToString();
            }
            else
            {
                await DisplayAlert("Error", "correo e id_pelicula requerido", "OK");
            }
        }

        private async void Read(object sender, EventArgs e)
        {
            try
            {
                idRenta = int.Parse(inputIdRent.Text);
            }
            catch
            {
                idRenta = 0;
            }

            if (idRenta > 0)
            {
                Table.Renta renta = await crudRenta.ReadRenta(idRenta);

                if (renta != null)
                {
                    inputIdRent.Text = renta.id_renta.ToString();
                    inputCorreo.Text = renta.correo;
                    inputIdPeli.Text = renta.id_pelicula.ToString();
                    inputFRenta.Text = renta.fecha_renta.ToString();
                }
                else
                {
                    await DisplayAlert("Registro inexistente", "No se encontró registro", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "id_renta requerido", "OK");
            }
        }

        private async void ReadBy(object sender, EventArgs e)
        {
            try
            {
                correo = inputCorreo.Text.Trim();
            }
            catch
            {
                correo = "";
            }

            try
            {
                idPelicula = int.Parse(inputIdPeli.Text);
            }
            catch
            {
                idPelicula = 0;
            }

            try
            {
                fechaRenta = inputFRenta.Text.Trim();
            }
            catch
            {
                fechaRenta = "";
            }

            if (!(String.IsNullOrEmpty(correo)) ||
                (idPelicula > 0) ||
                !(String.IsNullOrEmpty(fechaRenta)))
            {
                Table.Renta renta = null;
                if (!String.IsNullOrEmpty(correo))
                {
                    renta = await crudRenta.ReadRentaBy("correo", correo);
                }
                else if (idPelicula > 0)
                {
                    renta = await crudRenta.ReadRentaBy("id_pelicula", idPelicula.ToString());
                }
                else if (!String.IsNullOrEmpty(fechaRenta))
                {
                    renta = await crudRenta.ReadRentaBy("fecha_renta", fechaRenta);
                }

                if (renta != null)
                {
                    inputIdRent.Text = renta.id_renta.ToString();
                    inputCorreo.Text = renta.correo;
                    inputIdPeli.Text = renta.id_pelicula.ToString();
                    inputFRenta.Text = renta.fecha_renta.ToString();
                }
                else
                {
                    await DisplayAlert("Registro inexistente", "No se encontró registro", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "correo, id_pelicula o fecha_renta requerido", "OK");
            }
        }
        
        private async void ReadAll(object sender, EventArgs e)
        {
            List<Table.Renta> rentas = await crudRenta.ReadAllRentas();
            if (rentas.Count > 0)
            {
                await DisplayAlert("Rentas", "Se encontraron " + rentas.Count + " registros.\nRevise la consola para consultar los registros", "OK");
                
                Console.WriteLine("\n---- Registros encontrados ----\n");
                foreach (Table.Renta renta in rentas)
                {
                    Console.WriteLine("id: " + renta.id_renta);
                    Console.WriteLine("correo: " + renta.correo);
                    Console.WriteLine("id_pelicula: " + renta.id_pelicula);
                    Console.WriteLine("fecha_renta: " + renta.fecha_renta);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                await DisplayAlert("Rentas", "No se encontraron registros", "OK");
            }
        }

        private async void CountLogs(object sender, EventArgs e)
        {
            int count = await crudRenta.CountRentas();
            await DisplayAlert("Rentas", "Se encontraron " + count + " registros", "OK");
        }

        private async void Update(object sender, EventArgs e)
        {
            try
            {
                idRenta = int.Parse(inputIdRent.Text);

            }
            catch
            {
                idRenta = 0;
            }

            Table.Renta renta = await crudRenta.ReadRenta(idRenta);
            if (renta != null)
            {
                try
                {
                    correo = inputCorreo.Text.Trim();
                }
                catch
                {
                    correo = null;
                }

                try
                {
                    idPelicula = int.Parse(inputIdPeli.Text);
                }
                catch
                {
                    idPelicula = 0;
                }

                try
                {
                    fechaRenta = inputFRenta.Text.Trim();
                }
                catch
                {
                    fechaRenta = null;
                }

                if (!String.IsNullOrEmpty(correo))
                {
                    renta.correo = correo;
                }

                if (idPelicula > 0)
                {
                    renta.id_pelicula = idPelicula;
                }

                if (!String.IsNullOrEmpty(fechaRenta))
                {
                    try
                    {
                        renta.fecha_renta = DateTime.Parse(fechaRenta);
                    }
                    catch
                    { }
                }

                if (await crudRenta.UpdateRenta(renta) > 0)
                {
                    await DisplayAlert("Actualización", "Registro actualizado", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo actualizar el registro", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "id_renta requerido", "OK");
            }
        }

        private async void Delete(object sender, EventArgs e)
        {
            try
            {
                idRenta = int.Parse(inputIdRent.Text);
            }
            catch
            {
                idRenta = 0;
            }

            if (idRenta > 0)
            {
                Table.Renta renta = await crudRenta.ReadRenta(idRenta);
                if (renta != null)
                {
                    if (await DisplayAlert("Confirmación", "¿Desea eliminar el registro?", "Sí", "No"))
                    {
                        if (await crudRenta.DeleteRenta(renta) > 0)
                        {
                            await DisplayAlert("Eliminación", "Registro eliminado", "OK");

                            inputIdRent.Text = "";
                            inputCorreo.Text = "";
                            inputIdPeli.Text = "";
                            inputFRenta.Text = "";
                        }
                        else
                        {
                            await DisplayAlert("Elimicación", "No se eliminó el registro", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Registro inexistente", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "id_renta requerido", "OK");
            }
        }

        private async void Active(object sender, EventArgs e)
        {
            try
            {
                DateTime time = DateTime.Parse(inputFRenta.Text.Trim());
                RentarModel rentar = new RentarModel();
                if (rentar.isActiveRent(time))
                {
                    await DisplayAlert("Rentar", "Renta vigente", "OK");
                }
                else
                {
                    await DisplayAlert("Rentar", "Renta vencida", "OK");
                }
            }
            catch
            {
                await DisplayAlert("Error", "Fecha de renta no válida", "OK");
            }
        }
    }
}