using AGToolkit.Domain;
using AGToolkit.Domain.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AGToolkit.Integration.Tests
{
    public class CallTestDataTests
    {
        // Variables for each test
        FretPositionCalculator calculator;
        LoadTestData tdata;
        private double fretAmount;
        private double scaleLength;

        // Constructor for setup 
        // Loads calculator and calls API InitializeClient();
        public CallTestDataTests()
        {
            calculator = new FretPositionCalculator();
            tdata = new LoadTestData();
            ApiTestDataHelper.InitializeClient();
        }

        // Calling the API test data and assigning it to test varibles
        private async Task LoadData(int testIdNumber = 0)
        {
            var testdata = await TestDataProcessor.LoadTestData(testIdNumber);
           
            fretAmount = testdata.FretAmount;
            scaleLength = testdata.ScaleLength;
            tdata.FretAmount = fretAmount;
            tdata.ScaleLength = scaleLength;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task CallSpecificTestDataId (int id)
        {
            // GIVEN
            await LoadData(id);
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
