using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BUTTERPOP.db
{
    internal class Table
    {
        public class Cliente
        {
            [PrimaryKey, MaxLength(50)]
            public string correo { get; set; }

            [MaxLength(50)]
            public string usuario { get; set; }

            [MaxLength(50)]
            public string password { get; set; }
            
        }

        public class Lista
        {
            [PrimaryKey, AutoIncrement]
            public int id_lista { get; set; }
            [MaxLength(20)]
            public String nombre { get; set; }
            [MaxLength(50)]
            public String descripcion { get; set; }

            public byte[] imagen { get; set; }

            /*******************/
            [ForeignKey(typeof(Cliente))]
            public string correo { get; set; }

        }


        public class Administrador
        {
            [PrimaryKey]
            public string correo_admin { get; set; }
        }

        public class Pelicula
        {
            [PrimaryKey, AutoIncrement]
            public int id_pelicula { get; set; }
        }

        /// <summary>
        /// Registros de renta de peliculas, solo necesita correo y id_pelicula
        /// </summary>
        public class Renta
        {
            [PrimaryKey, AutoIncrement]
            public int id_renta { get; set; }

            [MaxLength(50)]
            public string correo { get; set; }

            public int id_pelicula { get; set; }

            public DateTime fecha_renta { get; set; }

            public Renta()
            {
                this.fecha_renta = DateTime.Now;
            }
        }

        public class Comenta
        {
            [PrimaryKey, AutoIncrement]
            public int id_comentario { get; set; }
        }

        public class Contiene
        {
            [PrimaryKey, AutoIncrement]
            public int id_contiene { get; set; }

            [MaxLength(20)]
            public int id_pelicula { get; set; }

            [MaxLength(20)]
            public int id_lista { get; set; }
        }

    }
}