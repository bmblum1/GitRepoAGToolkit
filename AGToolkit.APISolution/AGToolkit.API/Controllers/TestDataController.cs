using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AGToolkit.API.Data;
using AGToolkit.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGToolkit.API.Controllers
{
    //[EnableCors("_everyone")]
    [Route("api/")]
    [ApiController]
    public class TestDataController : Controller
    {
        TestDataContext context;

        public TestDataController(TestDataContext context)
        {
            this.context = context;
        }

        [HttpPost("testdata")]
        public async Task<IActionResult> AddTestData([FromBody] TestDataCreate testDataCreate)
        {
            var testdata = new Data.TestData
            {
                FretAmount = testDataCreate.FretAmount,
                ScaleLength = testDataCreate.ScaleLength
            };

            context.Add(testdata);
            await context.SaveChangesAsync();

            var response = new TestDataCreateResponse
            {
                FretAmount = testdata.FretAmount,
                ScaleLength = testdata.ScaleLength
            };

            return Ok(response);
        }

        [HttpGet("testdata")]
        public async Task<IActionResult> GetAllTestData()
        {
            var items = await context.TestData
                .Select(h => new TestDataResponseItem
                {
                    FretAmount = h.FretAmount,
                    ScaleLength = h.ScaleLength
                }).ToListAsync();

            var response = new TestDataResponse
            {
                Data = items
            };
            return Ok(response);
        }
    }
}