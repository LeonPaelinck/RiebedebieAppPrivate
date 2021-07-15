using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll(int childId);
        Reservation GetBy(int id);

        void Add(Reservation reservation);

        void SaveChanges();
    }
}
