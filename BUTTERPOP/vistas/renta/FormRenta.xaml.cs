using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.modelo.rentar;
using BUTTERPOP.crud.renta;
using BUTTERPOP.db;

namespace BUTTERPOP.vistas.renta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormRenta : ContentPage
    {
        private bool isRotate = false;
        private double frameHeight;

        public FormRenta()
        {
            InitializeComponent();

            addNavBack();

            frameHeight = abs_frame.Height;
            abs_frame.SizeChanged += resizeLayout;

            toTest.Clicked += ToTest;
            btnConfirmCard.Clicked += Pay;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            adjustFrame();
        }

        private void resizeLayout(object sender, EventArgs e)
        {
            bool currentRotation = Width > Height;
            if (isRotate != currentRotation)
            {
                isRotate = currentRotation;
                adjustFrame();
            }
        }

        private void adjustFrame()
        {
            // puede llegar a romperse si el ancho de la pantalla es menor a 512
            if (abs_frame.Width > 512)
            {
                AbsoluteLayout.SetLayoutBounds(abs_frame, new Rectangle(0.5, 0.5, 512, frameHeight));
                AbsoluteLayout.SetLayoutFlags(abs_frame, AbsoluteLayoutFlags.PositionProportional);
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(abs_frame, new Rectangle(0.5, 0.5, 1, frameHeight));
                AbsoluteLayout.SetLayoutFlags(abs_frame, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
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

        private void ToTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new testRenta());
        }

        private async void Pay(object sender, EventArgs e)
        {
            String nCuenta, mm, aa, c;
            try
            {
                nCuenta = card_number.Text.ToString();
                mm = month.Text.ToString();
                aa = year.Text.ToString();
                c = cvv.Text.ToString();
            }
            catch
            {
                nCuenta = null;
                mm = null;
                aa = null;
                c = null;
            }

            if (String.IsNullOrEmpty(nCuenta) || nCuenta.Length < 16 ||
                String.IsNullOrEmpty(mm) || mm.Length < 2 ||
                String.IsNullOrEmpty(aa) || aa.Length < 2 ||
                String.IsNullOrEmpty(c) || c.Length < 3)
            {
                await DisplayAlert("Error", "Todos los campos son requeridos", "OK");
            }
            else
            {
                // extraer la información de el cliente en uso
                Table.Cliente cliente = new Table.Cliente
                {
                    correo = "ejemplo@email.com",
                    usuario = "userName",
                    password = "password"
                };

                // extraer la información de la pelicula a rentar
                Table.Pelicula pelicula = new Table.Pelicula
                {
                    id_pelicula = 1
                };

                RentarModel rentarM = new RentarModel();
                DateTime time = DateTime.Now.AddMonths(1);

                // apurate chino
                String question = $"Deseas Rentar {pelicula.ToString()} a la cuenta '{cliente.correo}' por ${pelicula.ToString()}\nTu renta finalizará el {time.ToString()}";
                bool isPayed = (await DisplayAlert("Pagar", question, "Sí", "No")); // error
                if (isPayed)
                {
                    Table.Renta renta = new Table.Renta
                    {
                        id_pelicula = pelicula.id_pelicula,
                        correo = cliente.correo,
                    };

                    CRUD_Renta crud = new CRUD_Renta();
                    await crud.InsertRenta(renta);
                    await DisplayAlert("DEBUG", $"Se agregó un registro con el id {renta.id_renta}", "OK");

                    String sucess = "Transacción realizada exitosamente, revisa tu lista privada 'Mis películas rentadas' o haz click aquí para ver la película que acabas de rentar";
                    bool toFilms = (await DisplayAlert("Pago exitoso", sucess, "Mis películas", "Cancelar"));
                    if (toFilms)
                    {
                        NavigationPage.SetHasNavigationBar(this, false);
                        // tiene que conservar la información del cliente
                        Application.Current.MainPage = new NavigationPage(new HomePage(cliente.usuario, cliente.correo, cliente.password));
                    }
                }
                else
                {
                    await DisplayAlert("Pago cancelado", "El pago ha sido cancelado", "OK");
                }
            }
        }
    }
}