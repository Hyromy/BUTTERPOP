using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BUTTERPOP.Modelo
{
    public class ListaViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id_lista;

        private string _nombre;

        private string _descripcion;

        private byte[] _imagen;

        
        public ListaViewModel(int id_lista, string nombre, string descricpion, byte[] imagen)
        {
            Id_lista = id_lista;
            Nombre = nombre;
            Descripcion = descricpion;
            Imagen = imagen;
        }
        public int Id_lista 
        {
            get { return _id_lista; }
            set
            {
                _id_lista = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id_lista)));
            }
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

