using System;

namespace Tiempo;

public static class MonthExt
{
    /// <summary>
    /// Return the start of a month for the given date
    /// <example><code>
    /// // The start of a month for 2 September 2024 23:55:00
    /// var result = new DateTime(2024, 9, 2, 23, 55, 0).StartOfMonth();
    /// // -> 9/1/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <returns>The start of a month</returns>
    public static DateTime StartOfMonth(this DateTime dateTime) => 
        new(dateTime.Year, dateTime.Month, 1, 0, 0, 0);
    /// <summary>
    /// Return the last day of a month for the given date
    /// <example><code>
    /// // The last day of a month for 2 September 2024
    /// var result = new DateTime(2024, 9, 2, 23, 55, 0).LastDayOfMonth();
    /// //-> 9/30/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <returns>The last day of a month</returns>
    public static DateTime LastDayOfMonth(this DateTime dateTime) =>
        new(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));

}
