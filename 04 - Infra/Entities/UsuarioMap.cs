using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTeste.Camadas.Domain.Models;

namespace SistemaTeste.Camadas.Infra.Data.Entities
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
