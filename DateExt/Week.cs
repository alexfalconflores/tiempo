using System;

namespace DateExt;

public static class Week
{
    /// <summary>
    /// Add the specified number of weeks to the given date.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="amount">The amount of week to be added.</param>
    /// <returns>The new <see cref="DateTime"/> with the weeks added.</returns>
    public static DateTime AddWeeks(this DateTime dateTime, int amount) => dateTime.AddDays(amount * 7);

}
