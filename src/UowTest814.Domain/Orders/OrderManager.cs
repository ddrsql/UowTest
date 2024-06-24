using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UowTest814.Orders
{
    public class OrderManager : DomainService
    {
        protected IUnitOfWorkManager UnitOfWorkManager => base.LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();
        private readonly IRepository<Order, Guid> _repository;
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IRepository<Order, Guid> repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public virtual async Task<Order> AddOrderBeginAsync()
        {
            var order = new Order(Guid.NewGuid(), "order" + DateTime.Now);
            using (var uow = UnitOfWorkManager.Begin(true, true))
            {
                order = await _repository.InsertAsync(order);
                await uow.SaveChangesAsync();
                var orderBegin1 = await _orderRepository.GetBookByIdAsync(order.Id);
                if (orderBegin1 != null)
                    Logger.LogInformation("orderBegin1 查询√√√");
                else
                    Logger.LogInformation("orderBegin1 查询×××");

                await uow.CompleteAsync();

                var orderBegin2 = await _orderRepository.GetBookByIdAsync(order.Id);
                if (orderBegin2 != null)
                    Logger.LogInformation("orderBegin2 查询√√√");
                else
                    Logger.LogInformation("orderBegin2 查询×××");
            }
            try
            {
                var orderBegin3 = await _repository.GetAsync(order.Id);
                if (orderBegin3 != null)
                    Logger.LogInformation("orderBegin3 查询√√√");
                else
                    Logger.LogInformation("orderBegin3 查询×××");
            }
            catch (Exception ex)
            {
                Logger.LogInformation("orderBegin3 查询××× " + ex.Message);
            }
            var orderBegin4 = await _orderRepository.GetBookByIdAsync(order.Id);
            if (orderBegin4 != null)
                Logger.LogInformation("orderBegin4 查询√√√");
            else
                Logger.LogInformation("orderBegin4 查询×××");
            return order;
        }

        public virtual async Task<Order> AddOrderSaveChangeAsync()
        {
            var order = new Order(Guid.NewGuid(), "order" + DateTime.Now);
            order = await _repository.InsertAsync(order);
            if (UnitOfWorkManager != null && UnitOfWorkManager.Current != null)
                await UnitOfWorkManager.Current.SaveChangesAsync();
            try
            {
                var orderSaveChange1 = await _repository.GetAsync(order.Id);
                if (orderSaveChange1 != null)
                    Logger.LogInformation("orderSaveChange1 查询√√√");
                else
                    Logger.LogInformation("orderSaveChange1 查询×××");
            }
            catch (Exception ex)
            {
                Logger.LogInformation("orderSaveChange1 查询×××" + ex.Message);
            }
            var orderSaveChange2 = await _orderRepository.GetBookByIdAsync(order.Id);
            if (orderSaveChange2 != null)
                Logger.LogInformation("orderSaveChange2 查询√√√");
            else
                Logger.LogInformation("orderSaveChange2 查询×××");
            return order;
        }
    }
}
