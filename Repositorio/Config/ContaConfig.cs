using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public class ContaConfig : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ClienteId)
                .IsRequired();
            builder.Property(c => c.AgenciaId)
                .IsRequired();
            builder.Property(c => c.TipoConta)
                .IsRequired();
            builder.Property(c => c.NRConta)
                .IsRequired();
            builder.Property(c => c.Saldo)
                .IsRequired();
        }
    }
}
