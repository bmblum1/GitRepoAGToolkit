using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NLog;

namespace AGToolkit.Domain
{
    public class OutputLogger : INotifyOfFailedCalculation
    {
        public void NotifyOfFailedCalculation (double numberOfFrets, double scaleLength)
        {
            Debug.WriteLine("Failed to Calculate Fret Positions with the following values: ");
            Debug.WriteLine($"Number of Frets: {numberOfFrets} -- Scale Length: {scaleLength}");
        }

        public void NotifyOfFailedDeletion(int testId)
        {
            Debug.WriteLine($"Unable to delete data entry for key -- TestId: { testId }");
        }
    }
}
