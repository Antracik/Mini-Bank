using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Role Name")]
        [Required]
        public string Name { get; set; }
    }
}
