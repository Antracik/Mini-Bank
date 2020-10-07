using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class TransactionTypeEntityModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
