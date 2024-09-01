using System;

namespace DateExt;

public static class WeekdayExt
{
    /// <summary>
    /// Get the day of the week of the given date.
    /// <example>
    /// Which day of the week is 31 august 2024?
    /// <code>
    /// int day = new DateTime(2024,8,31).GetDayOfWeek();
    /// // 6
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The day of week, 0 represents Sunday</returns>
    public static int GetDayOfWeek(this DateTime dateTime) => dateTime.DayOfWeek.GetHashCode();
    /// <summary>
    /// Is the given date Sunday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Sunday</returns>
    public static bool IsSunday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Sunday;
    /// <summary>
    /// Is the given date Monday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Monday</returns>
    public static bool IsMonday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Monday;
    /// <summary>
    /// Is the given date Tuesday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Tuesday</returns>
    public static bool IsTuesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Tuesday;
    /// <summary>
    /// Is the given date Wednesday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Wednesday</returns>
    public static bool IsWednesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Wednesday;
    /// <summary>
    /// Is the given date Thursday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Thursday</returns>
    public static bool IsThursday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Thursday;
    /// <summary>
    /// Is the given date Friday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Friday</returns>
    public static bool IsFriday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Friday;
    /// <summary>
    /// Is the given date Saturday?
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is Saturday</returns>
    public static bool IsSaturday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday;
    /// <summary>
    /// Does the given date fall on a weekend? A weekend is either Saturday(`6`) or Sunday (`0`).
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date falls on a weekend</returns>
    public static bool IsWeekend(this DateTime dateTime)
    {
        var day = dateTime.DayOfWeek;
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }
    /// <summary>
    /// Does the date fall on a weekday? Weekdays are Monday (`1`) through Friday (`5`).
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date falls on a weekday</returns>
    public static bool IsWeekdays(this DateTime dateTime) => !dateTime.IsWeekend();
    /// <summary>
    /// When is the next day of the week? <see cref="DayOfWeek"/> the day of the week.
    /// <example>
    /// <code>
    /// // When is the next Monday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Monday);
    /// // 2 september 2024 -> 9/2/2024 12:00:00 AM
    /// 
    /// // When is the next Thursday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Thursday);
    /// // 5 september 2024 -> 9/5/2024 12:00:00 AM
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The day to check</param>
    /// <param name="dayOfWeek">Day of the week</param>
    /// <returns>The date is the next day of week.</returns>
    public static DateTime NextDay(this DateTime dateTime, DayOfWeek dayOfWeek)
    {
        int delta = dayOfWeek - dateTime.DayOfWeek;
        if (delta <= 0) delta += 7;
        return dateTime.AddDays(delta);
    }
    /// <summary>
    /// When is the next day of the week? 0-6 the day o the week, 0 represents Sunday.
    /// <example>
    /// <code>
    /// // When is the next Monday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextDay(1);
    /// // 2 september 2024 -> 9/2/2024 12:00:00 AM
    /// 
    /// // When is the next Thursday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextDay(4);
    /// // 5 september 2024 -> 9/5/2024 12:00:00 AM
    /// 
    /// // When is the next Thursday after 31 august 2024? 
    /// var result = new DateTime(2024, 8, 31).NextDay(-5); // Wrong day of the week
    /// // 31 august 2024 -> 8/31/2024 12:00:00 AM
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The day to check</param>
    /// <param name="dayOfWeek">Day of the week</param>
    /// <returns>The date is the next day of week.
    /// If <paramref name="dayOfWeek"/> is less than 0 or greater than 6, the original date is returned.
    /// </returns>
    public static DateTime NextDay(this DateTime dateTime, int dayOfWeek)
    {
        if (dayOfWeek is > 6 or < 0) return dateTime;
        int delta = dayOfWeek - dateTime.GetDayOfWeek();
        Console.WriteLine(delta);
        if (delta <= 0) delta += 7;
        return dateTime.AddDays(delta);
    }
    /// <summary>
    /// When is the next Sunday?
    /// <example><code>
    /// // When is the next Sunday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextSunday();
    /// // 1 september 2024 -> 9/1/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Friday</returns>
    public static DateTime NextSunday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Sunday);
    /// <summary>
    /// When is the next Monday?
    /// <example><code>
    /// // When is the next Monday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextMonday();
    /// // 2 september 2024 -> 9/2/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Monday</returns>
    public static DateTime NextMonday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Monday);
    /// <summary>
    /// When is the next Tuesday?
    /// <example><code>
    /// // When is the next Tuesday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextTuesday();
    /// // 3 september 2024 -> 9/3/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Tuesday</returns>
    public static DateTime NextTuesday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Tuesday);
    /// <summary>
    /// When is the next Wednesday?
    /// <example><code>
    /// // When is the next Wednesday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextWednesday();
    /// // 4 september 2024 -> 9/4/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Wednesday</returns>
    public static DateTime NextWednesday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Wednesday);
    /// <summary>
    /// When is the next Thursday?
    /// <example><code>
    /// // When is the next Thursday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextThursday();
    /// // 5 september 2024 -> 9/5/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Thursday</returns>
    public static DateTime NextThursday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Thursday);
    /// <summary>
    /// When is the next Friday?
    /// <example><code>
    /// // When is the next Friday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextFriday();
    /// // 6 september 2024 -> 9/6/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Friday</returns>
    public static DateTime NextFriday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Friday);
    /// <summary>
    /// When is the next Saturday?
    /// <example><code>
    /// // When is the next Saturday after 31 august 2024?
    /// var result = new DateTime(2024, 8, 31).NextSaturday();
    /// // 7 september 2024 -> 9/7/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to start counting from</param>
    /// <returns>The next Saturday</returns>
    public static DateTime NextSaturday(this DateTime dateTime) => dateTime.NextDay(DayOfWeek.Saturday);

}
