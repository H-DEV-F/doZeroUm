using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class AgenciaConfig :IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Endereco)
                .IsRequired();
            builder.Property(a => a.Bairro)
                .IsRequired();
            builder.Property(a => a.Cidade)
                .IsRequired();
            builder.Property(a => a.Estado)
                .IsRequired();
            builder.Property(a => a.CEP)
                .IsRequired();
            builder.HasMany(a => a.Contas)
                .WithOne(a => a.Agencia);
        }
    }
}
