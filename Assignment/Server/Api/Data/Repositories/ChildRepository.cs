using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Data.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly RiebedebieContext _context;
        private readonly DbSet<Child> _children;
        public ChildRepository(RiebedebieContext context)
        {
            _context = context;
            _children = context.Children;
        }

        public void Add(Child child)
        {
            _children.Add(child);
        }

        public void Delete(Child child)
        {
            _children.Remove(child);
        }

        public IEnumerable<Child> GetAll()
        {
            return _children.ToList();
        }

        public Child GetBy(int id)
        {
            return _children.FirstOrDefault(k => k.Id.Equals(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetChild(int id, out Child child)
        {
            child = _children.FirstOrDefault(k => k.Id == id);
            return child != null;
        }

        public void Update(Child child)
        {
            _context.Update(child);
        }
    }
}
