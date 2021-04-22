using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Data
{
    public class RiebedebieDataInitializer
    {
        private readonly RiebedebieContext _dbContext;

        public RiebedebieDataInitializer(RiebedebieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                var kinderen = new List<Kind>
                {
                     new Kind() { FirstName = "Chiara", LastName = "Van Campe", BirthDate = new DateTime(1999, 6, 14)},
                     new Kind() { FirstName = "Zjef", LastName = "Goethals", BirthDate = new DateTime(2008, 5, 6)},
                     new Kind() { FirstName = "Victor", LastName = "Robbrecht", BirthDate = new DateTime(2010, 10, 4)},
                     new Kind() { FirstName = "Wouter", LastName = "Denissen", BirthDate = new DateTime(2018, 8, 8)},
                     new Kind() { FirstName = "Amélie", LastName = "De Kimpe", BirthDate = new DateTime(2019, 6, 14)}
                };

                _dbContext.Kinderen.AddRange(kinderen);

                _dbContext.SaveChanges();
            }
        }
    }
}
