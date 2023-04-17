using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public enum OrderStatus
    {
        Draft = 1,
        Pending = 2,
        Confirmed = 3,
        Rejected = 4,
        Canceled = 5,
        Deleted = 6

    }
}
