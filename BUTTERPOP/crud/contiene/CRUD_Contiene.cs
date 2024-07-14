using System;
using System.Collections.Generic;
using System.Text;
using static BUTTERPOP.db.Table;
using System.Threading.Tasks;
using BUTTERPOP.db;
using SQLite;

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
            if (cont.Id_contiene == 0)
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
            return db.Table<Contiene>().Where(b => b.Id_contiene == idContiene).FirstOrDefaultAsync();
        }
    }
}
