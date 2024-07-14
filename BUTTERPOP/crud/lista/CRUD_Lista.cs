using BUTTERPOP.db;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BUTTERPOP.crud;


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
            if (lis.id_Lista != 0)
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
            return db.Table<Table.Lista>().Where(a => a.id_Lista == idLista).FirstOrDefaultAsync();
        }


        
    }
    
    
}
