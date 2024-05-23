namespace DotNET8.Interfaces;

public interface IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow { get; }
}