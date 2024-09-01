using System;

namespace DateExt;

public static class DayExt
{
    /// <summary>
    /// Subtract the specified number of days from the given date.
    /// <example><code>
    /// // Subtract 10 days from 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).SubtractDays(10);
    /// // 21 august 2024 -> 8/21/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="days">The amount of days to be subtracted</param>
    /// <returns>The new <see cref="DateTime"/> with the days subtracted</returns>
    public static DateTime SubtractDays(this DateTime dateTime, int days) => dateTime.AddDays(-(days));
}
