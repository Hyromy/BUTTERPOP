using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xamarin.Essentials;

using SQLite;

using BUTTERPOP.utils;
using System.Threading.Tasks;

namespace BUTTERPOP.crud.renta
{
    internal class CRUD_Renta
    {
        private SQLiteAsyncConnection _db;
        private String tbName = "renta";

        public CRUD_Renta(String dbPath)
        {
            this._db = new SQLiteAsyncConnection(dbPath);
            this._db.CreateTableAsync<Renta>().Wait();
        }

        public Task<int> InsertRenta(Renta renta)
        {
            return this._db.InsertAsync(renta);
        }

        public Task<Renta> ReadRenta(int idRenta)
        {
            return this._db.Table<Renta>().Where(r => r.id_renta == idRenta).FirstOrDefaultAsync();
        }

        public Task<Renta> ReadRentaBy(string atributo, string valor)
        {
            return this._db.Table<Renta>().Where(r => atributo == valor).FirstOrDefaultAsync();
        }

        public Task<List<Renta>> ReadAllRentas()
        {
            return this._db.Table<Renta>().ToListAsync();
        }

        public Task<int> CountRentas()
        {
            return this._db.Table<Renta>().CountAsync();
        }

        public Task<int> UpdateRenta(Renta renta)
        {
            return this._db.UpdateAsync(renta);
        }

        public Task<int> DeleteRenta(Renta renta)
        {
            return this._db.DeleteAsync(renta);
        }
    }
    /*
    internal class CRUD_Renta
    {
        private string tbName;

        private string idRent;
        private string correo;
        private string idPeli;
        private string fRenta;

        public CRUD_Renta()
        {
            tbName = "renta";

            idRent = "id_renta";
            idPeli = "id_pelicula";
            correo = "correo";
            fRenta = "fecha_renta";
        }

        /// <returns>Nombre del la tabla 'renta'</returns>
        public string getTBName() { return tbName; }

        /// <returns>Clave primarial del registro</returns>
        public string getIdRent() { return idRent; }

        /// <returns>Clave foránea de la tabla 'cliente'</returns>
        public string getCorreo() { return correo; }

        /// <returns>Clave foránea de la tabla 'pelicula'</returns>
        public string getIdPeli() { return idPeli; }

        /// <returns>Campo de la fecha de renta</returns>
        public string getFRenta() { return fRenta; }

        /// <summary>
        /// Sentencia sql para insertar un nuevo registro
        /// </summary>
        /// <param name="correo">Clave foránea de la tabla 'cliente'</param>
        /// <param name="idPelicula">Clave foránea de la tabla 'pelicula'</param>
        public string InsertRenta(string correo, int idPelicula)
        {
            string fechaRenta, values, atributes;

            atributes = $"{this.correo}, {idPeli}, {fRenta}";
            fechaRenta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            values = $"'{correo}', {idPelicula}, '{fechaRenta}'";

            return $"insert into {tbName}({atributes}) values({values});";
        }

        /// <summary>
        /// Sentencia sql para leer un registro con un id específico
        /// </summary>
        /// <param name="idRenta">Clave primaria del registro</param>
        public string ReadRenta(int idRenta)
        {
            return $"select * from {tbName} where {idRent} = {idRenta};";
        }

        /// <summary>
        /// Sentencia sql para leer un registro por campo y valor especificado  
        /// </summary>
        /// <param name="atributo">Atributo de la tabla 'renta'</param>
        /// <param name="valor">Valor del campo respectivo</param>
        /// <exception cref="Exception"></exception>
        public string ReadRentaBy(string atributo, string valor)
        {
            if (atributo != idPeli ||
                atributo != fRenta ||
                atributo != correo)
            {
                string validAtb = $"'{idPeli}', '{fRenta}', '{correo}'";
                throw new Exception($"Atributo no válido, valores disponibles: ({validAtb})");
            }

            return $"select * from {tbName} where {atributo} = {valor};";
        }

        /// <summary>
        /// Sentencia sql para leer todos los registros de la tabla
        /// </summary>
        public string ReadAllRentas()
        {
            return $"select * from {tbName};";
        }

        /// <summary>
        /// Sencencia sql para contar la cantidad de registros en la tabla
        /// </summary>
        public string CountRentas()
        {
            return $"select count({idRent}) from {tbName};";
        }

        /// <summary>
        /// Sentencia sql para actualizar los campos de un registro por su id
        /// </summary>
        /// <param name="idRenta">Clave primaria del registro</param>
        /// <param name="atributos">Arreglo de Strings con el nombre de los campos a actualizar</param>
        /// <param name="valores">Arreglo de Strings con los valores a actualizar</param>
        /// <exception cref="Exception"></exception>
        public string UpdateRenta(int idRenta, string[] atributos, string[] valores)
        {
            if (atributos.Length != valores.Length)
            {
                throw new Exception("La cantidad de atributos y valores deben ser idénticos");
            }

            string updateSentence = "";
            for (byte i = 0; i < atributos.Length; i++)
            {
                if (atributos[i] != idPeli ||
                    atributos[i] != fRenta ||
                    atributos[i] != correo)
                {
                    string validAtb = $"'{idPeli}', '{fRenta}', '{correo}'";
                    throw new Exception($"Atributo no válido, valores disponibles: ({validAtb})");
                }

                if (i != atributos.Length - 1)
                {
                    updateSentence += $"{atributos[i]} = '{valores[i]}', ";
                }
                else
                {
                    updateSentence += $"{atributos[i]} = '{valores[i]}'";
                }
            }

            return $"update {tbName} set {updateSentence} where {idRent} = {idRenta};";
        }

        /// <summary>
        /// Sentencia sql para eliminar un registro por su id
        /// </summary>
        /// <param name="idRenta">Clave primarial del registro</param>
        public string DeleteRenta(int idRenta)
        {
            return $"delete from {tbName} where {idRent} = {idRenta};";
        }
    }
    */
}