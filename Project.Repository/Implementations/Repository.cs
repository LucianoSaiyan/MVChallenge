using Project.Abtractions;
using Project.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        IDbContext<T> _ctx;
        public Repository(IDbContext<T> ctx)
        {
            _ctx = ctx;
        }

        #region Call Methods DbContext

        public IList<T> GetAll()
        {
            return _ctx.GetAll();
        }

        public async Task<IList<T>> GetAllAsync()
        {

            return await _ctx.GetAllAsync();
        }

        public T GetById(int id)
        {
            return _ctx.GetById(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _ctx.GetByIdAsync(id);
        }

        public Tuple<int, T> Save(T entity)
        {
            return _ctx.Save(entity);
        }

        public Task<Tuple<int, T>> SaveAsync(T entity)
        {
            return _ctx.SaveAsync(entity);
        }

        int ICrud<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> ICrudAsync<T>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        int ICrud<T>.Update(T entity)
        {
            return _ctx.Update(entity);
        }

        Task<int> ICrudAsync<T>.UpdateAsync(T entity)
        {
            return _ctx.UpdateAsync(entity);
        }

        Tuple<int, T> ICrud<T>.UpdateReturnResult(T entity)
        {
            return _ctx.UpdateReturnResult(entity);
        }

        Task<Tuple<int, T>> ICrudAsync<T>.UpdateReturnResultAsync(T entity)
        {
            return _ctx.UpdateReturnResultAsync(entity);
        }

        #endregion
    }
}
