using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace UowTest814.Tests
{
    public interface ITestAppService : IApplicationService
    {
        Task TestBeginAsync();

        Task TestSaveChangeAsync();
    }

}
