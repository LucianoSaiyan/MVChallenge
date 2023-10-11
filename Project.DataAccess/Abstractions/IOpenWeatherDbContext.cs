using Project.Abtractions;
using Project.Entities.Model;

namespace Project.DataAccess.Abstractions
{
    public interface IOpenWeatherDbContext : IDbContext<OpenWeatherEntity>
    {
        Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city);
    }
}
