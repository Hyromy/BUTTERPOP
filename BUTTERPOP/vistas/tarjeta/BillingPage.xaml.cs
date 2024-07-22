using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;
using BUTTERPOP.crud.usuario;


namespace BUTTERPOP.vistas.tarjeta
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BillingPage : ContentPage
	{
        private CRUD_Usuario crud = new CRUD_Usuario();

        public BillingPage () 
		{
			InitializeComponent ();
		}

        public BillingPage(string nombreUsuario, string apaternoUsuario, string amaternoUsuario, string correoUsuario, string passUsuario) : this()
        {
            // Establecer el contexto de datos con el nombre de usuario recibido
            BindingContext = new PerfilViewModel(nombreUsuario, apaternoUsuario, amaternoUsuario, correoUsuario, passUsuario);
        }


        private async void btnGuardarTarjeta_Clicked(object sender, EventArgs e)
        {
            if (validarDatosTarjeta())
            {
                if (validarMes())
                {
                    if (validarAnio())
                    {
                        if (validarTarjeta())
                        {
                            if (validarCVV())
                            {
                                if (!validarTarjetaExpirada(int.Parse(txtMes.Text), int.Parse(txtAnio.Text)))
                                {


                                    var cuentaExistente = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                                    if (cuentaExistente != null && cuentaExistente.numeroTarjeta == txtNumeroTarjeta.Text && cuentaExistente.cvv == int.Parse(txtCVV.Text) && cuentaExistente.tipoTarjeta == pickerTipoTarjeta.SelectedItem.ToString())
                                    {
                                        await DisplayAlert("Advertencia", "Este método de pago ya ha sido registrado anteriormente. Porfavor, intenta con otro o verifica la información.", "Aceptar");
                                        return;

                                    }



                                    var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);

                                    usuario.numeroTarjeta = txtNumeroTarjeta.Text;
                                    usuario.tipoTarjeta = pickerTipoTarjeta.SelectedItem.ToString();

                                    try
                                    {
                                        usuario.mes = int.Parse(txtMes.Text);
                                        usuario.anio = int.Parse(txtAnio.Text);
                                        usuario.cvv = int.Parse(txtCVV.Text);

                                        await crud.UpdateUsuarioAsync(usuario);

                                        await DisplayAlert("Guardado Exitoso", "Se ha registrado correctamente el nuevo método de pago", "Aceptar");
                                        limpiarDatos();
                                    }
                                    catch (FormatException)
                                    {
                                        await DisplayAlert("Error", "Uno o más campos contienen datos no válidos. Por favor, verifica los datos ingresados.", "Aceptar");
                                    }
                                }
                                else
                                {
                                    await DisplayAlert("Tarjeta Expirada", "Tu tarjeta ha expirado", "Aceptar");
                                }
                            }
                            else
                            {
                                await DisplayAlert("Advertencia", "Ingresa un CVV valido, debe contener 3 digitos (123)", "Aceptar");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Advertencia", "Ingresa un número de tarjeta valido, debe contener 16 digitos (xxxx-xxxx-xxxx-xxxx)", "Aceptar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Advertencia", "Ingresa un año valido, debe contener 4 digitos (yyyy)", "Aceptar");
                    }
                    
                   
                }
                else
                {
                    await DisplayAlert("Advertencia", "Ingresa un mes válido, debe contener 2 digitos (mm)", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos", "Aceptar");
            }
        }

        public bool validarMes()
        {
            
            return !string.IsNullOrEmpty(txtMes.Text) && txtMes.Text.Length == 2 &&
                   int.TryParse(txtMes.Text, out int mes) && mes > 0 && mes <= 12;
        }

        public bool validarCVV()
        {

            return !string.IsNullOrEmpty(txtCVV.Text) && txtCVV.Text.Length == 3;
        }

        public bool validarAnio()
        {
         
            return !string.IsNullOrEmpty(txtAnio.Text) && txtAnio.Text.Length == 4;
        }

        public bool validarTarjeta()
        {
            
            return !string.IsNullOrEmpty(txtNumeroTarjeta.Text) && txtNumeroTarjeta.Text.Length == 16;
        }


        public bool validarDatosTarjeta()
        {
            bool respuesta = !string.IsNullOrEmpty(txtNumeroTarjeta.Text) &&
                             !string.IsNullOrEmpty(txtMes.Text) &&
                             !string.IsNullOrEmpty(txtAnio.Text) &&
                             !string.IsNullOrEmpty(txtCVV.Text) &&
                             pickerTipoTarjeta.SelectedItem != null;
            return respuesta;
        }

        private bool validarTarjetaExpirada(int mes, int anio)
        {
           
            DateTime fechaActual = DateTime.Now;

            
            if (anio < fechaActual.Year || (anio == fechaActual.Year && mes < fechaActual.Month || mes == fechaActual.Month))
            {
                return true; // Tarjeta expirada
            }
            return false; // Tarjeta no expirada
        }

        private void limpiarDatos()
        {
            txtNumeroTarjeta.Text = "";
            txtMes.Text = "";
            txtCVV.Text = "";
            txtAnio.Text = "";
            
        }

        private async void btnVerTarjetas_Clicked(object sender, EventArgs e)
        {
            var usuario = await crud.GetUsuariosByCorreo(txtCorreoElec.Text);
            await Navigation.PushAsync(new DetalleBillingPage(usuario.correo, usuario.tipoTarjeta, usuario.numeroTarjeta, usuario.anio, usuario.mes, usuario.cvv));



        }
    }
}