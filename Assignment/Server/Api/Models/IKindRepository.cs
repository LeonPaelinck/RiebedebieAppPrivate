using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IKindRepository
    {
        Kind GetBy(int id);
        bool TryGetKind(int id, out Kind kind);
        IEnumerable<Kind> GetAll();
        void Add(Kind kind);
        void Delete(Kind kind);
        void Update(Kind kind);
        void SaveChanges();
    }
}
