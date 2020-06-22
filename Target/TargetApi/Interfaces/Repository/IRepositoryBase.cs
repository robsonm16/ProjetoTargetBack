using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetApi.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
