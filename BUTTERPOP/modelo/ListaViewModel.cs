using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BUTTERPOP.Modelo
{
    public class ListaViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nombre;

        private string _descripcion;

        private byte[] _imagen;


        public ListaViewModel(string nombre, string descricpion, byte[] imagen)
        {
            Nombre = nombre;
            Descripcion = descricpion;
            Imagen = imagen;
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }


        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Descripcion)));
            }
        }

        public byte[] Imagen
        {
            get { return _imagen; }
            set
            {
                _imagen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Imagen)));
            }
        }
    }
}

