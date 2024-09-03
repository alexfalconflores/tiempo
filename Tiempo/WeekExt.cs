using System;

namespace Tiempo;

public static class WeekExt
{
    /// <summary>
    /// Add the specified number of weeks to the given date.
    /// <example><code>
    /// // Add 4 weeks to 1 September, 2024
    /// var result = new DateTime(2024, 9, 1, 6, 0, 0).AddWeeks(4);
    /// // -> 9/29/2024 6:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="amount">The amount of week to be added.</param>
    /// <returns>The new <see cref="DateTime"/> with the weeks added</returns>
    public static DateTime AddWeeks(this DateTime dateTime, int amount) => dateTime.AddDays(amount * 7);
    /// <summary>
    /// Subtract the specified number of weeks from the given date.
    /// <example><code>
    /// // Subtract 4 weeks from 1 September, 2024
    /// var result = new DateTime(2024, 9, 1, 6, 0, 0).SubtractWeeks(4);\
    /// // -> 8/4/2024 6:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="amount">The amount of weeks to be subtracted</param>
    /// <returns>The new <see cref="DateTime"/> with the weeks subtracted</returns>
    public static DateTime SubtractWeeks(this DateTime dateTime, int amount) => dateTime.AddWeeks(-amount);
    /// <summary>
    /// Are the given dates in the same week (and month and year)?
    /// <example><code>
    /// // Are 2 September 11:55:00 and 2 September 11:50:00 in the same week?
    /// var result = new DateTime(2024, 9, 2, 11, 55, 0).IsSameWeek(new DateTime(2024, 9, 2, 11, 50, 0));
    /// // -> True
    /// 
    /// // Are 30 September 11:55:00 and 3 Octuber 11:55:00 in the same week?
    /// var result = new DateTime(2024, 9, 30, 11, 55, 0).IsSameWeek(new DateTime(2024, 10, 3, 11, 55, 0));
    /// // -> True
    /// 
    /// // Are 2 September 11:55:00 and 3 Octuber 11:55:00 in the same week?
    /// var result = new DateTime(2024, 9, 2, 11, 55, 0).IsSameWeek(new DateTime(2024, 10, 3, 11, 55, 0));
    /// // -> False
    /// </code></example>
    /// </summary>
    /// <param name="dateTimeLeft">The first date to check</param>
    /// <param name="dateTimeRight">The second date to check</param>
    /// <param name="weekStartsOn">Specifies the <see cref="DayOfWeek"/> of the week</param>
    /// <returns>The dates are in the same week (and month and year)</returns>
    public static bool IsSameWeek(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
        var leftWeek = calendar.GetWeekOfYear(dateTimeLeft, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);
        var rightWeek = calendar.GetWeekOfYear(dateTimeRight, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);

        return leftWeek == rightWeek && dateTimeLeft.Year == dateTimeRight.Year;
    }
    /// <summary>
    /// Return the start of a week for the given date.
    /// <example><code>
    /// // The start of a week for 3 Octuber, 2024 11:55:00
    /// var result = new DateTime(2024, 10, 3,11, 55, 0).StartOfWeek();
    /// // -> 9/29/2024 12:00:00 AM
    /// 
    /// // If the week starts on Monday, the start of a week for 3 Octuber, 2024 11:55:00
    /// var result = new DateTime(2024, 10, 3,11, 55, 0).StartOfWeek(DayOfWeek.Monday);
    /// // -> 9/30/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <param name="weekStartsOn">Specifies the <see cref="DayOfWeek"/> of the week</param>
    /// <returns>The start of a week</returns>
    public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        int diff = (7 + (dateTime.DayOfWeek - weekStartsOn)) % 7;
        return dateTime.AddDays(-1 * diff).Date;
    }
    /// <summary>
    /// Get the number of calendar weeks between the given dates.
    /// <example><code>
    /// // How many calendar weeks are between 5 July 2014 and 20 July 2014?
    /// var result = new DateTime(2014, 7, 20, 11, 55, 0).DifferenceInCalendarWeeks(new DateTime(2014, 7, 5, 11, 50, 0));
    /// // -> 3
    /// 
    /// // If the week starts on Monday,
    /// // how many calendar weeks are between 5 July 2024 and 20 July 2024?
    /// var result = new DateTime(2024, 7, 20, 11, 55, 0).DifferenceInCalendarWeeks(new DateTime(2024, 7, 5, 11, 50, 0), DayOfWeek.Monday);
    /// // -> 2
    /// </code></example>
    /// </summary>
    /// <param name="dateTimeLeft">The later date</param>
    /// <param name="dateTimeRight">The earlier date</param>
    /// <param name="weekStartsOn">Specifies the <see cref="DayOfWeek"/> of the week</param>
    /// <returns>The number of calendar weeks</returns>
    public static int DifferenceInCalendarWeeks(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
        int leftWeek = calendar.GetWeekOfYear(dateTimeLeft, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);
        int rightWeek = calendar.GetWeekOfYear(dateTimeRight, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);

        return (leftWeek - rightWeek) + (dateTimeLeft.Year - dateTimeRight.Year) * 52;
    }
    /// <summary>
    /// Get the number of full weeks between the given dates.
    /// </summary>
    /// <param name="dateTimeLeft">The later date</param>
    /// <param name="dateTimeRight">The earlier date</param>
    /// <returns>The number of full weeks</returns>
    /// <example><code>
    /// // How many full weeks are between 1 September, 2024 23:59:00 and 28 September, 2024?
    /// var result = new DateTime(2024, 9, 1, 23, 59, 59).DifferenceInWeeks(new DateTime(2024, 9, 28, 0, 0, 0));
    /// // -> 3
    /// </code></example>
    public static int DifferenceInWeeks(this DateTime dateTimeLeft, DateTime dateTimeRight) =>
        Math.Abs((dateTimeLeft - dateTimeRight).Days / 7);
    /// <summary>
    /// Return the end of a week for the given date.
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <param name="weekStartsOn">Specifies the <see cref="DayOfWeek"/> of the week</param>
    /// <returns>The end of a week</returns>
    /// <example><code>
    /// // The end of a week for 2 September 2024 11:55:00
    /// var result = new DateTime(2024, 9, 2, 11, 55, 0).EndOfWeek();
    /// // -> 9/6/2024 11:59:59 PM
    /// 
    /// // If the week starts on Monday, the end of a week for 2 September 2024 11:55:00
    /// var result = new DateTime(2024, 9, 2, 11, 55, 0).EndOfWeek(DayOfWeek.Monday);
    /// // -> 9/7/2024 11:59:59 PM 
    /// </code></example>
    public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        int diff = (7 - (dateTime.DayOfWeek - weekStartsOn + 7) % 7 - 1);
        return dateTime.AddDays(diff).Date.AddTicks(-1);
    }
    /// <summary>
    /// Return the start of a local week-numbering year for the given date.
    /// The exact calculation depends on the values of <see cref="WeekYearOptions.WeekStartsOn"/>
    /// (which is the index of the first day of the week) and <see cref="WeekYearOptions.FirstWeekContainsDate"/>
    /// (which is the day of January, which is always in the first week of the week-numbering year)
    /// <example><code>
    /// // The start of a week-numbering year for 2 July. 2005
    /// var result = new DateTime(2005, 7, 2).StartOfWeekYear();
    /// // -> 12/26/2004 12:00:00 AM
    /// 
    /// // The start of a week-numbering year for 2 July. 2005,
    /// if Monday is the first day of week and 4 January is always in the first week of the year
    /// var result = new DateTime(2005, 7, 2).StartOfWeekYear(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
    /// // -> 1/3/2005 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <param name="options">An class with options</param>
    /// <returns>The start of a week-numbering year</returns>
    public static DateTime StartOfWeekYear(this DateTime dateTime, WeekYearOptions options = null)
    {
        (DayOfWeek weekStartsOn, int firstWeekContainsDate) = options ?? new WeekYearOptions();
        int year = dateTime.Year;
        DateTime firstWeek = new(year, 1, firstWeekContainsDate, 0, 0, 0, DateTimeKind.Local);
        int diff = (7 + (firstWeek.DayOfWeek - weekStartsOn)) % 7;
        return firstWeek.AddDays(-diff);
    }
    /// <summary>
    /// Get the local week index of the given date.
    /// The exact calculatio depends on the values of
    /// <see cref="WeekYearOptions.WeekStartsOn"/> (which is the index of the first day of the week)
    /// and <see cref="WeekYearOptions.FirstWeekContainsDate"/> (which is the day of january, which is always
    /// in the first week of the week-numbering year)
    /// <example><code>
    /// // Which week of the local week numbering year is 2 January 2005?
    /// var result = new DateTime(2005, 1, 2).GetWeek();
    /// // -> 2
    /// 
    /// // Which week of the local week numbering year is 2 January 2005.
    /// if Monday is the first day of the week and the first week of the year always contains 4 January?
    /// var result = new DateTime(2005, 1, 2).GetWeek(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
    /// // -> 53
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The given date</param>
    /// <param name="options">An class with options</param>
    /// <returns>The week</returns>
    public static int GetWeek(this DateTime dateTime, WeekYearOptions options = null)
    {
        (DayOfWeek weekStartsOn, _) = options ?? new WeekYearOptions();
        long diffTicks = dateTime.StartOfWeek(weekStartsOn).Ticks - dateTime.StartOfWeekYear(options).Ticks;
        const long ticksInWeek = TimeSpan.TicksPerDay * 7;
        int weekNumber = (int)(diffTicks / ticksInWeek) + 1;
        if (weekNumber <= 0) weekNumber = new DateTime(dateTime.Year - 1, 12, 31).GetWeek(options);
        return weekNumber;
    }
    /// <summary>
    /// Get the local week-numbering year of the given date. The exact calculation
    /// depends of the values of <see cref="WeekYearOptions.WeekStartsOn"/> (Which is the index of 
    /// the first day of the week) and <see cref="WeekYearOptions.FirstWeekContainsDate"/> (which is 
    /// the day of January, which is always in the first week of the week-numbering year)
    /// <example><code>
    /// // Which week numbering year is 26 December 2004 with the default settings?
    /// var result = new DateTime(2004, 12, 26).GetWeekYear();
    /// // -> 2005
    /// 
    /// // Which week numbering year is 26 December 2004 if week starts on Saturday?
    /// var result = new DateTime(2004, 12, 26).GetWeekYear(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Saturday });
    /// // -> 2004
    /// 
    /// // Which week numbering year is 26 December 2004 if the first week contains 4 January?
    /// var result = new DateTime(2004, 12, 26).GetWeekYear(new WeekYearOptions() { FirstWeekContainsDate = 4 });
    /// // -> 2004
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The given date</param>
    /// <param name="options">An class with options</param>
    /// <returns>The local week-numbering year</returns>
    public static int GetWeekYear(this DateTime dateTime, WeekYearOptions options = null)
    {
        (DayOfWeek weekStartsOn, int firstWeekContainsDate) = options ?? new WeekYearOptions();
        int year = dateTime.Year;

        var startOfThisYear = new DateTime(year, 1, firstWeekContainsDate).StartOfWeek(weekStartsOn);
        var startOfNextYear = new DateTime(year + 1, 1, firstWeekContainsDate).StartOfWeek(weekStartsOn);

        if (dateTime >= startOfNextYear) return year + 1;
        else if (dateTime >= startOfThisYear) return year;
        else return year - 1;
    }
    /// <summary>
    /// Get the week of the month of the given date
    /// </summary>
    /// <param name="dateTime">The given date</param>
    /// <param name="weekStartsOn"></param>
    /// <returns>The week of month</returns>
    /// <example><code>
    /// // Which week of the month is 9 November 2017
    /// var result = new DateTime(2017, 11, 9, 23, 55, 0).GetWeekOfMonth();
    /// //-> 2
    /// </code></example>
    public static int GetWeekOfMonth(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        var currentDayOfMonth = dateTime.Day;
        var startWeekDay = dateTime.StartOfMonth().DayOfWeek;
        var lastDayOfFirstWeek = weekStartsOn - startWeekDay;
        if (lastDayOfFirstWeek <= 0) lastDayOfFirstWeek += 7;
        var remainingDaysAfterFirstWeek = currentDayOfMonth - lastDayOfFirstWeek;
        return (int)Math.Ceiling(remainingDaysAfterFirstWeek / 7.0) + 1;
    }
    /// <summary>
    /// Get the number of calendar weeks a month spans
    /// <example><code>
    /// // How many calendar weeks does febreary 2015 span?
    /// var result = new DateTime(2015, 2, 8, 23, 55, 0).GetWeeksInMonth();
    /// // -> 4
    /// 
    /// // How many calendar weeks does febreary 2015 span, if the week starts on Monday
    /// var result = new DateTime(2017, 7, 5, 23, 55, 0).GetWeeksInMonth(DayOfWeek.Monday);
    /// // -> 6
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The given date</param>
    /// <param name="weekStartsOn"></param>
    /// <returns>The number of calendar weeks</returns>
    public static int GetWeeksInMonth(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday) => dateTime.LastDayOfMonth().DifferenceInCalendarWeeks(dateTime.StartOfMonth(), weekStartsOn) + 1;
    /// <summary>
    /// Get the week number of the year of the given date
    /// </summary>
    /// <param name="dateTime">The given date</param>
    /// <returns>The week number of the year</returns>
    /// <remarks>
    /// <example><code>
    /// // Which week number of the year is 2 September, 2024
    /// var result = new DateTime(2024, 9, 2, 23, 55, 0).WeekOfYear();
    /// //-> 36
    /// </code></example>
    /// </remarks>
    public static int WeekOfYear(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        DateTime jan1 = new(dateTime.Year, 1, 1);
        DateTime startOfWeek = jan1.StartOfWeek(weekStartsOn);
        return (dateTime - startOfWeek).Days / 7 + 1;
    }

    /// <summary>
    /// Is the given date in the same week as the current date?
    /// <example><code>
    /// // If today is 3 September, 2024, is 1 September 2024 in this week?
    /// var result = new DateTime(2024, 9, 1, 23, 55, 0).IsThisWeek();
    /// // -> True
    /// 
    /// // If today is 3 September, 2024 and week starts with Monday, is 1 September 2024 in this week?
    /// var result = new DateTime(2024, 9, 1, 23, 55, 0).IsThisWeek(DayOfWeek.Monday);
    /// // -> False
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date check</param>
    /// <param name="weekStartsOn"></param>
    /// <returns>The date is in this week</returns>
    public static bool IsThisWeek(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday) =>
        DateTime.Today.IsSameWeek(dateTime, weekStartsOn);
    /// <summary>
    /// Return the last day of a week for the given date.
    /// <example><code>
    /// // The last day of a week for 1 September 2024 23:55:00
    /// var result = new DateTime(2024, 9, 1, 23, 55, 0).LastDayOfWeek();
    /// //-> 9/7/2024 12:00:00 AM
    /// 
    /// // The last day of a week for 1 September 2024 23:55:00, if the week starts on Monday
    /// var result = new DateTime(2024, 9, 1, 23, 55, 0).LastDayOfWeek(DayOfWeek.Monday);
    /// //-> 9/1/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <param name="weekStartsOn"></param>
    /// <returns>The last day of a week</returns>
    public static DateTime LastDayOfWeek(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday) =>
        dateTime.StartOfWeek(weekStartsOn).AddDays(6);
    /// <summary>
    /// Set the local week to the given date.
    /// The exact calculation depends on the values of <see cref="WeekYearOptions.WeekStartsOn"/>
    /// (which is the index the first day of the week) and <see cref="WeekYearOptions.FirstWeekContainsDate"/>
    /// (which is the day of Januarym which is always in the first week of the week-numbering year)
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="week">The week of the new <see cref="DateTime"/></param>
    /// <param name="options">An class with options</param>
    /// <returns>Te new <see cref="DateTime"/> with the local week set</returns>
    /// <example><code>
    /// // Set the 1st week to 2 January 2005
    /// var result = new DateTime(2005, 1, 2, 23, 55, 0).SetWeek(1);
    /// // -> 12/26/2004 12:00:00 AM
    /// 
    /// // Set the 1st week to 2 January 2005, if Monday is the first day of the week and the first week of the year always
    /// contains 4 January
    /// var result = new DateTime(2005, 1, 2, 23, 55, 0).SetWeek(1, new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
    /// // -> 1/4/2004 12:00:00 AM
    /// </code></example>
    public static DateTime SetWeek(this DateTime dateTime, int week, WeekYearOptions options = null)
    {
        week = Math.Max(1, Math.Min(week, 53));
        options ??= new WeekYearOptions();
        int diff = (dateTime.GetWeek(options) - week) * 7;
        return dateTime.AddDays(-diff).Date;
    }
}

public class WeekYearOptions
{
    public int FirstWeekContainsDate { get; set; } = 1;
    public DayOfWeek WeekStartsOn { get; set; } = DayOfWeek.Sunday;
    public void Deconstruct(out DayOfWeek weekStartsOn, out int firstWeekContainsDate)
    {
        firstWeekContainsDate = FirstWeekContainsDate;
        weekStartsOn = WeekStartsOn;
    }

}