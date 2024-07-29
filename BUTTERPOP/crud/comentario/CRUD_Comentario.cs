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
        public async Task<List<Table.Comenta>> GetComentariosAsync()
        {
            return await db.Table<Table.Comenta>().ToListAsync();
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
        */
        public Task<int> UpdateComentarioAsync(Table.Comenta comentario)
        {
            if (comentario.Comentario != null)
            {
                return db.UpdateAsync(comentario);
            }
            else
            {
                return null;
            }
        }

        public Task<int> DeleteComentarioByIDAsync(int idcom)
        {
            return db.Table<Table.Comenta>().DeleteAsync(c => c.id_comentario == idcom);
        }





        public Task<List<Table.Comenta>> GetCommentsByMovieIdAsync(int movieId)
        {
            return db.Table<Table.Comenta>()
                            .Where(c => c.id_pelicula == movieId)
                            .ToListAsync();
        }




    }
}
