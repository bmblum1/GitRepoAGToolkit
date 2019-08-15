using AGToolkit.Domain;
using AGToolkit.Domain.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AGToolkit.Integration.Tests
{
    public class AddTestDataTests
    {
        FretPositionCalculator calculator;
        LoadTestData tdata;
        private double fretAmount;
        private double scaleLength;

        // Constructor for setup 
        // Loads calculator and calls API InitializeClient();
        public AddTestDataTests()
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
        [InlineData(6,22,27)]
        [InlineData(7,21,24)]
        [InlineData(8,21,25.5)]
        [InlineData(9,18,34)]
        public async Task AddNewDataEntryToTestDatabase(int id, double frets, double scale)
        {
            // GIVEN
            await PostData(id, frets, scale);

            calculator.FretAmount = fretAmount;
            calculator.ScaleLength = scaleLength;

            // WHEN
            //// Method used to fill the "expected" list with values
            List<double> expected = new List<double>(tdata.TestValues());

            //// SUT
            List<double> calculatedFretList = new List<double>(calculator.GenerateFretList());

            // THEN
            Assert.Equal(expected, calculatedFretList);
        }
    }
}
