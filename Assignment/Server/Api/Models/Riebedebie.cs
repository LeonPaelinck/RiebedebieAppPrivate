﻿using System;
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
        public ICollection<Reservation> Reservations { get; private set; }
        //public ICollection<Reservation> ToddlerReservations { get; private set; }
        public decimal DailyFee;
        public int MaxChildrenPerDay { get; set; }
        #endregion

        public Riebedebie()
        {
            Reservations = new List<Reservation>();
            //ToddlerReservations = new List<Reservation>();
        }

        public Reservation Register(Child child, DateTime day, bool earlier, bool overtime)
        {
            IEnumerable<Reservation> reservations = GetReservationsByDay(day);
            if (reservations.Count() >= MaxChildrenPerDay)
                throw new ArgumentException("The maximum number of people has been exceeded.");
            if (reservations.Any(res => res.Child.Equals(child)))
                throw new ArgumentException("This child has already been registered on that day");
            Reservation reservation = new Reservation() { Child = child, Date = day, Earlier = earlier, Later = overtime, PricePerDay = DailyFee, AfterHoursPrice = DailyFee/2 };
            Reservations.Add(reservation);
            //parent.AddReservation(reservation);
            return reservation;

        }

        public int howManyReservationsLeft(DateTime date, Child child)
        {
            return MaxChildrenPerDay - GetReservationsByDay(date).Count();
        }

        private IEnumerable<Reservation> GetReservationsByDay(DateTime day)
        {
            return Reservations.Where(res => res.Date.Equals(day));
        }

       /* private IEnumerable<Reservation> GetToddlerReservationsByDay(DateTime day)
        {
            return ToddlerReservations.Where(res => res.Date.Equals(day));
        }*/
    }
}