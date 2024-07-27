using System;
using System.Collections.Generic;
using System.Text;
using static BUTTERPOP.db.Table;
using System.Threading.Tasks;
using BUTTERPOP.db;
using SQLite;
using System.Linq;
using System.Reflection;
using BUTTERPOP.crud.lista;

namespace BUTTERPOP.crud.contiene
{
    internal class CRUD_Contiene
    {
        private SQLiteAsyncConnection db;
        public CRUD_Contiene()
        {
            this.db = new SQLiteHelper().getConnection();
        }

        public Task<int> SaveContieneAsync(Table.Contiene cont)
        {
            if (cont.id_contiene == 0)
            {
                return db.InsertAsync(cont);
            }
            else
            {
                return null;
            }
        }
        public Task<int> DeleteContieneAsync(Table.Contiene cont)
        {
            return db.DeleteAsync(cont);
        }
        public Task<List<Table.Contiene>> GetContieneAsync()
        {
            return db.Table<Contiene>().ToListAsync();
        }
        
        public Task<Table.Contiene> GetContieneByIdAsync(int idContiene)
        {
            return db.Table<Contiene>().Where(b => b.id_contiene == idContiene).FirstOrDefaultAsync();
        }

        /*******************************************************************/
        public Task<Table.Contiene> GetContieneByListaAsync(int idLista)
        {
            return db.Table<Contiene>().Where(b => b.id_lista == idLista).FirstOrDefaultAsync();
        }
        public async Task<int> GetIdListaByNombreAsync(string nombreLista)
        {
            var lista = await this.db.Table<Table.Lista>()
                .Where(a => a.nombre == nombreLista)
                .FirstOrDefaultAsync();

            if (lista != null)
            {
                return lista.id_lista;
            }
            else
            {
                // Maneja el caso en el que no se encuentra la lista
                // Puedes lanzar una excepción o devolver un valor predeterminado
                return -1; // Por ejemplo, -1 para indicar que no se encontró la lista
            }
        }

        public async Task<List<Table.Contiene>> GetPeliculasByListasAsync(int id_lista)
        {
            var peliculas = await this.db.Table<Table.Contiene>()
                .Where(a => a.id_lista == id_lista)
                .ToListAsync();

            return peliculas;
        }

        // sacar nombre de la pelicula por id
        public async Task<string> GetNombrePeliculaById(int id_pelicula)
        {
            var pelicula = await db.Table<Pelicula>().Where(b => b.id_pelicula == id_pelicula).FirstOrDefaultAsync();
            return pelicula?.titulo; // Devuelve el nombre de la película o null si no se encuentra.
        }

    }
}
