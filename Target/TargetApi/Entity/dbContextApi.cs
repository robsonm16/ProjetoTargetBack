
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TargetApi.Entity
{
    public class dbContextApi : DbContext
    {
        public DbSet<tb_cli_cliente> tb_cli_cliente { get; set; }

        public dbContextApi(DbContextOptions<dbContextApi> opcoes)
            :base(opcoes)
        { }

        public dbContextApi()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            ConfiguraCliente(modelBuilder);
        }

        private void ConfiguraCliente(ModelBuilder construtor)
        {
            construtor.Entity<tb_cli_cliente>(etd=>
            {
                  etd.ToTable("tbCliente");
                  etd.HasKey(c => c.id).HasName("id");
                  etd.Property(c => c.id).HasColumnName("id").HasColumnType("uniqueidentifier");
                  etd.Property(c => c.nome).HasColumnName("nome").HasMaxLength(300);
                  etd.Property(c => c.endereco).HasColumnName("endereco").HasMaxLength(200);
                  etd.Property(c => c.numero).HasColumnName("numero").HasMaxLength(10);
                  etd.Property(c => c.bairro).HasColumnName("bairro").HasMaxLength(100);
            });                
        }
    }
}
