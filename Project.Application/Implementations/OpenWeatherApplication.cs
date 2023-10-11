using Project.Abtractions;
using Project.Application.Abstractions;
using Project.Entities.Model;
using Project.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Implementations
{
    public class OpenWeatherApplication : Application<OpenWeatherEntity>, IOpenWeatherApplication
    {
        IOpenWeatherRepository _openWeatherRepository;

        public OpenWeatherApplication(IOpenWeatherRepository openWeatherRepository)
                            : base(openWeatherRepository)
        {
            _openWeatherRepository = openWeatherRepository;
        }


        #region Methods Repository

        #region Delete

        public int Delete(int id)
        {
            return _openWeatherRepository.Delete(id);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _openWeatherRepository.DeleteAsync(id);
        }

        #endregion

        #region GetAll

        public IList<OpenWeatherEntity> GetAll()
        {
            return _openWeatherRepository.GetAll();
        }

        public async Task<IList<OpenWeatherEntity>> GetAllAsync()
        {
            return await _openWeatherRepository.GetAllAsync();
        }

        #endregion

        #region Gets

        public OpenWeatherEntity GetById(int id)
            => _openWeatherRepository.GetById(id);
        
        public async Task<OpenWeatherEntity> GetByIdAsync(int id)
            => await _openWeatherRepository.GetByIdAsync(id);
               
        public async Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city)
            => await _openWeatherRepository.GetOpenWeatherByCity(city);
        
        #endregion

        #endregion
    }
}
