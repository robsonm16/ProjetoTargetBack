using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TargetApi.Entity;
using TargetApi.Interfaces.Repository;

namespace TargetApi.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlConnection conn;
        protected readonly dbContextApi db;

        public RepositoryBase()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            conn = new SqlConnection(config.GetConnectionString("defaut"));

            db = new dbContextApi();
            db.Database.SetCommandTimeout(0);
        }

        public void Adicionar(TEntity obj)
        {
            db.ChangeTracker.AutoDetectChangesEnabled = false;
            db.Add(obj);
            db.SaveChanges();
        }


        public void Atualizar(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            
        }     

        public void Remover(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
            
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
