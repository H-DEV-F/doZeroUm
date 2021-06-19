using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class AgenciaRepositorio : BaseRepositorio<Agencia>, IAgenciaRepositorio
    {
        public AgenciaRepositorio(BancoContexto bancoContexto) : base(bancoContexto) {}
    }
}
