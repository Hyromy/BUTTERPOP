using BUTTERPOP.db;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BUTTERPOP.crud;
using System.Collections;
using System.Buffers;
using System.Linq;


namespace BUTTERPOP.crud.lista
{
    internal class CRUD_Lista
    {
        private SQLiteAsyncConnection db;
        public CRUD_Lista()
        {
            this.db = new SQLiteHelper().getConnection();
        }
        public Task<int> SaveListaAsync(Table.Lista lis)
        {
            if (lis.id_lista != 0)
            {

                return db.UpdateAsync(lis);
            }
            else
            {
                return db.InsertAsync(lis);
            }
        }
        public Task<int> DeleteListaAsync(Table.Lista lis)
        {
            return db.DeleteAsync(lis);
        }
        public Task<List<Table.Lista>> GetListasAsync()
        {
            return db.Table<Table.Lista>().ToListAsync();
        }

        public Task<Table.Lista> GetListaByIdAsync(int idLista)
        {
            return db.Table<Table.Lista>().Where(a => a.id_lista == idLista).FirstOrDefaultAsync();
        }

        public Task<List<Table.Lista>> GetListasByCorreoAsync(string correo)
        {
            return this.db.Table<Table.Lista>().Where(a => a.correo == correo).ToListAsync();
        }

        public async Task<List<string>> GetNombresListasPorCorreoAsync(string correo)
        {
            try
            {
                var listas = await this.db.Table<Table.Lista>()
                    .Where(a => a.correo == correo)
                    .ToListAsync();

                var nombresListas = listas.Select(a => a.nombre).ToList();

                return nombresListas;
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí (por ejemplo, registra o notifica el error)
                Console.WriteLine($"Error al obtener nombres de listas: {ex.Message}");
                return null; // Otra acción apropiada en caso de error
            }
        }


    }
    
    
}
