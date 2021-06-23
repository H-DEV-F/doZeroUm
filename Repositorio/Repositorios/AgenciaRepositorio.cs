using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;

namespace Repositorio.Repositorios
{
    public class AgenciaRepositorio : BaseRepositorio<Agencia>, IAgenciaRepositorio
    {
        public AgenciaRepositorio(BancoContexto bancoContexto) : base(bancoContexto) {}
    }
}
