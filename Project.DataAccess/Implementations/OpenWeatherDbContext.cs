using Project.DataAccess.Abstractions;
using Project.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Implementations
{
    public class OpenWeatherDbContext : DbContext<OpenWeatherEntity>, IOpenWeatherDbContext
    {
        protected ApiDbContext _ctx;
        public OpenWeatherDbContext(ApiDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        #region Implemented Methods

        public async Task<List<OpenWeatherEntity>> GetOpenWeatherByCity(string city)
            => GetAll().Where(c => c.city == city).ToList();
        

        #endregion

    }
}
