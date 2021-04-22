using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IChildRepository
    {
        Child GetBy(int id);
        bool TryGetChild(int id, out Child child);
        IEnumerable<Child> GetAll();
        void Add(Child child);
        void Delete(Child child);
        void Update(Child child);
        void SaveChanges();
    }
}
