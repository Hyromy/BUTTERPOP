using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xamarin.Essentials;

namespace BUTTERPOP.crud
{
    internal class CRUD_Renta
    {
        private String tbName;

        private String idRent;
        private String correo;
        private String idPeli;
        private String fRenta;

        public CRUD_Renta()
        {
            this.tbName = "renta";

            this.idRent = "id_renta";
            this.idPeli = "id_pelicula";
            this.correo = "correo";
            this.fRenta = "fecha_renta";
        }

        /// <returns>Nombre del la tabla 'renta'</returns>
        public String getTBName() { return this.tbName; }

        /// <returns>Clave primarial del registro</returns>
        public String getIdRent() { return this.idRent; }

        /// <returns>Clave foránea de la tabla 'cliente'</returns>
        public String getCorreo() { return this.correo; }

        /// <returns>Clave foránea de la tabla 'pelicula'</returns>
        public String getIdPeli() { return this.idPeli; }

        /// <returns>Campo de la fecha de renta</returns>
        public String getFRenta() { return this.fRenta; }

        /// <summary>
        /// Sentencia sql para insertar un nuevo registro
        /// </summary>
        /// <param name="correo">Clave foránea de la tabla 'cliente'</param>
        /// <param name="idPelicula">Clave foránea de la tabla 'pelicula'</param>
        public String create(String correo, int idPelicula)
        {
            String fechaRenta, values, atributes;

            atributes = $"{this.correo}, {this.idPeli}, {this.fRenta}";
            fechaRenta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            values = $"'{correo}', {idPelicula}, '{fechaRenta}'";

            return $"insert into {this.tbName}({atributes}) values({values});";
        }

        /// <summary>
        /// Sentencia sql para leer un registro con un id específico
        /// </summary>
        /// <param name="idRenta">Clave primaria del registro</param>
        public String read(int idRenta)
        {
            return $"select * from {this.tbName} where {this.idRent} = {idRenta};";
        }

        /// <summary>
        /// Sentencia sql para leer un registro por campo y valor especificado  
        /// </summary>
        /// <param name="atributo">Atributo de la tabla 'renta'</param>
        /// <param name="valor">Valor del campo respectivo</param>
        /// <exception cref="Exception"></exception>
        public String readBy(String atributo, String valor)
        {
            if (atributo != this.idPeli ||
                atributo != this.fRenta ||
                atributo != this.correo)
            {
                String validAtb = $"'{this.idPeli}', '{this.fRenta}', '{this.correo}'";
                throw new Exception($"Atributo no válido, valores disponibles: ({validAtb})");
            }

            return $"select * from {this.tbName} where {atributo} = {valor};";
        }

        /// <summary>
        /// Sentencia sql para leer todos los registros de la tabla
        /// </summary>
        public String readAll()
        {
            return $"select * from {this.tbName};";
        }

        /// <summary>
        /// Sencencia sql para contar la cantidad de registros en la tabla
        /// </summary>
        public String countLogs()
        {
            return $"select count({this.idRent}) from {this.tbName};"; 
        }

        /// <summary>
        /// Sentencia sql para actualizar los campos de un registro por su id
        /// </summary>
        /// <param name="idRenta">Clave primaria del registro</param>
        /// <param name="atributos">Arreglo de Strings con el nombre de los campos a actualizar</param>
        /// <param name="valores">Arreglo de Strings con los valores a actualizar</param>
        /// <exception cref="Exception"></exception>
        public String update(int idRenta, String[] atributos, String[] valores)
        {
            if (atributos.Length != valores.Length)
            {
                throw new Exception("La cantidad de atributos y valores deben ser idénticos");
            }

            String updateSentence = "";
            for (byte i = 0; i < atributos.Length; i++)
            {
                if (atributos[i] != this.idPeli ||
                    atributos[i] != this.fRenta ||
                    atributos[i] != this.correo)
                {
                    String validAtb = $"'{this.idPeli}', '{this.fRenta}', '{this.correo}'";
                    throw new Exception($"Atributo no válido, valores disponibles: ({validAtb})");
                }

                if (i != atributos.Length -1)
                {
                    updateSentence += $"{atributos[i]} = '{valores[i]}', ";
                }
                else
                {
                    updateSentence += $"{atributos[i]} = '{valores[i]}'";
                }
            }

            return $"update {this.tbName} set {updateSentence} where {this.idRent} = {idRenta};";
        }

        /// <summary>
        /// Sentencia sql para eliminar un registro por su id
        /// </summary>
        /// <param name="idRenta">Clave primarial del registro</param>
        public String delete(int idRenta)
        {
            return $"delete from {this.tbName} where {this.idRent} = {idRenta};";
        }
    }
}