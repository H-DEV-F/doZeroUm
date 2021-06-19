using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired();
            builder.Property(c => c.Email)
                .IsRequired();
            builder.Property(c => c.CPFCNPJ)
                .IsRequired();
            builder.HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente);
        }
    }
}
