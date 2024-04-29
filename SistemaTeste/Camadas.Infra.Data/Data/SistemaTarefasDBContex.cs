using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using SistemaTeste.Camadas.Domain.Models;
using SistemaTeste.Camadas.Infra.Data.Entities;

namespace SistemaTeste.Camadas.Infra.Data.Data
{
    public class SistemaTarefasDBContex : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<UsuarioModel> usuarios { get; set; }

        public SistemaTarefasDBContex(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var typedatabase = _configuration["typedatabase"];
            var connectionString = _configuration.GetConnectionString(typedatabase);

            if (typedatabase == "Mysql")
            {
                optionsBuilder.UseMySQL(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);

        }

    }
}
