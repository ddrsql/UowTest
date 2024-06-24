using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowTest814.Books;
using UowTest814.Orders;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace UowTest814.Tests
{
    public class TestAppService : UowTest814AppService, ITestAppService
    {
        private readonly IIdentityUserRepository _identityuserRepository;
        private readonly IIdentityRoleRepository _identityRoleRepository;
        private readonly BookManager _bookManager;
        private readonly OrderManager _orderManager;

        public TestAppService(
            IIdentityUserRepository identityuserRepository,
            IIdentityRoleRepository identityRoleRepository,
            BookManager bookManager,
            OrderManager orderManager)
        {
            _identityuserRepository = identityuserRepository;
            _identityRoleRepository = identityRoleRepository;
            _bookManager = bookManager;
            _orderManager = orderManager;
        }
        //abp 8.1.4

        /// <summary>
        /// UnitOfWorkManager.Begin
        /// </summary>
        /// <returns></returns>
        public async Task TestBeginAsync()
        {
            //await _bookManager.AddBookBeginAsync();
            //await _orderManager.AddOrderBeginAsync();

            var name = DateTime.Now.ToString("MMssffff");
            IdentityUser identityUser = new IdentityUser(Guid.NewGuid(), $"{name}", $"{name}@cc.cc");
            using (var uow = UnitOfWorkManager.Begin(true, true))
            {
                await _identityuserRepository.InsertAsync(identityUser);
                await uow.SaveChangesAsync();
                var userBegin1 = await _identityuserRepository.FindAsync(identityUser.Id);
                if (userBegin1 != null)
                    Logger.LogInformation("userBegin1 查询√√√");
                else
                    Logger.LogInformation("userBegin1 查询×××");
                await uow.CompleteAsync();

                var userBegin2 = await _identityuserRepository.FindAsync(identityUser.Id);
                if (userBegin2 != null)
                    Logger.LogInformation("userBegin2 查询√√√");
                else
                    Logger.LogInformation("userBegin2 查询×××");
            }
            var userBegin3 = await _identityuserRepository.FindAsync(identityUser.Id);
            if (userBegin3 != null)
                Logger.LogInformation("userBegin3 查询√√√");
            else
                Logger.LogInformation("userBegin3 查询×××");

            IdentityRole identityRole = new IdentityRole(Guid.NewGuid(), $"{name}");
            using (var uow = UnitOfWorkManager.Begin(true, true))
            {
                await _identityRoleRepository.InsertAsync(identityRole);
                await uow.SaveChangesAsync();
                var roleBegin1 = await _identityRoleRepository.FindAsync(identityRole.Id);
                if (roleBegin1 != null)
                    Logger.LogInformation("roleBegin1 查询√√√");
                else
                    Logger.LogInformation("roleBegin1 查询×××");

                await uow.CompleteAsync();

                var roleBegin2 = await _identityRoleRepository.FindAsync(identityRole.Id);
                if (roleBegin2 != null)
                    Logger.LogInformation("roleBegin2 查询√√√");
                else
                    Logger.LogInformation("roleBegin2 查询×××");
            }
            var roleBegin3 = await _identityRoleRepository.FindAsync(identityRole.Id);
            if (roleBegin3 != null)
                Logger.LogInformation("roleBegin3 查询√√√");
            else
                Logger.LogInformation("roleBegin3 查询×××");

            await _bookManager.AddBookBeginAsync();
            await _orderManager.AddOrderBeginAsync();
        }

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public async Task TestSaveChangeAsync()
        {
            var name = DateTime.Now.ToString("MMssffff");
            IdentityUser identityUser = new IdentityUser(Guid.NewGuid(), $"{name}", $"{name}@cc.cc");
            await _identityuserRepository.InsertAsync(identityUser);
            if (UnitOfWorkManager != null && UnitOfWorkManager.Current != null)
                await UnitOfWorkManager.Current.SaveChangesAsync();
            var userSaveChange = await _identityuserRepository.FindAsync(identityUser.Id);
            if (userSaveChange != null)
                Logger.LogInformation("userSaveChange 查询√√√");
            else
                Logger.LogInformation("userSaveChange 查询×××");

            IdentityRole identityRole = new IdentityRole(Guid.NewGuid(), $"{name}");
            await _identityRoleRepository.InsertAsync(identityRole);
            if (UnitOfWorkManager != null && UnitOfWorkManager.Current != null)
                await UnitOfWorkManager.Current.SaveChangesAsync();
            var roleSaveChange = await _identityRoleRepository.FindAsync(identityRole.Id);
            if (roleSaveChange != null)
                Logger.LogInformation("roleSaveChange 查询√√√");
            else
                Logger.LogInformation("roleSaveChange 查询×××");

            await _bookManager.AddBookSaveChangeAsync();
            await _orderManager.AddOrderSaveChangeAsync();
        }
    }
}
