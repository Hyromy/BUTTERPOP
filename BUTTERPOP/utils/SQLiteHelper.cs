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

    /*
     * porfis apequense al diccionario de datos
     */

    public class Cliente
    {
        [PrimaryKey, MaxLength(50)]
        public string correo { get; set; }

        [MaxLength(50)]
        public string usuario { get; set; }

        [MaxLength(50)]
        public string password { get; set; }
    }

    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int id_lista { get; set; }
    }

    public class Administrador
    {
        [PrimaryKey]
        public string correo_admin { get; set; }
    }

    public class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int id_pelicula { get; set; }
    }

    /// <summary>
    /// Registros de renta de peliculas, solo necesita correo y id_pelicula
    /// </summary>
    public class Renta
    {
        [PrimaryKey, AutoIncrement]
        public int id_renta { get; set; }

        [MaxLength(50)]
        public string correo { get; set; }

        public int id_pelicula { get; set; }

        public DateTime fecha_renta { get; set; }

        public Renta()
        {
            this.fecha_renta = DateTime.Now;
        }
    }

    public class Comenta
    {
        [PrimaryKey, AutoIncrement]
        public int id_comentario { get; set; }
    }

    public class Contiene
    {
        [PrimaryKey, AutoIncrement]
        public int id_contiene { get; set; }
    }
}