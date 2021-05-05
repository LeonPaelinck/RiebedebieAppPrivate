using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Data.Repositories
{
    public class RiebedebieRepository : IRiebedebieRepository
    {
        private readonly RiebedebieContext _context;
        private readonly DbSet<Riebedebie> _riebedebies;


        public RiebedebieRepository(RiebedebieContext context)
        {
            _context = context;
        }

        public Riebedebie getBy(int id)
        {
            return _context.Riebedebies.Where(r => r.Id == id).Include(r => r.Reservations).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
