using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IParentRepository
    {
        Parent GetBy(string email);
        void Add(Parent parent);
        void SaveChanges();
    }
}
