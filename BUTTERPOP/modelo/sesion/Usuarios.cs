using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using SQLite;

namespace BUTTERPOP.modelo
{
    public class Usuarios
    {
        [PrimaryKey, MaxLength(100)]
        public string correo { get; set; }

        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string apaterno { get; set; }
        [MaxLength(50)]
        public string amaterno { get; set; }

        [MaxLength(50)]
        public string password { get; set; }

        // Datos del número de cuenta

        [MaxLength(16)]
       
        public string numeroTarjeta { get; set; }


        [MaxLength(50)]
        public string tipoTarjeta { get; set; }
        public int cvv { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }




    }
}
