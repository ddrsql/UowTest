using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowTest814.Orders;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UowTest814.EntityFrameworkCore.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<UowTest814DbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(IDbContextProvider<UowTest814DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Order> GetBookByIdAsync(Guid id)
        {
            return await (await GetDbSetAsync()).Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }
}
