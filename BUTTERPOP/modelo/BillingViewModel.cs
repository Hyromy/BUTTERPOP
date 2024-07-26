using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BUTTERPOP.modelo
{

    /*
        Esta clase sirve para facilitar el binding de los valores recibidos del LoginPage (usuario, correo y contraseña)
        y poder mostrarlos en el diseño XML. Lo demás es establecerle parametros constructor (revisar el cnstructor del HomePage.xml)
        y después hacerle el paso de parametros (revisar el metodo btnIniciarSesion_Clicked del LoginPage) ;)
    
     */


    public class BillingViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _correoUsuario;
        private string _tipoTarjetaUsuario;
        private string _numeroTarjetaUsuario;
        private int _mesUsuario;
        private int _anioUsuario;
        private int _cvvUsuario;



        public BillingViewModel(string correoUsuario, string tipoTarjetaUsuario, string numeroTarjetaUsuario, int mesUsuario, int anioUsuario, int cvvUsuario)
        {
           
            CorreoUsuario = correoUsuario;
            TipoTarjetaUsuario= tipoTarjetaUsuario;
            NumeroTarjetaUsuario = numeroTarjetaUsuario;
            MesUsuario = mesUsuario;
            AnioUsuario = anioUsuario;
            CvvUsuario = cvvUsuario;

        }



        public string CorreoUsuario
        {
            get { return _correoUsuario; }
            set
            {
                _correoUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CorreoUsuario)));
            }
        }
        public string TipoTarjetaUsuario
        {
            get { return _tipoTarjetaUsuario; }
            set
            {
                _tipoTarjetaUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TipoTarjetaUsuario)));
            }
        }

        public string NumeroTarjetaUsuario
        {
            get { return _numeroTarjetaUsuario; }
            set
            {
                _numeroTarjetaUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumeroTarjetaUsuario)));
            }
        }

        public int MesUsuario
        {
            get { return _mesUsuario; }
            set
            {
                _mesUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MesUsuario)));
            }
        }


        public int AnioUsuario
        {
            get { return _anioUsuario; }
            set
            {
                _anioUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnioUsuario)));
            }
        }

        public int CvvUsuario
        {
            get { return _cvvUsuario; }
            set
            {
                _cvvUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CvvUsuario)));
            }
        }








    }
}
