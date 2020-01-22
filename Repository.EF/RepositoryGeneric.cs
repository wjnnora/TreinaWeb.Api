using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected DbContext _context;
        public RepositoryGeneric(DbContext context)
        {
            _context = context;
        }
        public void Atualizar(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(TKey key)
        {
            TEntity entity = SelecionarPorId(key);
            Excluir(entity);
        }

        public void Inserir(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public List<TEntity> Selecionar(Expression<Func<TEntity, bool>> where = null)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            if (where == null)
                return dbSet.ToList();
            else
                return dbSet.Where(where).ToList();
        }

        public TEntity SelecionarPorId(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
