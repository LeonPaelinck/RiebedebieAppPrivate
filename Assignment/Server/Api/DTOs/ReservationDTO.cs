using System;
using System.ComponentModel.DataAnnotations;
namespace RecipeApi.DTOs
{
    public class ReservationDTO
    {
        [Required]
        public string Date { get; set; }
        public bool Earlier { get; set; }
        public bool Later { get; set; }

    }
}