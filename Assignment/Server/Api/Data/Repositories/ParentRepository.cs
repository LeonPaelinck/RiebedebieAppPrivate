using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Data.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly RiebedebieContext _context;
        private readonly DbSet<Parent> _parents;

        public ParentRepository(RiebedebieContext dbContext)
        {
            _context = dbContext;
            _parents = dbContext.Parents;
        }

        public void Add(Parent parent)
        {
            _parents.Add(parent); 
        }

        public Parent GetBy(string email)
        {
            return _parents.Include(p => p.Children).SingleOrDefault(p => p.Email == email); //including meer of niet?
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
