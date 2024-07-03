using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BUTTERPOP.modelo;
using System.Threading.Tasks;


namespace BUTTERPOP.utils
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Usuarios>().Wait();
        }

        public Task <int> SaveUsuarioAsync(Usuarios usuario)
        {
            if (usuario.correo != null)
            {
                return db.InsertAsync(usuario);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Recuperar todos los usuarios
        /// </summary>
        /// <returns></returns>
        public Task<List<Usuarios>> GetUsuariosAsync() { 
            return db.Table<Usuarios>().ToListAsync();
        }

        /// <summary>
        /// Recuperar usuarios por correo
        /// </summary>
        /// <param name="correo">correo del alumno que se requiere</param>
        /// <returns></returns>

        public Task<Usuarios> GetUsuariosByCorreo(string correo)
        {
            return db.Table<Usuarios>().Where(a => a.correo == correo).FirstOrDefaultAsync();   
        }

        public Task<int> UpdateUsuarioAsync(Usuarios usuario)
        {
            return db.UpdateAsync(usuario);
        }

        public Task<int> DeleteUsuarioAsync(Usuarios usuario)
        {
            return db.DeleteAsync(usuario);
        }






    }
}
