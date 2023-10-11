using Project.Abtractions;
using Project.Application.Abstractions;
using Project.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Implementations
{
    public class Application<T> : IApplication<T> where T : IEntity
    {
        IRepository<T> _repository;
        //esta inyeccion se encuentra en el "contenedor"
        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }

        #region Methods Repository

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Tuple<int,T> Save(T entity)
        {
            return _repository.Save(entity);
        }

        public async Task<Tuple<int, T>> SaveAsync(T entity)
        {
            return await _repository.SaveAsync(entity);
        }

        int ICrud<T>.Update(T entity)
        {
            return _repository.Update(entity);
        }

        Task<int> ICrudAsync<T>.UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }

        Tuple<int, T> ICrud<T>.UpdateReturnResult(T entity)
        {
            return _repository.UpdateReturnResult(entity);
        }

        Task<Tuple<int, T>> ICrudAsync<T>.UpdateReturnResultAsync(T entity)
        {
            return _repository.UpdateReturnResultAsync(entity);
        }

        #endregion
    }
}
