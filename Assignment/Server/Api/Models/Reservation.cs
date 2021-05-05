using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Child Child;
        public DateTime Date { get; set; }
        public bool Earlier { get; set; }
        public bool Later { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal AfterHoursPrice { get; set; } 
        public decimal Price
        {
            get
            {
                decimal price = PricePerDay;
                if (Earlier) price += AfterHoursPrice;
                if (Later) price += AfterHoursPrice;
                return price;
            }
        }


    }
}
