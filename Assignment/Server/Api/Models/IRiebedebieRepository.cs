using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IRiebedebieRepository
    {
        Riebedebie GetBy(int id);
        IEnumerable<Riebedebie> GetAll();
        Riebedebie GetByAgeCategory(AgeCategory ageCategory);

        void SaveChanges();
    }
}
