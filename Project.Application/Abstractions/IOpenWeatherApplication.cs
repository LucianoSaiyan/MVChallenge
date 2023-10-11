using Project.Abtractions;
using Project.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions
{
    public interface IOpenWeatherApplication : IApplication<OpenWeatherEntity>
    {
        Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city);
    }
}
