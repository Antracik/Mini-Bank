using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Queries
{
    public class NewUsersIn30Days : BaseQuery, IBaseModel
    {
        [NotMapped]
        public int Id { get; set; }

        public int UserCount { get; set; }
        public int Day { get; set; }
    }

    public static class NewUsersIn30DaysExtension
    {
        public static string GetQuery(this NewUsersIn30Days item)
        {
            return @"SELECT 
                      COUNT(Id) AS UserCount, 
                      DATEDIFF(DAY, DateCreated, GETDATE()) AS [Day] 
                      FROM AspNetUsers
                      WHERE DATEDIFF(DAY, DateCreated, GETDATE())  BETWEEN 0 AND 29
                      GROUP BY DATEDIFF(DAY, DateCreated, GETDATE())
                      ORDER BY DATEDIFF(DAY, DateCreated, GETDATE())";
        }
    }
}
