using Mini_Bank.Models.ViewModels.SharedViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class TicketRequestViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 50 symbols")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Decription cannot be longer than 500 symbols")]
        public string Description { get; set; }

        [Required]
        public TicketTypeViewModel TicketType { get; set; }
    }
}
