namespace AGToolkit.Domain
{
    public interface INotifyOfFailedCalculation
    {
        void NotifyOfFailedCalculation(double numberOfFrets, double scaleLength);
    }
}