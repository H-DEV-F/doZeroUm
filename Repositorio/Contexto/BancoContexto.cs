using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class BancoContexto : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Contato> Contatos { get; set; }
        DbSet<Conta> Conta { get; set; }

        public BancoContexto(DbContextOptions options) : base(options) {}
    }
}
