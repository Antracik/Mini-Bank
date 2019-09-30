using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class TicketMessageViewModel
    {
        [Required(ErrorMessage = "Message cannot be empty!")]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        public int SentById { get; set; }

        public DateTime DateSent { get; set; }
    }
}
