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
        public ICollection<Reservation> Reservations { get; private set; }
        //public ICollection<Reservation> ToddlerReservations { get; private set; }
        public int DailyFeeChildren;
        public int DailyFeeToddlers;
        public int maxChildrenPerDay { get; set; }
        public int maxToddlersPerDay { get; set; }
        #endregion

        public Riebedebie()
        {
            Reservations = new List<Reservation>();
            //ToddlerReservations = new List<Reservation>();
        }

        public Reservation Reserveer(Child child, DateTime day, bool earlier, bool overtime)
        {
            int max;
            int price;
            switch (child.AgeCategory)
            {
                case AgeCategory.Child:
                    max = maxChildrenPerDay;
                    price = DailyFeeChildren;
                    break;
                case AgeCategory.Toddler:
                    max = maxToddlersPerDay;
                    price = DailyFeeToddlers;
                    break;
                default:
                    throw new ArgumentException("Only children or toddlers can register");
            }
            IEnumerable<Reservation> reservations = GetReservationsByDayByAgeCategory(day, child.AgeCategory);
            if (reservations.Count() >= max)
                throw new ArgumentException("The maximum number of people has been exceeded.");
            Reservation reservation = new Reservation() { Child = child, Date = day, Earlier = earlier, Later = overtime, PricePerDay = price, AfterHoursPrice = price/2 };
            Reservations.Add(reservation);
            //parent.AddReservation(reservation);
            return reservation;

        }

        private IEnumerable<Reservation> GetReservationsByDayByAgeCategory(DateTime day, AgeCategory? ageCategory)
        {
            return Reservations.Where(res => res.Child.AgeCategory.Equals(ageCategory)).Where(res => res.Date.Equals(day));
        }

       /* private IEnumerable<Reservation> GetToddlerReservationsByDay(DateTime day)
        {
            return ToddlerReservations.Where(res => res.Date.Equals(day));
        }*/
    }
}
