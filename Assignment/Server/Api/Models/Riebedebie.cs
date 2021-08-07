using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public class Riebedebie
    {
        #region Properties
        public int Id { get; set; }
        public String Name { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public decimal DailyFee;
        public int MaxChildrenPerDay { get; set; }
        #endregion

        public Riebedebie()
        {
            Reservations = new List<Reservation>();
            //ToddlerReservations = new List<Reservation>();
        }

        public Reservation Register(Parent parent, Child child, DateTime day, bool earlier, bool overtime)
        {
            IEnumerable<Reservation> reservations = Reservations.Where(res => res.Date.Date.Equals(day));
            if (reservations.Count() >= MaxChildrenPerDay)
                throw new ArgumentException("The maximum number of people has been exceeded.");
            if (reservations.Any(res => res.Child.Equals(child)))
                throw new ArgumentException("This child has already been registered on that day");
            Reservation reservation = new Reservation() { Child = child, Date = day, Earlier = earlier, Later = overtime, PricePerDay = DailyFee, AfterHoursPrice = DailyFee/2 };
            
            Reservations.Add(reservation);
            parent.AddReservation(reservation);
           
            return reservation;

        }

        /*
        public int HowManyReservationsLeft(DateTime date, Child child)
        {
            return MaxChildrenPerDay - GetReservationsByDay(date).Count();
        }

        public bool AlreadyRegistered(DateTime date, Child child)
        {
            return GetReservationsByDay(date).Where(r => r.Child.Equals(child)).Count() >= 1;
        }*/

        /*
        private IEnumerable<Reservation> GetReservationsByDay(DateTime day)
        {
            return Reservations.Where(res => res.Date == day);
        } */

       /* private IEnumerable<Reservation> GetToddlerReservationsByDay(DateTime day)
        {
            return ToddlerReservations.Where(res => res.Date.Equals(day));
        }*/
    }
}
