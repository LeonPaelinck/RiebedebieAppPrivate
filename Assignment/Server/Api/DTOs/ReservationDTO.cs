using System;
using System.ComponentModel.DataAnnotations;
namespace RecipeApi.DTOs
{
    public class ReservationDTO
    {
        [Required]
        public string Date { get; set; }
        public string Earlier { get; set; }
        public string Later { get; set; }

    }
}