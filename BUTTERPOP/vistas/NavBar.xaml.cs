using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using BUTTERPOP.vistas.tarjeta;


namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {

        public HomePage(Table.Cliente cliente)
        {
            InitializeComponent();

            this.Children.Add(new Home(cliente));
            this.Children.Add(new Buscar());
            this.Children.Add(new Perfil(cliente));
            new BillingPage(cliente);
            
        


        /*public HomePage(string nombreUsuario, string apaternoUsuario, string amaternoUsuario,  string correoUsuario, string passUsuario) : this()
        {
            // Establecer el contexto de datos con el nombre de usuario recibido
            BindingContext = new PerfilViewModel(nombreUsuario, apaternoUsuario, amaternoUsuario, correoUsuario, passUsuario);
        } */
        }
    }
}