using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Data.Repositories
{
    public class KindRepository : IKindRepository
    {
        private readonly RiebedebieContext _context;
        private readonly DbSet<Kind> _kinderen;
        public KindRepository(RiebedebieContext context)
        {
            _context = context;
            _kinderen = context.Kinderen;
        }

        public void Add(Kind kind)
        {
            _kinderen.Add(kind);
        }

        public void Delete(Kind kind)
        {
            _kinderen.Remove(kind);
        }

        public IEnumerable<Kind> GetAll()
        {
            return _kinderen.ToList().OrderBy(k => k.LastName).ThenBy(k => k.BirthDate);
        }

        public Kind GetBy(int id)
        {
            return _kinderen.FirstOrDefault(k => k.Id.Equals(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetKind(int id, out Kind kind)
        {
            kind = _kinderen.FirstOrDefault(k => k.Id == id);
            return kind != null;
        }

        public void Update(Kind kind)
        {
            _context.Update(kind);
        }
    }
}
