using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BUTTERPOP.vistas.pelicula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPelicula : ContentPage
    {
        public InfoPelicula()
        {
            InitializeComponent();

            btn_rent.Clicked += ToRent;
        }

        private void ToRent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vistas.renta.FormRenta());
        }
    }
}