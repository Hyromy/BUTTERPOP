using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BUTTERPOP.db;

namespace BUTTERPOP.vistas.tarjeta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleBillingPage : ContentPage
    {
        private Table.Cliente cliente;
        public DetalleBillingPage(Table.Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;

            txtCorreoElec.Text = this.cliente.correo;
            txtTarjeta.Text = this.cliente.numeroTarjeta;
            txtTipo.Text = this.cliente.tipoTarjeta;
            txtMes.Text = this.cliente.mes.ToString();
            txtAnio.Text = this.cliente.anio.ToString();
            txtCVV.Text = this.cliente.cvv.ToString();


        }

       

        

    }
}