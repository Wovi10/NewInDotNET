using NewInDotNET8.Interfaces;

namespace NewInDotNET8;

public class TimeAbstraction
{
    private readonly TimeProvider _timeProvider;

    public TimeAbstraction(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }
    
    public string Old_GetTimeOfDay()
    {
        var currentTime = DateTimeOffset.UtcNow; // Difficult to mock and therefore test
        
        var message = currentTime.Hour switch
        {
            >= 6 and <= 12 => "Morning",
            > 12 and <= 18 => "Afternoon",
            > 18 and <= 24 => "Evening",
            _ => "Night"
        };

        return message;
    }
    
    public string GetTimeOfDay()
    {
        var currentTime = _timeProvider.GetUtcNow(); // Easy to mock and therefore test
        
        var message = currentTime.Hour switch
        {
            >= 6 and <= 12 => "Morning",
            > 12 and <= 18 => "Afternoon",
            > 18 and <= 24 => "Evening",
            _ => "Night"
        };

        return message;
    }
}