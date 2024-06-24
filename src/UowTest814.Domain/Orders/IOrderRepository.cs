﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace UowTest814.Orders
{
    public interface IOrderRepository : IBasicRepository<Order, Guid>
    {
        Task<Order> GetBookByIdAsync(Guid id);
    }
}
