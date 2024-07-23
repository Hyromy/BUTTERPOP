using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using SQLite;
using BUTTERPOP.db;

namespace BUTTERPOP.crud.pelicula
{
    internal class CRUD_Pelicula
    {
        private SQLiteAsyncConnection db;
        public CRUD_Pelicula()
        {
            this.db = new SQLiteHelper().getConnection();
        }

        public Task<int> SavePeliculaAsync(Table.Pelicula pelicula)
        {
            if (pelicula.id_pelicula != 0)
            {

                return db.UpdateAsync(pelicula);
            }
            else
            {
                return db.InsertAsync(pelicula);
            }
        }


        public Task<int> DeletePeliculaAsync(Table.Pelicula pelicula)
        {
            return db.DeleteAsync(pelicula);
        }

        public Task<List<Table.Pelicula>> GetPeliculasAsync()
        {
            return db.Table<Table.Pelicula>().ToListAsync();
        }

        public Task<Table.Pelicula> GetPeliculasByIdAsync(int idPelicula)
        {
            return db.Table<Table.Pelicula>().Where(a => a.id_pelicula == idPelicula).FirstOrDefaultAsync();
        }

      



    }
}
