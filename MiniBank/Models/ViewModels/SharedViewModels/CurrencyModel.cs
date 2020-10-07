
using Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models.ViewModels.SharedViewModels
{
    public class CurrencyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
