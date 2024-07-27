using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.crud.renta;
using BUTTERPOP.db;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class testRenta : ContentPage
    {
        private String correo;
        private int idRent, idPeli, semanas;
        private int slideValue = 0;
        private float precio;

        private CRUD_Renta crudRenta = new CRUD_Renta();

        public testRenta()
        {
            InitializeComponent();

            addNavBack();

            inputSRent.ValueChanged += Slide;

            btnclear.Clicked += Clear;
            btninsert.Clicked += Insert;
            btnread.Clicked += Read;
            btnreadAll.Clicked += ReadAll;
            btncountLogs.Clicked += CountLogs;
            btnupdate.Clicked += Update;
            btndelete.Clicked += Delete;
            btndeleteall.Clicked += DeleteAll;
        }

        private async void Insert(object sender, EventArgs e)
        {
            try
            {
                correo = inputCorreo.Text;
                idPeli = int.Parse(inputIdPeli.Text);
                semanas = slideValue + 1;
                precio = float.Parse(inputPPeli.Text);

                Table.Renta renta = new Table.Renta
                {
                    correo = correo,
                    id_pelicula = idPeli,
                    semanas_renta = semanas,
                    precio = precio,
                };

                renta.validateInputAtributes();
                renta.calculateRent();

                await crudRenta.InsertRenta(renta);
                drawData(renta);
            }
            catch (Exception err)
            {
                await DisplayAlert(err.GetType().ToString(), err.Message, "OK");
            }
        }

        private async void Read(object sender, EventArgs e)
        {
            try
            {
                idRent = int.Parse(inputIdRent.Text);

                Table.Renta renta = await crudRenta.ReadRenta(idRent);
                drawData(renta);
            }
            catch (Exception err)
            {
                await DisplayAlert(err.GetType().ToString(), err.Message, "OK");
            }
        }

        private async void ReadAll(object sender, EventArgs e)
        {
            List<Table.Renta> rentas = await crudRenta.ReadAllRentas();
            int count = rentas.Count;
            
            if (count > 0)
            {
                Console.WriteLine("\n---- Registros encontrados ----\n");
                foreach (Table.Renta renta in rentas)
                {
                    consoleData(renta);
                    Console.WriteLine("----\n");
                }

                String message = $"Se encontraron {count} registros. Revise la consola para consultar los registros";
                await DisplayAlert("Rentas", message, "OK");
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
                idRent = int.Parse(inputIdRent.Text);
                Table.Renta renta = await crudRenta.ReadRenta(idRent);

                correo = inputCorreo.Text;
                idPeli = int.Parse(inputIdPeli.Text);
                semanas = slideValue + 1;
                precio = float.Parse(inputPPeli.Text);

                renta.correo = correo;
                renta.id_pelicula = idPeli;
                renta.semanas_renta = semanas;
                renta.precio = precio;

                renta.validateInputAtributes();
                renta.calculateRent();

                await crudRenta.UpdateRenta(renta);
                drawData(renta);

                String message = $"Se ha actualizado la renta con id {idRent} exitosamente";
                await DisplayAlert("Actualización exítosa", message, "OK");
            }
            catch (Exception err)
            {
                await DisplayAlert(err.GetType().ToString(), err.Message, "OK");
            }
        }

        private async void Delete(object sender, EventArgs e)
        {
            try
            {
                idRent = int.Parse(inputIdRent.Text);
                Table.Renta renta = await crudRenta.ReadRenta(idRent);

                int delete = await crudRenta.DeleteRenta(renta);
                if (delete > 0)
                {
                    Clear(sender, e);
                    String message = $"Se ha eliminado la renta con id {idRent} exitosamente";
                    await DisplayAlert("Eliminacion exítosa", message, "OK");
                }
                else
                {
                    String message = "No se ha podido completar la eliminación";
                    await DisplayAlert("No se puede eliminar", message, "OK");
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.GetType().ToString(), err.Message, "OK");
            }
        }

        private async void DeleteAll(object sender, EventArgs e)
        {
            int logs = await crudRenta.CountRentas();
            bool delete = await DisplayAlert($"Eliminar {logs} registros", "¿Está seguro de eliminar todos los registros?", "Si", "No");

            if (delete)
            {
                await crudRenta.DeteleAllRentas(delete);
                Clear(sender, e);

                String message = "Se han eliminado todos los registros";
                await DisplayAlert("Eliminación masiva", message, "OK");
            }
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

        private void Clear(object sender, EventArgs e)
        {
            inputIdRent.Text = "";
            inputCorreo.Text = "";
            inputIdPeli.Text = "";
            inputPPeli.Text = "";

            inputSRent.Value = 0;
            outputSRent.Text = "1";

            outputFIRenta.Text = "";
            outputFFRenta.Text = "";
            outputCobro.Text = "";
        }

        private void drawData(Table.Renta renta)
        {
            inputIdRent.Text = renta.id_renta.ToString();
            inputCorreo.Text = renta.correo;
            inputIdPeli.Text = renta.id_pelicula.ToString();
            inputPPeli.Text = renta.precio.ToString();

            inputSRent.Value = renta.semanas_renta - 1;
            outputSRent.Text = renta.semanas_renta.ToString();

            outputFIRenta.Text = renta.fecha_renta.ToString();
            outputFFRenta.Text = renta.fin_fecha_renta.ToString();
            outputCobro.Text = renta.cobro_renta.ToString();
        }

        private void consoleData(Table.Renta renta)
        {
            Console.WriteLine("id_renta: " + renta.id_renta.ToString());
            Console.WriteLine("correo: " + renta.correo);
            Console.WriteLine("id_pelicula" + renta.id_pelicula.ToString());
            Console.WriteLine("precio: " + renta.precio.ToString());
            Console.WriteLine("semanas_renta: " + renta.semanas_renta.ToString());

            Console.WriteLine("fecha_renta: " + renta.fecha_renta.ToString());
            Console.WriteLine("fin_fecha_renta" + renta.fin_fecha_renta.ToString());
            Console.WriteLine("cobro_renta" + renta.cobro_renta.ToString());
        }

        private void Slide(object sender, ValueChangedEventArgs e)
        {
            int value = (int)Math.Round(e.NewValue);
            slideValue = value;
            inputSRent.Value = value;
            outputSRent.Text = (1 + value).ToString();
        }
    }
}