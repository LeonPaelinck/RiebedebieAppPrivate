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
            _riebedebies = _context.Riebedebies;
        }

        public IEnumerable<Riebedebie> getAll()
        {
            return _riebedebies.AsNoTracking().ToList();
        }

        public Riebedebie getBy(int id)
        {
            return _riebedebies.Where(r => r.Id == id).Include(r => r.Reservations).FirstOrDefault();
        }

        public Reservation GetReservationBy(int riebedebieId, int id)
        {
            return getBy(riebedebieId).Reservations.Where(res => res.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
