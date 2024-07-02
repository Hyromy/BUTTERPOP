using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using SQLite;

namespace BUTTERPOP.database
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "butterpop.db");
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Conexión a la base de datos establecida con éxito.");

            db.Execute("PRAGMA foreign_keys = ON;");
            Console.WriteLine("Claves foráneas activadas con éxito.");

            db.CreateTable<Cliente>();
            Console.WriteLine("Tabla 'cliente' creada con éxito.");

            db.CreateTable<Lista>();
            Console.WriteLine("Tabla 'lista' creada con éxito.");

            db.CreateTable<Administrador>();
            Console.WriteLine("Tabla 'administrador' creada con éxito.");

            db.CreateTable<Pelicula>();
            Console.WriteLine("Tabla 'pelicula' creada con éxito.");

            db.CreateTable<Renta>();
            Console.WriteLine("Tabla 'renta' creada con éxito.");

            db.CreateTable<Comenta>();
            Console.WriteLine("Tabla 'comenta' creada con éxito.");

            db.CreateTable<Contiene>();
            Console.WriteLine("Tabla 'contiene' creada con éxito.");
        }
    }

    //falta definir
    public class Cliente
    {
        [PrimaryKey]
        public string correo { get; set; }
    }

    //falta definir
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int id_lista { get; set; }
    }

    //falta definir
    public class Administrador
    {
        [PrimaryKey]
        public string correo_admin { get; set; }
    }

    //falta definir
    public class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int id_pelicula { get; set; }
    }

    public class Renta
    {
        [PrimaryKey, AutoIncrement]
        public int id_renta { get; set; }

        // Clave foránea de la tabla 'cliente'.correo
        public string correo { get; set; }
        
        // Clave foránea de la tabla 'pelicula'.id_pelicula
        public int id_pelicula { get; set; }
        
        public DateTime fecha_renta { get; set; }
    }

    //falta definir
    public class Comenta
    {
        [PrimaryKey, AutoIncrement]
        public int id_comentario { get; set; }
    }

    //falta definir
    public class Contiene
    {
        [PrimaryKey, AutoIncrement]
        public int id_contiene { get; set; }
    }
}