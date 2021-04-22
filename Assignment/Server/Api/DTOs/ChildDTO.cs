using System;
using System.ComponentModel.DataAnnotations;
namespace RecipeApi.DTOs
{
    public class ChildDTO
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}