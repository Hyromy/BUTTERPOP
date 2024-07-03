using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BUTTERPOP.modelo
{
    public class Usuarios
    {
        [PrimaryKey, MaxLength(100)]
        public string correo { get; set; }

        [MaxLength(50)]
        public string usuario { get; set; }

        [MaxLength(50)]
        public string password { get; set; }


    }
}
