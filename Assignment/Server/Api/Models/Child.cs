using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Models
{
    public class Child
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public AgeCategory AgeCategory 
        { 
            get 
            {
                if (Age < 3)
                   return AgeCategory.Peuter;
                else if (this.Age < 6)
                   return AgeCategory.Kleuter;
                else if (this.Age < 12)
                   return AgeCategory.Kind;
                else if (this.Age < 16)
                   return AgeCategory.Tiener;
                else
                   return AgeCategory.Animator;
            }
        }


        public Child()
        {

        }

        public Child(string lastName, string firstName, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }

    }
}
