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


    public class PerfilViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nombreUsuario;
        private string _apaternoUsuario;
        private string _amaternoUsuario;
       
        private string _correoUsuario;

        private string _passUsuario;


        public PerfilViewModel(string nombreUsuario, string apaternoUsuario, string amaternoUsuario, string correoUsuario, string passUsuario)
        {
            NombreUsuario = nombreUsuario;
            ApaternoUsuario = apaternoUsuario;
            AmaternoUsuario = amaternoUsuario;
            CorreoUsuario = correoUsuario;
            PassUsuario = passUsuario;
        }


        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                _nombreUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NombreUsuario)));
            }
        }

        public string ApaternoUsuario
        {
            get { return _apaternoUsuario; }
            set
            {
                _apaternoUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ApaternoUsuario)));
            }
        }

        public string AmaternoUsuario
        {
            get { return _amaternoUsuario; }
            set
            {
                _amaternoUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmaternoUsuario)));
            }
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

        public string PassUsuario
        {
            get { return _passUsuario; }
            set
            {
                _passUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassUsuario)));
            }
        }


    }
}
