using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        List<TEntity> Selecionar(Expression<Func<TEntity, bool>> where = null);
        TEntity SelecionarPorId(TKey id);
        void Inserir(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        void ExcluirPorId(TKey key);
    }
}
