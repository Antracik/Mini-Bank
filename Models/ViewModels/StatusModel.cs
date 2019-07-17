using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models
{
    public class StatusModel
    {
        public enum Status
        {
            Okay,
            AwaitingAuthorization,
            Blocked
        }

    }
}
