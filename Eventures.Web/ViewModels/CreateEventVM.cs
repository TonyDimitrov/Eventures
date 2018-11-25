
using Eventures.Web.Utils.CustomAtributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventures.Web.ViewModels
{
    public class CreateEventVM
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        [MinLength(5)]
        public string Place { get; set; }

        [NoZeroPositiveNumber(ErrorMessage = "Invalid number!")]
        public int TotalTickets { get; set; }

        [NoZeroPositiveNumber(ErrorMessage = "Invalid number!")]
        public decimal PricePerTicket { get; set; }
    }
}
