using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowTest814.Tests;

namespace UowTest814.Controllers
{
    public class TestController : UowTest814Controller, ITestAppService
    {
        private readonly ITestAppService _testAppService;

        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }
        [HttpPost]
        [Route("TestBegin")]
        public async Task TestBeginAsync()
        {
            await _testAppService.TestBeginAsync();
        }

        [HttpPost]
        [Route("TestSaveChange")]
        public async Task TestSaveChangeAsync()
        {
            await _testAppService.TestSaveChangeAsync();
        }
    }
}
