using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IDateService
    {
        void ToLocalTime<T>(ref T item) where T : IBaseHistory;
        void SetDateCreatedNow<T>(ref T item) where T : IBaseHistory;
        void SetDateEditedNow<T>(ref T item) where T : IBaseHistory;
    }
}
