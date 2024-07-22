using BUTTERPOP.db;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUTTERPOP.crud.comentario
{
    internal class CRUD_Comentario
    {
        private SQLiteAsyncConnection db;
        public CRUD_Comentario()
        {
            this.db = new SQLiteHelper().getConnection();
        }

        public async Task<int> InsertComentario(Table.Comenta Comentario)
        {
            return await this.db.InsertAsync(Comentario);
        }


        /// <summary>
        /// Recuperar todos los comentarios
        /// </summary>
        /// <returns></returns>
        public Task<List<Table.Comenta>> GetComentariosAsync()
        {
            return db.Table<Table.Comenta>().ToListAsync();
        }

        /// <summary>
        /// Recuperar comentarios por correo
        /// </summary>
        /// <returns></returns>
        /*
        public Task<Table.Comenta> GetComentariosByIDpeli(string IDpeli)
        {
            return db.Table<Table.Comenta>().Where(a => a.IDpeli == IDpeli).FirstOrDefaultAsync();
        }

        public Task<int> UpdateUsuarioAsync(Table.Cliente usuario)
        {
            if (usuario.correo != null)
            {
                return db.UpdateAsync(usuario);
            }
            else
            {
                return null;
            }
        }

        public Task<int> DeleteUsuarioAsync(Table.Cliente usuario)
        {
            return db.DeleteAsync(usuario);
        }*/
    }
}
