﻿using System;
using System.Xml.Schema;

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
}
