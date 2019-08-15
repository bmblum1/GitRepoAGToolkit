using AGToolkit.API.Data;
using AGToolkit.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGToolkit.API.Controllers
{
    [Route("api/testdata/")]
    [ApiController]
    public class TestDataController : Controller
    {
        [HttpGet]
        public IEnumerable<TestData> GetAllTestDataEntries()
        {
            using (TestDataContext context = new TestDataContext())
            {
                return context.TestData.ToList();
            }
        }

        [HttpGet("{id}")]
        public TestData GetSingleTestDataEntry(int id)
        {
            using (TestDataContext context = new TestDataContext())
            {
                return context.TestData.FirstOrDefault(e => e.TestId == id);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestData>> AddToTestDatabase([FromBody] TestDataCreate testDataCreate)
        {
            using (TestDataContext context = new TestDataContext())
            {
                var testdata = new Data.TestData
                {
                    TestId = testDataCreate.TestId,
                    FretAmount = testDataCreate.FretAmount,
                    ScaleLength = testDataCreate.ScaleLength
                };

                context.TestData.Add(testdata);
                await context.SaveChangesAsync();

                var response = new TestDataCreateResponse
                {
                    TestId = testdata.TestId,
                    FretAmount = testdata.FretAmount,
                    ScaleLength = testdata.ScaleLength
                };

                return CreatedAtAction(nameof(GetSingleTestDataEntry), new
                {
                    id = testdata.TestId,
                    fret = testdata.FretAmount,
                    scale = testdata.ScaleLength
                }, testdata);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingleTestEntry(int id)
        {
            using (TestDataContext context = new TestDataContext())
            {
                var testDataItem = await context.TestData.FindAsync(id);
                if (testDataItem == null)
                {
                    return NotFound();
                }
                context.TestData.Remove(testDataItem);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}