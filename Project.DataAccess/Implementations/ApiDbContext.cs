using Project.Abtractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities.Model;

namespace Project.DataAccess.Implementations
{
    public class ApiDbContext : DbContext
    {
        #region DbSets

        public DbSet<OpenWeatherEntity> OpenWeather { get; set; }

        #endregion

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ignorara la clase Entity para que no genere una clase
            modelBuilder.Ignore<Entity>();
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
