using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly BancoContexto CirclesPratasContexto;

        public BaseRepositorio(BancoContexto circlesPratasContexto)
        {
            CirclesPratasContexto = circlesPratasContexto;
        }

        public void Adicionar(TEntity entity)
        {
            CirclesPratasContexto.Set<TEntity>().Add(entity);
            CirclesPratasContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            CirclesPratasContexto.Set<TEntity>().Update(entity);
            CirclesPratasContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return CirclesPratasContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return CirclesPratasContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            CirclesPratasContexto.Remove(entity);
            CirclesPratasContexto.SaveChanges();
        }

        public void Dispose()
        {
            CirclesPratasContexto.Dispose();
        }
    }
}
