using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;


        public RiebedebieDataInitializer(RiebedebieContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                Parent parent1 = new Parent { Email = "parent@stekene.be", FirstName = "John", LastName = "Doe" };
                _dbContext.Parents.Add(parent1);
                await CreateUser(parent1.Email, "P@ssword1111");

                Child child1 = new Child() { FirstName = "Chiara", LastName = "Van Campe", BirthDate = new DateTime(1999, 6, 14) };
                Child child2 = new Child() { FirstName = "Zjef", LastName = "Goethals", BirthDate = new DateTime(2008, 5, 6) };
                Child child3 = new Child() { FirstName = "Victor", LastName = "Robbrecht", BirthDate = new DateTime(2010, 10, 4) };
                Child child4 = new Child() { FirstName = "Wouter", LastName = "Denissen", BirthDate = new DateTime(2018, 8, 8) };

                parent1.AddChild(child2);
                parent1.AddChild(child3);
                parent1.AddChild(child4);

                var kinderen = new List<Child>
                {
                     child1,
                     child2,
                     child3,
                     child4,
                     new Child() { FirstName = "Amélie", LastName = "De Kimpe", BirthDate = new DateTime(2019, 6, 14)}
                };
                _dbContext.Children.AddRange(kinderen);

                Riebedebie kinderwerking = new Riebedebie() { DailyFee = 4.00M, Name = "Kinderwerking", AgeCategory = AgeCategory.Child, MaxChildrenPerDay = 100};
                Riebedebie kleuterwerking = new Riebedebie() { DailyFee = 4.00M, Name = "Kleuterwerking", AgeCategory = AgeCategory.Toddler, MaxChildrenPerDay = 50 };
                Riebedebie tienerwerking = new Riebedebie() { DailyFee = 4.00M, Name = "Kleuterwerking", AgeCategory = AgeCategory.Teenager, MaxChildrenPerDay = 20 };
                var riebedebies = new List<Riebedebie> { kinderwerking, kleuterwerking, tienerwerking };

                _dbContext.Riebedebies.AddRange(riebedebies);


                Reservation res3 = kinderwerking.Register(parent1, child3, new DateTime(2021, 07, 21), true, false);
                Reservation res4 = kleuterwerking.Register(parent1, child4, new DateTime(2021, 07, 20), false, false);



                _dbContext.SaveChanges();

                Parent parent1 = new Parent { Email = "parent@stekene.be", FirstName = "John", LastName = "Doe" };
                parent1.AddChild(child2);
                parent1.AddChild(child3);
                parent1.AddChild(child4);
                _dbContext.Parents.Add(parent1);
                await CreateUser(parent1.Email, "P@ssword1111");

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
