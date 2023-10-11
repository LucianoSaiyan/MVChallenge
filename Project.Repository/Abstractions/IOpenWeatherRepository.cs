using Project.Abtractions;
using Project.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Abstractions
{
    public interface IOpenWeatherRepository : IRepository<OpenWeatherEntity>
    {
        Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city);
    }
}
