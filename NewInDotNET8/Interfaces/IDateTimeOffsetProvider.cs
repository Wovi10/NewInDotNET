namespace NewInDotNET8.Interfaces;

public interface IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow { get; }
}