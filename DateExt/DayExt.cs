using System;

namespace DateExt;

public static class DayExt
{
    /// <summary>
    /// Subtract the specified number of days from the given date.
    /// <example><code>
    /// // Subtract 10 days from 31 august, 2024?
    /// var result = new DateTime(2024, 8, 31).SubtractDays(10);
    /// // 21 august, 2024 -> 8/21/2024 12:00:00 AM
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
    /// //The start of a day for 31 August, 2024 06:00:00
    /// var result = new DateTime(2024, 8, 31, 6,0,0).StartOfDay();
    /// // -> 8/31/2024 12:00:00 AM
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The original date</param>
    /// <returns>The start of a day</returns>
    public static DateTime StartOfDay(this DateTime dateTime) => dateTime.Date;
    /// <summary>
    /// Get the number of calendar days between the given dates. This means that times are removed 
    /// from the dates and then the difference in days is calculated.
    /// <example><code>
    /// // How many calendar days are between
    /// // 31 August, 2024 06:00:00 and 30 August, 2024 00:00:00
    /// var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2024, 8, 30));
    /// // -> 1
    /// 
    /// // How many calendar days are between
    /// // 31 August, 2024 06:00:00 and 31 August, 2023 00:00:00
    /// var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2023, 8, 31));
    /// // -> 366
    /// </code></example>
    /// </summary>
    /// <param name="dateTimeLeft">The later date</param>
    /// <param name="dateTimeRight">The earlier date</param>
    /// <returns>The nuber of calendar days</returns>
    public static int DifferenceInCalendarDays(this DateTime dateTimeLeft, DateTime dateTimeRight)
    {
        DateTime startOfDayLeft = dateTimeLeft.StartOfDay();
        DateTime startOfDayRight = dateTimeRight.StartOfDay();
        TimeSpan diff = startOfDayLeft - startOfDayRight;
        return diff.Days;
    }
    /// <summary>
    /// Get the number of business day between the given dates.
    /// Businnes days being days that aren't in the weekend.
    /// Like <see cref="DifferenceInCalendarDays(DateTime, DateTime)"/>, the function removes the times from
    /// the dates before calculating the difference.
    /// <example><code>
    /// // How many business days are between
    /// // 31 August, 2024 06:00:00 and 29 August, 2024 00:00:00
    /// var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2024, 8, 29));
    /// // -> 2
    /// 
    /// // How many business days are between
    /// // 31 August, 2024 06:00:00 and 31 August, 2023 00:00:00
    /// var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2023, 8, 31));
    /// // -> 262
    ///
    /// // How many business days are between
    /// // 1 November, 2021 06:00:00 and 1 December, 2021 00:00:00
    /// var res = new DateTime(2021, 11, 1, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2021, 12, 1));
    /// // -> -22
    /// </code></example>
    /// </summary>
    /// <param name="dateTimeLeft">The later date</param>
    /// <param name="dateTimeRight">The earlier date</param>
    /// <returns>The number of business days</returns>
    public static int DifferenceInBusinessDays(this DateTime dateTimeLeft, DateTime dateTimeRight)
    {
        if (IsSameDay(dateTimeLeft, dateTimeRight)) return 0;

        bool isNegative = dateTimeLeft < dateTimeRight;
        if (isNegative) (dateTimeLeft, dateTimeRight) = (dateTimeRight, dateTimeLeft);

        int calendarDifference = dateTimeLeft.DifferenceInCalendarDays(dateTimeRight);

        int fullWeeks = calendarDifference / 7;
        int businessDays = fullWeeks * 5;

        dateTimeRight = dateTimeRight.AddDays(fullWeeks * 7);

        while (!IsSameDay(dateTimeLeft, dateTimeRight))
        {
            if (!dateTimeRight.IsWeekend())
                businessDays++;
            dateTimeRight = dateTimeRight.AddDays(1);
        }

        return isNegative ? -businessDays : businessDays;
    }
    /// <summary>
    /// Get the number of full days between the given dates. One "full day" is the distance between
    /// a local time in one day to the same local time on the next or previous day. A full day can sometimes
    /// be less than or more than 24 hours if a daylight savings change happens between two dates.
    /// <example><code>
    /// // How many full days are between
    /// 2 July, 2011 23:00:00 and 2 July, 2012 00:00:00?
    /// var result = new DateTime(2012, 7,2, 0, 0, 0).DifferenceInDays(new DateTime(2011, 7, 2, 23, 0, 0));
    /// // -> 365
    /// 
    /// // How many full days are between
    /// 2 July, 2011 23:59:00 and 3 July, 2011 00:01:00?
    /// var result = new DateTime(2011, 7, 3, 0, 1, 0).DifferenceInDays(new DateTime(2011, 7, 2, 23, 59, 0));
    /// // -> 0
    /// 
    /// // How many full days are between
    /// 1 March, 2020 00:00 and 1 June, 2020 00:00?
    /// var result = new DateTime(2020, 6, 1, 0, 0, 0).DifferenceInDays(new DateTime(2020, 3, 1, 0, 0, 0));
    /// // -> 92
    /// </code></example>
    /// <example><code>
    /// </code></example>
    /// </summary>
    /// <param name="dateTimeLeft">The later date</param>
    /// <param name="dateTimeRight">The earlier date</param>
    /// <returns>The number of full days according to the local timezone</returns>
    public static int DifferenceInDays(this DateTime dateTimeLeft, DateTime dateTimeRight) => (dateTimeLeft - dateTimeRight).Days;
    /// <summary>
    /// Return the end of a day for the given date.
    /// <example><code>
    /// // The end of a day for 1 September, 2024 11:55:00 AM
    /// var result = new DateTime(2024, 9, 1, 11,55,0).EndOfDay();
    /// // -> 9/1/2024 11:59:59 PM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The original <see cref="DateTime"/></param>
    /// <returns>The end of a day</returns>
    public static DateTime EndOfDay(this DateTime dateTime)
        => new(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
    /// <summary>
    /// Return the end of <see cref="DateTime.Today"/>.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.EndOfToday();
    /// // -> 9/1/2024 11:59:59 PM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The end of <see cref="DateTime.Today"/></returns>
    public static DateTime EndOfToday(this DateTime dateTime) => dateTime.EndOfDay();
    /// <summary>
    /// Return the end of tomorrow.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.EndOfTomorrow();
    /// // -> 9/2/2024 11:59:59 PM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The end of tomorrow</returns>
    public static DateTime EndOfTomorrow(this DateTime dateTime) => dateTime.AddDays(1).EndOfDay();
    /// <summary>
    /// Return the end of yesterday.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.EndOfTomorrow();
    /// // -> 8/31/2024 11:59:59 PM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The end of yesterday</returns>
    public static DateTime EndOfYesterday(this DateTime dateTime) => dateTime.SubtractDays(1).EndOfDay();
    /// <summary>
    /// Is the given date today?
    /// <example><code>
    /// // If today is 1 September, 2024, is 1 September, 2024 11:55:00 today?
    /// var result = new DateTime(2024, 9, 1, 11,55,0).IsToday();
    /// // -> True
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date to check</returns>
    public static bool IsToday(this DateTime dateTime) => DateTime.Today.IsSameDay(dateTime);
    /// <summary>
    /// Is the given date tomorrow?
    /// <example><code>
    /// // If today is 1 September, 2024, is 2 September, 2024 06:00:00 tomorrow?
    /// var result = new DateTime(2024, 9, 2, 6, 0, 0).IsTomorrow();
    /// // -> True
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is tomorrow</returns>
    public static bool IsTomorrow(this DateTime dateTime) => DateTime.Today.AddDays(1).IsSameDay(dateTime);
    /// <summary>
    /// Is the given date yesterday?
    /// <example><code>
    /// // If today is 1 September, 2024, is 31 August, 2024 06:00:00 yesterday?
    /// var result = new DateTime(2024, 9, 2, 6, 0, 0).IsYesterday();
    /// // -> True
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The date is yesterday</returns>
    public static bool IsYesterday(this DateTime dateTime) => DateTime.Today.SubtractDays(1).IsSameDay(dateTime);
    /// <summary>
    /// Set the day of the month to the given date.
    /// <example><code>
    /// // Set the 10th day of the month to 31 August, 2024 06:00:00
    /// var result = new DateTime(2024, 8, 31, 6, 0, 0).SetDay(10);
    /// // -> 8/10/2024 6:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="dayOfMonth">The day of the month of the new <see cref="DateTime"/></param>
    /// <returns>The new <see cref="DateTime"/> with the day of the month set</returns>
    public static DateTime SetDay(this DateTime dateTime, int dayOfMonth = 1)
    {
        int daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        dayOfMonth = Math.Max(1, Math.Min(dayOfMonth, daysInMonth));
        return dateTime.Day == dayOfMonth
            ? dateTime
            : new DateTime(dateTime.Year, dateTime.Month, dayOfMonth, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);
    }
    /// <summary>
    /// Set the day of the year to the given date.
    /// <example><code>
    /// // Set the 2nd day of the year to 31 August, 2024 06:00:00
    /// var result = new DateTime(2024, 8, 31, 6, 0, 0).SetDay(2);
    /// // -> 1/2/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="dayOfMonth">The day of the year of the new <see cref="DateTime"/></param>
    /// <returns>The new <see cref="DateTime"/> with the day of the year set</returns>
    public static DateTime SetDayOfYear(this DateTime dateTime, int dayOfYear)
    {
        int year = dateTime.Year;
        bool isLeapYear = DateTime.IsLeapYear(year);
        int maxDays = isLeapYear ? 366 : 365;
        dayOfYear = Math.Max(1, Math.Min(dayOfYear, maxDays));
        if (dateTime.DayOfYear == dayOfYear) return dateTime;

        int[] daysToMonth = isLeapYear
        ? [0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366]  // Año bisiesto
        : [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365]; // Año no bisiesto

        int month = 1;
        while (dayOfYear > daysToMonth[month]) month++;
        int day = dayOfYear - daysToMonth[month - 1];

        return new DateTime(year, month, day, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
    /// <summary>
    /// Return the start of <see cref="DateTime.Today"/>.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.StartOfToday();
    /// // -> 9/1/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The start of <see cref="DateTime.Today"/></returns>
    public static DateTime StartOfToday(this DateTime dateTime) => dateTime.StartOfDay();
    /// <summary>
    /// Return the start of tomorrow.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.StartOfTomorrow();
    /// // -> 9/2/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The start of tomorrow</returns>
    public static DateTime StartOfTomorrow(this DateTime dateTime) => dateTime.AddDays(1).StartOfDay();
    /// <summary>
    /// Return the start of yesterday.
    /// <example><code>
    /// // If today is 1 September, 2024
    /// var result = DateTime.Today.EndOfTomorrow();
    /// // -> 8/31/2024 12:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"><see cref="DateTime.Today"/></param>
    /// <returns>The start of yesterday</returns>
    public static DateTime StartOfYesterday(this DateTime dateTime) => dateTime.SubtractDays(1).StartOfDay();
    /// <summary>
    /// Add the specified number of business days (monday - friday) to the given date, ignoraring weekends.
    /// <example><code>
    /// //Add 10 business days to 1 September, 2024
    /// var result = new DateTime(2024, 9, 1, 6, 0, 0).AddBusinessDays(10);
    /// // -> 9/16/2024 6:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="amount">The amount of business days to be added.</param>
    /// <returns>The new <see cref="DateTime"/> with the business days added</returns>
    public static DateTime AddBusinessDays(this DateTime dateTime, int amount)
    {
        if (amount == 0) return dateTime;
        long ticks = dateTime.Ticks;
        int sign = amount < 0 ? -1 : 1;
        int absAmount = Math.Abs(amount);
        int fullWeeks = absAmount / 5;
        ticks += fullWeeks * 7 * TimeSpan.TicksPerDay * sign;
        int restDays = absAmount % 5;
        while (restDays > 0)
        {
            ticks += TimeSpan.TicksPerDay * sign;
            DayOfWeek dayOfWeek = (DayOfWeek)((ticks / TimeSpan.TicksPerDay + 1) % 7);
            if (dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Sunday) restDays--;
        }
        DayOfWeek finalDayOfWeek = (DayOfWeek)((ticks / TimeSpan.TicksPerDay + 1) % 7);
        if (finalDayOfWeek == DayOfWeek.Saturday) ticks += TimeSpan.TicksPerDay * 2 * sign;
        else if (finalDayOfWeek == DayOfWeek.Sunday) ticks += TimeSpan.TicksPerDay * sign;
        return new DateTime(ticks);
    }
    /// <summary>
    /// Subtract the specified number of business days (monday - friday) to the given date, ignoring weekends.
    /// <example><code>
    /// // Subtract 10 business days from 1 September, 2024
    /// var result = new DateTime(2024, 9, 1, 6, 0, 0).SubtractBusinessDays(10);
    /// // -> 8/17/2024 6:00:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime">The date to be changed</param>
    /// <param name="amount">The amount of business days to be subtracted</param>
    /// <returns>The new <see cref="DateTime"/> with the business days subtracted</returns>
    public static DateTime SubtractBusinessDays(this DateTime dateTime, int amount) => dateTime.AddBusinessDays(-amount);
}
