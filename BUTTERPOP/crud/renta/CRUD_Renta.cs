using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xamarin.Essentials;

using SQLite;
using System.Threading.Tasks;
using BUTTERPOP.db;

namespace BUTTERPOP.crud.renta
{
    internal class CRUD_Renta
    {
        private SQLiteAsyncConnection db;

        public CRUD_Renta()
        {
            this.db = new SQLiteHelper().getConnection();
        }

        /// <summary>
        /// Inserta en la tabla 'renta' un nuevo registro
        /// </summary>
        /// <param name="renta">objeto renta</param>
        /// <returns>Número de registros insertados</returns>
        public async Task<int> InsertRenta(Table.Renta renta)
        {
            return await this.db.InsertAsync(renta);
        }

        /// <summary>
        /// Lee un registro de la tabla 'renta' por su id
        /// </summary>
        /// <param name="idRenta">id de la renta</param>
        /// <returns>Objeto de la clase Renta</returns>
        public async Task<Table.Renta> ReadRenta(int idRenta)
        {
            return await this.db.Table<Table.Renta>().Where(r => r.id_renta == idRenta).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Lee un registro de la tabla 'renta' por un atributo especificado con su respectivo valor
        /// </summary>
        /// <param name="atributo">Criterio de busqueda (id_pelucula, correo, fecha_renta)</param>
        /// <param name="valor">Valor de busqueda</param>
        /// <returns>Objeto de la clase Renta</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Table.Renta> ReadRentaBy(string atributo, string valor)
        {
            if (atributo != "id_pelicula" &&
                atributo != "correo" &&
                atributo != "fecha_renta")
            {
                String validAtb = "'id_pelicula', 'correo', 'fecha_renta'";
                throw new ArgumentException($"Atributo no válido, valores disponibles: ({validAtb})");
            }

            if (atributo == "id_pelicula")
            {
                return await this.db.Table<Table.Renta>().Where(r => r.id_pelicula == int.Parse(valor)).FirstOrDefaultAsync();
            } 
            else if (atributo == "fecha_renta")
            {
                return await this.db.Table<Table.Renta>().Where(r => r.fecha_renta.ToString() == valor).FirstOrDefaultAsync();
            }
            else if (atributo == "correo")
            {
                return await this.db.Table<Table.Renta>().Where(r => r.correo == valor).FirstOrDefaultAsync();
            }
            return null;
        }

        /// <summary>
        /// Lee todos los registros de la tabla 'renta'
        /// </summary>
        /// <returns>Lista de objetos de la clase Renta</returns>
        public async Task<List<Table.Renta>> ReadAllRentas()
        {
            return await this.db.Table<Table.Renta>().ToListAsync();
        }

        /// <summary>
        /// Cuenta la cantidad de registros en la tabla 'renta'
        /// </summary>
        /// <returns>Cantidad de registros en 'renta'</returns>
        public async Task<int> CountRentas()
        {
            return await this.db.Table<Table.Renta>().CountAsync();
        }

        /// <summary>
        /// Actualiza los campos de un registro por su id
        /// </summary>
        /// <param name="renta">Objeto renta a actualizar</param>
        /// <returns>Cantidad de actualizaciones realizadas en la tabla renta</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<int> UpdateRenta(Table.Renta renta)
        {
            if (String.IsNullOrEmpty(renta.correo))
            {
                throw new ArgumentException("Correo no puede ser nulo o vacío");
            }

            if (renta.id_pelicula <= 0)
            {
                throw new ArgumentException("Id de película inválido");
            }

            if (renta.fecha_renta == null)
            {
                throw new ArgumentException("Fecha de renta no puede ser nula");
            }

            return await this.db.UpdateAsync(renta);
        }

        /// <summary>
        /// Elimina un registro de la tabla 'renta'
        /// </summary>
        /// <param name="renta">Objeto renta</param>
        /// <returns>Cantidad de registros eliminados</returns>
        public async Task<int> DeleteRenta(Table.Renta renta)
        {
            return await this.db.DeleteAsync(renta);
        }
    }
}