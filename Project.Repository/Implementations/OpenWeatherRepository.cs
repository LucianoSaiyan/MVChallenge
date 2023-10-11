using Project.Abtractions;
using Project.DataAccess.Abstractions;
using Project.Entities.Model;
using Project.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Implementations
{

    public class OpenWeatherRepository : Repository<OpenWeatherEntity>, IOpenWeatherRepository
    {
        IOpenWeatherDbContext _ctx;

        public OpenWeatherRepository(IOpenWeatherDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }


        public async Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city)
            => await _ctx.GetOpenWeatherByCity(city); 

    }
}
