using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BUTTERPOP.db
{
    public class Table
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
        /// Registros de renta de peliculas
        /// <para>Es necesario declarar correo, id_pelicula, semanas_renta y precio</para>
        /// <para>Para declarar el resto de propiedades es necesario ejecutar el método calculateRent()</para>
        /// </summary>
        public class Renta
        {
            [PrimaryKey, AutoIncrement]
            public int id_renta { get; set; }

            [ForeignKey(typeof(Table.Cliente)), MaxLength(50)]
            public string correo { get; set; }

            [ForeignKey(typeof(Table.Pelicula))]
            public int id_pelicula { get; set; }

            [ForeignKey(typeof(Table.Pelicula))]
            public float precio { get; set; }

            public DateTime fecha_renta { get; set; }

            public DateTime fin_fecha_renta { get; set; }

            public int semanas_renta { get; set; }
            
            public float cobro_renta { get; set; }

            public Renta()
            {
                this.fecha_renta = DateTime.Now;
            }

            /// <summary>
            /// Calcula la fecha de fin de renta y el precio de la renta 
            /// basados en la fecha de inicio de renta, las semanas de renta y 
            /// el precio de la película 
            /// (para su ejecución es necesario declarar this.precio y this.semanas_renta)
            /// <para>La cantidad de semanas de renta debe ser de 1 a 4 semanas</para>
            /// <para>El precio de cobro de renta se calcula como la sumatoria del precio de la película sobre la iteración, la cual va de 1 hasta la cantidad de semanas de renta</para>
            /// </summary>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public void calculateRent()
            {
                if (this.precio <= 0)
                {
                    String reason = "No se puede calcular el precio de la renta si el precio de la película es menor o igual a 0";
                    throw new ArgumentNullException(reason);
                }
                else if (this.semanas_renta <= 0)
                {
                    String reason = "No se puede calcular el preico de la renta si las semanas de renta es menor o igual a 0";
                    throw new ArgumentNullException(reason);
                }
                else if (this.semanas_renta > 4)
                {
                    String reason = "No se puede realizar una renta mayor a 4 semanas";
                    throw new ArgumentOutOfRangeException(reason);
                }

                this.fin_fecha_renta = this.fecha_renta.AddDays(semanas_renta * 7);

                float cobro = 0;
                for (int i = 1; i <= this.semanas_renta; i++)
                {
                    cobro += this.precio / i;
                }

                this.cobro_renta = cobro;
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