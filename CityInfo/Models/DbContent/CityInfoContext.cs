using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Models.DbContent
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<PointOfInternet> Internet { get; set; } = null!;


        public CityInfoContext(DbContextOptions<CityInfoContext> options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Milano")
                {
                    Id = 1,
                    Description = "wwwww"
                },


                new City("Roma")
                {
                    Id = 2,
                    Description = "ssssss"
                }
                );

            modelBuilder.Entity<PointOfInternet>().HasData(

                new PointOfInternet("Duomo")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "bianco"
                },
                new PointOfInternet("Colosseo")
                {
                    Id = 2,
                    CityId = 2,
                    Description = "monument"
                }
                );

        }
    }
}
