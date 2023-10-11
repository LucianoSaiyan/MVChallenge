using Project.Abtractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Implementations
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        //objeto del dominio que utilizara para acceder a los datos
        DbSet<T> _entity;

        protected ApiDbContext _ctx;
        int result;

        public DbContext(ApiDbContext ctx)
        {
            //setea los datos que se obtiene para usar el contexto de los datos
            _ctx = ctx;

            _entity = ctx.Set<T>();
            result = 0;
        }

        #region Saves

        public Tuple<int, T> Save(T entity)
        {
            _entity.Add(entity);
            int result = _ctx.SaveChanges();
            return new Tuple<int, T>(result, entity);
        }

        public async Task<Tuple<int, T>> SaveAsync(T entity)
        {
            await _entity.AddAsync(entity);
            int result = await _ctx.SaveChangesAsync();
            return new Tuple<int, T>(result, entity);
        }
        #endregion

        #region Updates

        Tuple<int, T> UpdateReturnResult(T entity)
        {
            _entity.Update(entity);
            result = _ctx.SaveChanges();
            return new Tuple<int, T>(result, GetById(entity.Id));
        }
        
        async Task<Tuple<int, T>> UpdateReturnResultAsync(T entity)
        {
            _entity.Update(entity);
            result = await _ctx.SaveChangesAsync();
            return new Tuple<int, T>(result, GetById(entity.Id));
        }

        int ICrud<T>.Update(T entity)
        {
            _entity.Update(entity);
            result = _ctx.SaveChanges();
            return result;
        }

        Tuple<int, T> ICrud<T>.UpdateReturnResult(T entity)
        {
            throw new NotImplementedException();
        }

        Task<int> ICrudAsync<T>.UpdateAsync(T entity)
        {
            _entity.Update(entity);
            Task<int> result = _ctx.SaveChangesAsync();
            return result;
        }

        Task<Tuple<int, T>> ICrudAsync<T>.UpdateReturnResultAsync(T entity)
        {
            throw new NotImplementedException();
            //_entity.Update(entity);
            //var result = await _ctx.SaveChangesAsync();
            //return  new Tuple<int, T>(result, GetById(entity.Id));
        }
        #endregion

        #region Delete
        public int Delete(int id)
        {
            result = 0;
            T? tmp = _entity.Find(id);
            if (tmp != null)
            {
                _entity.Remove(tmp);
                result = _ctx.SaveChanges();
            }
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            T? tmp = _entity.Find(id);
            if (tmp != null)
            {
                _entity.Remove(tmp);
                result = await _ctx.SaveChangesAsync();
            }
            return result;
        }

        #endregion

        #region Gets
        public IList<T> GetAll()
        {
            return _entity.ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }
        #endregion

    }
}
