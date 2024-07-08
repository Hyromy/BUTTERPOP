﻿using BUTTERPOP.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using BUTTERPOP.utils;
using BUTTERPOP.db;
using System.IO;

namespace BUTTERPOP.crud.usuario
{
    internal class CRUD_Usuario
    {
        private SQLiteAsyncConnection db;
        public CRUD_Usuario()
        {
            this.db = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ButterPop.db3"));
            this.db.CreateTableAsync<Table.Cliente>().Wait();
        }

        public Task<int> SaveUsuarioAsync(Table.Cliente usuario)
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
        public Task<List<Table.Cliente>> GetUsuariosAsync()
        {
            return db.Table<Table.Cliente>().ToListAsync();
        }

        /// <summary>
        /// Recuperar usuarios por correo
        /// </summary>
        /// <param name="correo">correo del alumno que se requiere</param>
        /// <returns></returns>
        public Task<Table.Cliente> GetUsuariosByCorreo(string correo)
        {
            return db.Table<Table.Cliente>().Where(a => a.correo == correo).FirstOrDefaultAsync();
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
        }
    }
}