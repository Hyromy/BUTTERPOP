using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

using BUTTERPOP.modelo.rentar;
using BUTTERPOP.crud.renta;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class testRenta : ContentPage
    {
        CRUD_Renta crud = new CRUD_Renta();
        RentarModel rentarM = new RentarModel();

        int idRenta, idPelicula;
        String correo, fechaRenta;

        public testRenta()
        {
            InitializeComponent();

            getTBName.Clicked += TBName;
            getIdRent.Clicked += IDRent;
            getCorreo.Clicked += Correo;
            getIdPeli.Clicked += IDPeli;
            getFRenta.Clicked += FRenta;

            create.Clicked += Create;
            read.Clicked += Read;
            readBy.Clicked += ReadBy;
            readAll.Clicked += ReadAll;
            countLogs.Clicked += CountLogs;
            update.Clicked += Update;
            delete.Clicked += Delete;

            isActiveRent.Clicked += IsActiveRent;

            preview.Clicked += Preview;
        }

        private void TBName(object sender, EventArgs e) { output.Text = crud.getTBName(); }

        private void IDRent(object sender, EventArgs e) { output.Text = crud.getIdRent(); }

        private void Correo(object sender, EventArgs e) { output.Text = crud.getCorreo(); }

        private void IDPeli(object sender, EventArgs e) { output.Text = crud.getIdPeli(); }

        private void FRenta(object sender, EventArgs e) { output.Text = crud.getFRenta(); }

        private void Create(object sender, EventArgs e)
        {
            try
            {
                correo = inputCorreo.Text.Trim();
            }
            catch (NullReferenceException)
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

            if (correo == "" ||
                idPelicula <= 0)
            {
                output.Text = "(!) correo y id_pelicula requerido";
            }
        }

        private void Read(object sender, EventArgs e)
        {
            try
            {
                idRenta = int.Parse(inputIdRent.Text);
            }
            catch
            {
                idRenta = 0;
            }
            output.Text = crud.ReadRenta(idRenta);
        }

        private void ReadBy(object sender, EventArgs e)
        {
            try
            {
                output.Text = crud.ReadRentaBy("atributo", "valor");
            }
            catch (Exception err)
            {
                output.Text = err.Message;
            }
        }

        private void ReadAll(object sender, EventArgs e)
        {
            output.Text = crud.ReadAllRentas();
        }

        private void CountLogs(object sender, EventArgs e)
        {
            output.Text = crud.CountRentas();
        }

        private void Update(object sender, EventArgs e)
        {
            String[] atributos = {crud.getCorreo()};
            String[] valores = {"hyromy"};
            try
            {
                output.Text = crud.UpdateRenta(1, atributos, valores);
            }
            catch (Exception err)
            {
                output.Text = err.Message;
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            try
            {
                idRenta = int.Parse(inputIdRent.Text);
            }
            catch
            {
                idRenta = 0;
            }
            output.Text = crud.DeleteRenta(idRenta);
        }

        private void IsActiveRent(object sender, EventArgs e)
        {
            try
            {
                output.Text = rentarM.isActiveRent(inputFRenta.Text).ToString();
            }
            catch (Exception err)
            {
                output.Text = err.Message;
            }
        }

        private void Preview(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.renta.FormRenta());
        }
    }
}