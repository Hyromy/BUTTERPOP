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
        /// Actualiza los campos de un registro de la tabla 'renta'
        /// </summary>
        /// <param name="renta">Objeto renta a actualizar</param>
        /// <returns>Cantidad de actualizaciones realizadas en la tabla renta</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<int> UpdateRenta(Table.Renta renta)
        {
            if (String.IsNullOrEmpty(renta.correo))
            {
                throw new ArgumentNullException("Correo no puede ser nulo o vacío");
            }

            if (renta.id_pelicula <= 0)
            {
                throw new ArgumentException("Id de película debe ser mayor a 0");
            }

            if (renta.precio <= 0)
            {
                throw new ArgumentException("Precio debe ser mayor a 0");
            }

            if (renta.semanas_renta <= 0)
            {
                throw new ArgumentException("Semanas de renta deben ser mayores a 0");
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