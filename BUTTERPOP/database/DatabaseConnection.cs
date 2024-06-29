using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace BUTTERPOP.database
{
    public class DatabaseConnection
    {
        private static SQLiteConnection db;

        public static SQLiteConnection GetConnection()
        {
            if (db == null)
            {
                var dbPath = "butterpop.db";
                db = new SQLiteConnection(dbPath);

                db.CreateTable<Cliente>();
                db.CreateTable<Lista>();
                db.CreateTable<Administrador>();
                db.CreateTable<Pelicula>();
                db.CreateTable<Renta>();
                db.CreateTable<Comenta>();
                db.CreateTable<Contiene>();
            }

            return db;
        }
    }
}