using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BUTTERPOP.db
{
    public class Table
    {
        public class Cliente
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

            [MaxLength(100)]
            public string titulo { get; set; }

            [MaxLength(50)]

            public string genero { get; set; }

            [MaxLength(500)]
            public string descripcion { get; set; }

            [MaxLength(10)]
            public string clasificacion { get; set; }

            public int duracion { get; set; } // Duración en minutos

            public decimal precio { get; set; } 

            public byte[] imagen { get; set; } // Imagen en formato byte array para almacenar en la base de datos
        }

        /// <summary>
        /// Registros de renta de peliculas
        /// <para>Es necesario declarar correo, id_pelicula, semanas_renta y precio</para>
        /// <para>Es necesario validar los datos previos con el método validateInputAtributes()</para>
        /// <para>El resto de propiedades se calculan en el método calculateRent()</para>
        /// </summary>
        public class Renta
        {
            // autogenerado
            [PrimaryKey, AutoIncrement]
            public int id_renta { get; set; }

            // obligatorio
            [ForeignKey(typeof(Table.Cliente)), MaxLength(50)]
            public string correo { get; set; }

            // obligatorio
            [ForeignKey(typeof(Table.Pelicula))]
            public int id_pelicula { get; set; }

            // obligatorio
            [ForeignKey(typeof(Table.Pelicula))]
            public float precio { get; set; }

            // obligatorio
            public int semanas_renta { get; set; }

            // autogenerado
            public DateTime fecha_renta { get; set; }
            
            // autogenerado
            public DateTime fin_fecha_renta { get; set; }

            // autogenerado
            public float cobro_renta { get; set; }

            /// <summary>
            /// Valida que todos los campos obligatorios(correo, id_pelicula, precio, semanas_renta) sean adecuados
            /// </summary>
            /// <exception cref="ArgumentException"></exception>
            public void validateInputAtributes()
            {
                String reason = "No re puede crear una instancia de la tabla renta si";
                
                if (String.IsNullOrEmpty(this.correo))
                {
                    reason += " el correo esta vacio";
                    throw new ArgumentException(reason);
                }
                else if (this.id_pelicula < 0)
                {
                    reason += " el id_pelicula es menor o igual a 0";
                    throw new ArgumentException(reason);
                }
                else if (this.precio < 0)
                {
                    reason += " el precio es menor o igual a 0";
                    throw new ArgumentException(reason);
                }
                else if (this.semanas_renta < 0)
                {
                    reason += " las semanas son menores o iguales a 0";
                    throw new ArgumentException(reason);
                }
            }

            /// <summary>
            /// Calcula la fecha de fin de renta y el precio de la renta 
            /// basados en la fecha de inicio de renta, las semanas de renta y 
            /// el precio de la película 
            /// <para>La cantidad de semanas de renta debe ser de 1 a 4 semanas</para>
            /// <para>El precio de cobro de renta se calcula como la sumatoria del precio de la película sobre, 2 elevado a la iteración menos 1, dicha iteración va de 1 hasta la cantidad de semanas de renta</para>
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

                this.fecha_renta = DateTime.Now;
                this.fin_fecha_renta = this.fecha_renta.AddDays(semanas_renta * 7);

                float cobro = 0;
                for (int i = 1; i <= this.semanas_renta; i++)
                {
                    cobro += this.precio / (int) Math.Pow(2, i - 1);
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

            [ForeignKey(typeof(Pelicula))]
            public int id_pelicula { get; set; }

            [ForeignKey(typeof(Lista))]
            public int id_lista { get; set; }
        }






    }
}