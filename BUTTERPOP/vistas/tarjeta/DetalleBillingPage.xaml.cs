using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BUTTERPOP.vistas.tarjeta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleBillingPage : ContentPage
    {
        public DetalleBillingPage()
        {
            InitializeComponent();
            
        }

        public DetalleBillingPage(string correoUsuario, string tipoTarjetaUsuario, string numeroTarjetaUsuario, int mesUsuario, int anioUsuario , int cvvUsuario) : this()
        {
            // Establecer el contexto de datos con el nombre de usuario recibido
            BindingContext = new BillingViewModel(correoUsuario, tipoTarjetaUsuario, numeroTarjetaUsuario, mesUsuario, anioUsuario, cvvUsuario);


        }

        

    }
}