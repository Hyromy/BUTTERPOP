using System.ComponentModel;

namespace BUTTERPOP.vistas
{
    public class PerfilViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nombreUsuario;

        private string _correoUsuario;

        private string _passUsuario;

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                _nombreUsuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NombreUsuario)));
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







        public PerfilViewModel(string nombreUsuario, string correoUsuario, string passUsuario)
        {
            NombreUsuario = nombreUsuario;
            CorreoUsuario= correoUsuario;
            PassUsuario= passUsuario;
        }


     
    }
}
