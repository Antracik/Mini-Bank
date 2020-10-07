using System;
using System.Collections.Generic;
using System.Text;
using Shared;

namespace Services.Services.Implementations
{
    public class DateService : IDateService
    {
        public int MyProperty { get; set; }
        public void SetDateCreatedNow<T>(ref T item) where T : IBaseHistory
        {
            item.DateCreated = DateTime.Now;
            item.DateEdited = DateTime.Now;
        }

        public void SetDateEditedNow<T>(ref T item) where T : IBaseHistory
        {
            item.DateEdited = DateTime.Now;
        }

        public void ToLocalTime<T>(ref T item) where T : IBaseHistory
        {
            item.DateCreated = item.DateCreated.ToLocalTime();
            item.DateEdited = item.DateEdited.Value.ToLocalTime();
        }
    }
}
