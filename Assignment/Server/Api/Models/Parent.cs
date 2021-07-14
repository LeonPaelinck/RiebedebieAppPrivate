using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public class Parent
    {
        #region Properties
        //add extra properties if needed
        public int ParentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Child> Children { get; private set; }

        public ICollection<Reservation> Reservations { get; private set; }
        #endregion

        #region Constructors
        public Parent()
        {
            Children = new List<Child>();
            Reservations = new List<Reservation>();
        }
        #endregion

        #region Methods
        public void AddChild(Child child)
        {
            Children.Add(child);
        }

        public void DeleteChild(Child child)
        {
            Children.Remove(child);
        }
        public void AddReservation(Reservation res)
        {
            Reservations.Add(res);
        }
        #endregion
    }
}
