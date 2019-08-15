using System;
using System.Collections.Generic;

namespace AGToolkit.Integration.Tests
{
    public class LoadTestData
    {
        // Private variables for calculation
        private double location;
        private double scalingFactor;
        private double distance;
        private double fretAmount;
        private double scaleLength;

        // A list that loads the calculated fret position for each fret. 
        // Result is in inches.
        private List<double> calculatedFretPositions = new List<double>();

        // Properties 
        public double FretAmount { get => fretAmount; set => fretAmount = value; }
        public double ScaleLength { get => scaleLength; set => scaleLength = value; }
        public double Distance { get => distance; set => distance = value; }

        public LoadTestData() { }

        public LoadTestData(double frets, double scale)
        {
            frets = FretAmount;
            scale = ScaleLength;
        }

        public double CalculateValues(double numberOfFrets, double scale)
        {
            // Calculate scale length
            location = scale - Distance;
            scalingFactor = location / 17.817;

            // Return calculated distance
            return Distance += scalingFactor;
        }

        public double CalculateValues(double numberOfFrets, double scale, double dist)
        {
            // Calculate scale length
            location = scale - dist;
            scalingFactor = location / 17.817;

            // Return calculated distance
            return dist += scalingFactor;
        }

        public List<double> TestValues()
        {
            for (int i = 0; i < FretAmount; i++)
            {
                Distance = Math.Round(CalculateValues(FretAmount, ScaleLength, Distance), 3);
                calculatedFretPositions.Add(Distance);
            }
            return calculatedFretPositions;
        }
    }
}

