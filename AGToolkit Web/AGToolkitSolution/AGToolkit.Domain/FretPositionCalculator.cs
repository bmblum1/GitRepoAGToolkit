using System;
using System.Collections.Generic;
using NLog;

namespace AGToolkit.Domain
{
    public class FretPositionCalculator
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

        // Set up txt file logger 
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        Logger logger = LogManager.GetLogger("fileLogger");

        // Set up console output _logger
        OutputLogger _logger = new OutputLogger();
        
        // Properties 
        public double FretAmount { get => fretAmount; set => fretAmount = value; }
        public double ScaleLength { get => scaleLength; set => scaleLength = value; }
        public double Distance { get => distance; set => distance = value; }

        // Constructor that takes no arguments
        public FretPositionCalculator() { }

        // Constructor that takes two arguments
        public FretPositionCalculator(double frets, double scale)
        {
            frets = FretAmount;
            scale = ScaleLength;
        }

        public double CalculateValues(double numberOfFrets, double scale, double dist)
        {
            // Calculate scale length
            location = scale - dist;
            scalingFactor = location / 17.817;

            // Return calculated distance
            return dist += scalingFactor;
        }

        public List<double> GenerateFretList()
        {
            try
            {
                if (FretAmount > 0 
                    && FretAmount < 50
                    && ScaleLength > 0 
                    && ScaleLength < 100)
                {
                    for (int i = 0; i < FretAmount; i++)
                    {
                        Distance = Math.Round(CalculateValues(FretAmount, ScaleLength, Distance), 3);
                        calculatedFretPositions.Add(Distance);
                    }
                }
                else
                {
                    throw new InvalidFretOrScaleException();
                }
            }
            catch (InvalidFretOrScaleException ex)
            {

                _logger.NotifyOfFailedCalculation(FretAmount, ScaleLength); // Console Output Logger
                logger.Error(ex, message: "Invalid Fret Amount or Scale Length!"); // Write to text file logger
                throw new InvalidFretOrScaleException();
            }
            return calculatedFretPositions;
        }
    }
}
