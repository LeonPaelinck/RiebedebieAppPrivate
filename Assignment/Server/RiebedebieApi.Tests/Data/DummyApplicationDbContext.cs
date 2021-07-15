using RiebedebieApi.Models;
using System;

namespace RiebedebieApi.Tests.Data
{
    public class DummyApplicationDbContext
    {
        public Child Kleuter { get; set; }
        public Child Kind { get; set; }
        public Child Tiener { get; set; }
        public Parent Parent1 { get; private set; }

        public Riebedebie Kinderwerking { get; private set; }

        public DummyApplicationDbContext()
        {
            Kleuter = new Child("Joosens", "Set", DateTime.Now.AddYears(-4));
            Kind = new Child("Joosens", "Chris", DateTime.Now.AddYears(-8));
            Tiener = new Child("Joosens", "Staf", DateTime.Now.AddYears(-13));

            Parent1 = new Parent { Email = "parent@stekene.be", FirstName = "John", LastName = "Doe" };

            Kinderwerking = new Riebedebie() { DailyFee = 4.00M, Name = "Kinderwerking", AgeCategory = AgeCategory.Child, MaxChildrenPerDay = 100 };

        }
    }
}
