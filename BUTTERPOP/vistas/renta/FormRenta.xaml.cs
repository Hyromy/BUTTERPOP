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

        private int slideValue = 0;

        private String number = "";
        private String mm = "";
        private String aa = "";
        private String key = "";

        private Table.Cliente cliente;
        private Table.Pelicula pelicula;
        private Table.Renta renta;

        private RentarModel model = new RentarModel();
        private CRUD_Renta crud = new CRUD_Renta();

        public FormRenta(Table.Cliente cliente, Table.Pelicula pelicula)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.pelicula = pelicula;

            addNavBack();

            frameHeight = abs_frame.Height;
            abs_frame.SizeChanged += resizeLayout;

            input_slide_semanas.ValueChanged += Slide;

            btnConfirmCard.Clicked += ToPay;

            toTest.Clicked += ToTest;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            adjustFrame();
            LoadFilm();
        }

        private void LoadFilm()
        {
            film_name.Text = this.pelicula.titulo;
        }

        private async void ToPay(object sender, EventArgs e)
        {
            try
            {
                CleanInputData(sender, e);

                this.model.validateInputsCard(this.number, this.mm, this.aa, this.key);
                DateTime cardDate = model.monthYearToDate(mm, aa);
                slideValue = 1 + (int) input_slide_semanas.Value;
                String timeEnd = DateTime.Now.AddDays(7 * slideValue).ToString("dd/MM/yyyy HH:mm");

                String question = "";
                question += $"¿Deseas rentar '{this.pelicula.titulo}'";
                question += $" a la cuenta '{this.cliente.correo}'";
                question += $" por ${model.CalculatePrice((float) this.pelicula.precio, slideValue)}?";
                question += $"\n\nTu renta finalizará el {timeEnd}hrs";

                bool isPayed = (await DisplayAlert("Pagar", question, "Sí", "No"));
                if (isPayed)
                {
                    await ProcesingPay();
                    Pay();

                    String sucess = "Transacción realizada exitosamente, revisa tu lista privada 'Mis películas rentadas' o haz click en 'Ir' para ver la película que acabas de rentar";
                    bool toFilms = (await DisplayAlert("Pago exitoso", sucess, "Ir", "OK"));
                    if (toFilms)
                    {
                        Application.Current.MainPage = new NavigationPage(new HomePage(this.cliente));
                    }
                }
                else
                {
                    await DisplayAlert("Cobro cancelado", "Se ha cancelado la operación", "OK");
                }
            }
            catch (Exception err)
            {
                String reason;
                if (err.Message.StartsWith("Value cannot be null."))
                {
                    reason = err.Message.Substring(38);
                }
                else
                {
                    reason = err.Message;
                }

                Console.WriteLine(err.GetType() + " => " + reason);
                await DisplayAlert("Error", reason, "OK");
            }   
        }

        private void Slide(object sender, ValueChangedEventArgs e)
        {
            int value = (int)Math.Round(e.NewValue);
            slideValue = value;
            input_slide_semanas.Value = value;
            output_semanas.Text = (1 + value).ToString();
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

        private void CleanInputData(object sender, EventArgs e)
        {
            try
            {
                this.number = card_number.Text;
            }
            catch
            {
                this.number = null;
            }

            try
            {
                this.mm = month.Text;
            }
            catch
            {
                this.mm = null;
            }

            try
            {
                this.aa = year.Text;
            }
            catch
            {
                this.aa = null;
            }

            try
            {
                this.key = cvv.Text;
            }
            catch
            {
                this.key = null;
            }
        }

        private async void Pay()
        {
            this.renta = new Table.Renta
            {
                correo = this.cliente.correo,
                id_pelicula = this.pelicula.id_pelicula,
                precio = (float) this.pelicula.precio,
                semanas_renta = slideValue
            };

            renta.validateInputAtributes();
            renta.calculateRent();

            await this.crud.InsertRenta(renta);
            Console.WriteLine($"Nuevo registro de renta con id: {this.renta.id_renta}");
        }

        private async Task ProcesingPay()
        {
            ActivityIndicator load = new ActivityIndicator
            {
                IsRunning = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Color = Color.FromHex("#c80000")
            };

            Frame frame = new Frame
            {
                CornerRadius = 32,
                Margin = 0,
                Padding = 32,
                BackgroundColor = Color.FromHex("#1c1c1c"),
                Content = load
            };

            AbsoluteLayout absolute = new AbsoluteLayout
            {
                BackgroundColor = Color.FromRgba(0, 0, 0, 128),
                Children = { frame }
            };

            AbsoluteLayout.SetLayoutBounds(frame, new Rectangle(0.5, 0.5, 192, 192));
            AbsoluteLayout.SetLayoutFlags(frame, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(frame);
            Grid.SetRow(absolute, 0);
            Grid.SetRowSpan(absolute, 3);

            main.Children.Add(absolute);
            await Task.Delay(new Random().Next(3000, 5001));
            main.Children.Remove(absolute);
        }

        private void ToTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new testRenta());
        }
    }
}