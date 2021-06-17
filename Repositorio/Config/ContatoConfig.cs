using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ClienteId);
            builder.Property(c => c.TipoContato)
                .IsRequired();
            builder.Property(c => c.Telefone)
                .IsRequired();
        }
    }
}
