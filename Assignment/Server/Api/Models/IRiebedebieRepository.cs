using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    interface IRiebedebieRepository
    {
        Riebedebie getBy(int id);
        void SaveChanges();
    }
}
