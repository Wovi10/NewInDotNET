using Moq;
using DotNET8;

namespace DotNET8Tests;

public class TimeAbstractionTests
{
    private readonly TimeAbstraction _timeAbstraction;
    private readonly Mock<TimeProvider> _timeProviderMock = new();

    public TimeAbstractionTests()
    {
        _timeAbstraction = new TimeAbstraction(_timeProviderMock.Object);
    }

    [Fact]
    public void Old_GetTimeOfDay_Morning()
    {
        const string expected = "Morning";
        var actual = _timeAbstraction.Old_GetTimeOfDay();

        Assert.Same(actual, expected);
    }

    [Fact]
    public void Old_GetTimeOfDay_Afternoon()
    {
        const string expected = "Afternoon";
        var actual = _timeAbstraction.Old_GetTimeOfDay();

        Assert.Same(actual, expected);
    }

    [Theory]
    [MemberData(nameof(TimeOffDayTestCases))]
    public void GetTimeOfDay_Morning(DateTimeOffset date, string expectedMessage)
    {
        _timeProviderMock.Setup(x => x.GetUtcNow()).Returns(date);

        var actual = _timeAbstraction.GetTimeOfDay();

        Assert.Same(actual, expectedMessage);
    }

    public static IEnumerable<object[]> TimeOffDayTestCases()
    {
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 6, 0, 0, TimeSpan.Zero), "Morning"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 12, 59, 59, TimeSpan.Zero), "Morning"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 13, 0, 0, TimeSpan.Zero), "Afternoon"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 18, 59, 59, TimeSpan.Zero), "Afternoon"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 19, 0, 0, TimeSpan.Zero), "Evening"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 23, 59, 59, TimeSpan.Zero), "Evening"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 00, 0, 0, TimeSpan.Zero), "Night"
        };
        yield return new object[]
        {
            new DateTimeOffset(2024, 1, 1, 05, 59, 59, TimeSpan.Zero), "Night"
        };
    }
}