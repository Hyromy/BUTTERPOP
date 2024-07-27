using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BUTTERPOP.db
{
    public class SQLiteHelper
    {
        private SQLiteAsyncConnection db;

        public SQLiteHelper()
        {
            String dbName = "ButterPop.db3";
            String dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
            this.db = new SQLiteAsyncConnection(dbpath);

            this.db.CreateTableAsync<Table.Cliente>().Wait();
            this.db.CreateTableAsync<Table.Lista>().Wait();
            this.db.CreateTableAsync<Table.Pelicula>().Wait();
            this.db.CreateTableAsync<Table.Renta>().Wait();
            this.db.CreateTableAsync<Table.Comenta>().Wait();
            this.db.CreateTableAsync<Table.Contiene>().Wait();
        }

        public SQLiteAsyncConnection getConnection()
        {
            return this.db;
        }
    }
}