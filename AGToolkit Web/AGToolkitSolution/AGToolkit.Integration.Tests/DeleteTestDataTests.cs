using AGToolkit.Domain;
using AGToolkit.Domain.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AGToolkit.Integration.Tests
{
    public class DeleteTestDataTests
    {
        // Variables for each test
        FretPositionCalculator calculator;
        LoadTestData tdata;
        private double fretAmount;
        private double scaleLength;

        // Constructor for setup 
        // Loads calculator and calls API InitializeClient();
        public DeleteTestDataTests()
        {
            calculator = new FretPositionCalculator();
            tdata = new LoadTestData();
            ApiTestDataHelper.InitializeClient();
        }

        private async Task PostData(int id = 0, double frets = 0, double scale = 0)
        {
            var testdata = await TestDataProcessor.PostTestData(id, frets, scale);

            fretAmount = testdata.FretAmount;
            scaleLength = testdata.ScaleLength;
            tdata.FretAmount = fretAmount;
            tdata.ScaleLength = scaleLength;
        }

        [Theory]
        [InlineData(10, 22, 27)]
        [InlineData(11, 21, 24)]
        [InlineData(12, 21, 25.5)]
        [InlineData(13, 18, 34)]
        [InlineData(14, 20, 32)]
        public async Task AddNewEntryToDatabaseThenDelete (int id, double frets, double scale)
        {
            // GIVEN
            // Posts data to database for test
            await PostData(id, frets, scale);
            int expectedStatusCode = 204; // Expects a "204 No Content" status code after deletion

            // WHEN
            // The data is deleted from the DB
            var testdataStatusCode = await TestDataProcessor.DeleteTestData(id);

            // THEN
            // The data entry is no longer in the DB
            Assert.Equal(expectedStatusCode, testdataStatusCode);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        public async Task FailedToDeleteTestEntry(int id)
        {
            // GIVEN
            //// The connection to the DB is active
            // WHEN
            //// The user tries to delete a data entry that doesnt exist
            // THEN
            //// The system throws an excpetion
            //// and displays a log message 
            //// "Unable to delete data entry for key -- TestId: { id }"
            await Assert.ThrowsAsync<Exception>(() => TestDataProcessor.DeleteTestData(id));
        }

    }
}
