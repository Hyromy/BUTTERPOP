using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BUTTERPOP.modelo;
using System.Threading.Tasks;

using BUTTERPOP.db;

namespace BUTTERPOP.utils
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
        }
    }
}