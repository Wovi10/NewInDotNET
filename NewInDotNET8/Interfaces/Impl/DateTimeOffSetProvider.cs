﻿namespace NewInDotNET8.Interfaces.Impl;

public class DateTimeOffSetProvider:IDateTimeOffsetProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.Now;
}