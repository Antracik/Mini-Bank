using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IBaseHistory : IBaseModel
    {
        int? CreatedById { get; set; }
        DateTime DateCreated { get; set; }
        int? EditedById { get; set; }
        DateTime? DateEdited { get; set; }
    }
}
