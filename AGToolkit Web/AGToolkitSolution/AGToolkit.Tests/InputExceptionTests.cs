using System;
using System.Collections.Generic;
using System.Text;
using AGToolkit;
using AGToolkit.Domain;
using Xunit;

namespace AGToolkit.Tests
{
    public class InputExceptionTests
    {
        FretPositionCalculator calculator;
   
        public InputExceptionTests()
        {
            calculator = new FretPositionCalculator();
        }

        [Theory]
        [InlineData(-5, 25.5)]
        [InlineData(21, -25.5)]
        [InlineData(0, 0)]
        [InlineData(51, 25.5)] // Frets 1-50
        [InlineData(24, 100.1)] // Scale 1-100
        public void InvalidFretAmountThrowsExcpetion (double frets, double scale)
        {
            // GIVEN
            calculator.FretAmount = frets;
            calculator.ScaleLength = scale;
            List<double> calculatedFretList = new List<double>();

            // WHEN -- THEN
            Assert.Throws<InvalidFretOrScaleException>(() => calculator.GenerateFretList());
        }
    }
}