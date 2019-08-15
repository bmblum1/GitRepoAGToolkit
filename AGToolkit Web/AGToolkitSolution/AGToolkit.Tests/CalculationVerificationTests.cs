using AGToolkit.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AGToolkit.Tests
{
    public class CalculationVerificationTests
    {
        FretPositionCalculator calculator;
        LoadTestData tdata;

        public CalculationVerificationTests()
        {
            calculator = new FretPositionCalculator();
            tdata = new LoadTestData();
        }

        [Theory]
        [InlineData(24, 25.5)]
        [InlineData(21, 25.5)]
        [InlineData(22, 24.75)]
        [InlineData(24, 25)]
        [InlineData(24, 28)]
        public void VerifyCorrectCalculationTest(double frets, double scale)
        {
            // GIVEN
            calculator.FretAmount = frets;
            calculator.ScaleLength = scale;
            tdata.FretAmount = frets;
            tdata.ScaleLength = scale;

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
