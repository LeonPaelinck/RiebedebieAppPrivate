using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IRiebedebieRepository
    {
        Riebedebie getBy(int id);
        IEnumerable<Riebedebie> getAll();
        Reservation GetReservationBy(int riebedebieId, int id);
        void SaveChanges();
    }
}
