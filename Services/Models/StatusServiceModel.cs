
using Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class StatusServiceModel : IBaseModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
