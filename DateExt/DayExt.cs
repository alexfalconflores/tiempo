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
    /// <summary>
    /// Are the given dates in the same day (and year and month)?
    /// <example>
    /// <code>
    /// //Are 31 August 06:00:00 and 31 August 18:00:00 in the same day?
    /// var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
    /// // -> True
    /// 
    /// //Are 30 August and 30 September in the same day?
    /// var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
    /// // -> False
    /// 
    /// //Are 31 August, 2024 and 31 August, 2023 in the same day?
    /// var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
    /// // -> False
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime1">The first date to check</param>
    /// <param name="dateTime2">The second date to check</param>
    /// <returns>The date are in the same day (and year and month)</returns>
    public static bool IsSameDay(this DateTime dateTimeLeft, DateTime dateTimeRight) =>
        dateTimeLeft.StartOfDay().Equals(dateTimeRight.StartOfDay());
    /// <summary>
    /// Return the start of a day for the given date.
    /// <example>
    /// <code>
    /// //The start of a day for 31 August 2024 06:00:00
    /// var result = new DateTime(2024, 8, 31, 6,0,0).StartOfDay();
    /// // -> 8/31/2024 12:00:00 AM
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <returns>The start of a day</returns>
    public static DateTime StartOfDay(this DateTime dateTime) => dateTime.Date;
}
