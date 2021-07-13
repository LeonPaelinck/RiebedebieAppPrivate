using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public class Child
    {
        private DateTime _birthDate;

        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Birthdate cannot be in the future");
                _birthDate = value;
            }
        }

        //public ICollection<Reservation> Reservations { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public AgeCategory AgeCategory 
        { 
            get 
            {
                if (Age < 3)
                    return AgeCategory.TooYoung;
                else if (Age < 6)
                    return AgeCategory.Toddler;
                else if (Age < 12)
                    return AgeCategory.Child;
                else if (Age < 16)
                    return AgeCategory.Teenager;
                else
                    return AgeCategory.Adult;
            }
        }

        /*public void AddReservation(Reservation reservation)
        {
            if (Reservations.Any(res => res.Date.Equals(reservation.Date)))
                throw new ArgumentException("There is already a reservation on " + reservation.Date.ToString());
            Reservations.Add(reservation);
        }*/

        public Child()
        {

        }

        public Child(string lastName, string firstName, DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year >= 16)
                throw new ArgumentException("This child is too old ");
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }

    }
}
