using System;
using System.Collections.Generic;

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
    /// <summary>
    /// Get the number of calendar months between the given dates.
    /// <example><code>
    /// int result = new DateTime(2013, 9, 1).DifferenceInCalendarMonths(new DateTime(2014, 9, 30));
    /// //-> 12
    /// </code></example>
    /// </summary>
    /// <param name="laterDate">The later date</param>
    /// <param name="earlierDate">The earlier date</param>
    /// <returns>The number of calendar months</returns>
    public static int DifferenceInCalendarMonths(this DateTime laterDate, DateTime earlierDate)
    {
        if (laterDate < earlierDate)
            (laterDate, earlierDate) = (earlierDate, laterDate);
        return (laterDate.Year - earlierDate.Year) * 12 + (laterDate.Month - earlierDate.Month);
    }
    /// <summary>
    /// Get the number of full months between the given dates.
    /// <example><code>
    /// var res = new DateTime(2021, 6, 28).DifferenceInMonths(new DateTime(2021, 1, 31));
    /// //-> 4
    /// </code></example>
    /// </summary>
    /// <param name="laterDate">The later date</param>
    /// <param name="earlierDate">The earlier date</param>
    /// <returns>The number of full months</returns>
    public static int DifferenceInMonths(this DateTime laterDate, DateTime earlierDate)
    {
        if (laterDate < earlierDate)
            (laterDate, earlierDate) = (earlierDate, laterDate);
        int totalMonths = (laterDate.Year - earlierDate.Year) * 12 + (laterDate.Month - earlierDate.Month);

        // Si no hay diferencia, retornamos 0
        if (totalMonths < 1) return 0;

        // Ajustamos el último mes si es necesario
        bool isLastMonthNotFull = laterDate.Day < DateTime.DaysInMonth(laterDate.Year, laterDate.Month)
            || (laterDate.IsLastDayOfMonth() && totalMonths == 1 && laterDate > earlierDate);

        // Devolvemos el resultado ajustando según si el último mes es completo
        return totalMonths - (isLastMonthNotFull ? 1 : 0);
    }
    /// <summary>
    /// Get all the Saturdays and Sundays in the given month.
    /// <example><code>
    /// List&lt;DateTime&gt; result = new DateTime(2022, 2, 1).EachWeekendOfMonth();
    /// //-> [
    /// // 2/5/2022 12:00:00 AM
    /// // 2/6/2022 12:00:00 AM
    /// // 2/12/2022 12:00:00 AM
    /// // 2/13/2022 12:00:00 AM
    /// // 2/19/2022 12:00:00 AM
    /// // 2/20/2022 12:00:00 AM
    /// // 2/26/2022 12:00:00 AM
    /// // 2/27/2022 12:00:00 AM
    /// // ]
    /// </code></example>
    /// </summary>
    /// <param name="date"> The given month</param>
    /// <returns>An array containing all the Saturdays and Sundays</returns>
    public static List<DateTime> EachWeekendOfMonth(this DateTime date)
    {
        DateTime start = new DateTime(date.Year, date.Month, 1);
        DateTime end = start.AddMonths(1).AddDays(-1);
        var weekends = new List<DateTime>();
        DateTime firstSaturday = start.AddDays((int)DayOfWeek.Saturday - (int)start.DayOfWeek + (int)(start.DayOfWeek > DayOfWeek.Saturday ? 7 : 0));
        // Agregar sábados y domingos hasta el final del mes
        for (DateTime current = firstSaturday; current <= end; current = current.AddDays(7))
        {
            weekends.Add(current); // Sábado
            if (current.AddDays(1) <= end)
            {
                weekends.Add(current.AddDays(1)); // Domingo
            }
        }
        return weekends;
    }
    /// <summary>
    /// Return the end of a month for the given date.
    /// <example><code>
    /// var result = new DateTime(2014, 9, 1, 11, 55, 0).EndOfMonth();
    /// // -> 9/30/2014 11:59:59 PM
    /// </code></example>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>The end of a month</returns>
    public static DateTime EndOfMonth(this DateTime dateTime) =>
        new(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59, 999);
    /// <summary>
    /// Gets the number of days in the month of the given date.
    /// <example><code>
    /// var result = new DateTime(2014, 9, 1, 11, 55, 0).GetDaysInMonth();
    /// //-> 30
    /// </code></example>
    /// </summary>
    /// <param name="date"></param>
    /// <returns>The number of days in the month.</returns>
    public static int GetDaysInMonth(this DateTime date) => DateTime.DaysInMonth(date.Year, date.Month);
    /// <summary>
    /// Checks if the given date is the first day of the month.
    /// <example><code>
    /// var result = new DateTime(2000, 2, 1, 11, 55, 0).IsFirstDayOfMonth();
    /// //-> true
    /// </code></example>
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the first day of the month, false otherwise.</returns>
    public static bool IsFirstDayOfMonth(this DateTime date) => date.Day == 1;
    /// <summary>
    /// Is the given date the last day of a month?
    /// <example><code>
    /// DateTime date = new DateTime(2014, 2, 28);
    /// var res = date.IsLastDayOfMonth()
    /// //-> True
    /// </code></example>
    /// </summary>
    /// <param name="date">The date to check</param>
    /// <returns>True if the date is the last day of the month; otherwise, false</returns>
    public static bool IsLastDayOfMonth(this DateTime date) => date.Day == DateTime.DaysInMonth(date.Year, date.Month);
    /// <summary>
    /// Checks if two given dates are in the same month and year.
    /// <example><code>
    /// var result = new DateTime(2000, 2, 1, 11, 55, 0).IsSameMonth(new DateTime(2000, 2, 5));
    /// //-> true
    /// 
    /// var result = new DateTime(2001, 2, 1, 11, 55, 0).IsSameMonth(new DateTime(2000, 2, 5));
    /// //-> false
    /// </code></example>
    /// </summary>
    /// <param name="firstDate"></param>
    /// <param name="secondDate"></param>
    /// <returns>True if the dates are in the same month and year, false otherwise.</returns>
    public static bool IsSameMonth(this DateTime firstDate, DateTime secondDate) => firstDate.Year == secondDate.Year && firstDate.Month == secondDate.Month;
    /// <summary>
    /// Checks if the given date is in the same month as the current date.
    /// <example><code>
    /// // -> Today , 2/1/2001
    /// var result = new DateTime(2001, 2, 1, 11, 55, 0).IsThisMonth();
    /// // -> true
    /// </code></example>
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is in the current month, false otherwise.</returns>
    public static bool IsThisMonth(this DateTime date)
    {
        DateTime now = DateTime.Now;
        return date.Year == now.Year && date.Month == now.Month;
    }
    /// <summary>
    /// Set the month to the given date.
    /// <example><code>
    /// var result = new DateTime(2001, 2, 16, 11, 55, 0).SetMonth(7);
    /// //-> 7/16/2001 11:55:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="date">The date to be changed</param>
    /// <param name="month">The month index to set (1-12)</param>
    /// <returns>The new date with the month set</returns>
    public static DateTime SetMonth(this DateTime date, int month)
    {
        // If month is outside the valid range (1-12), return the original date
        if (month < 1 || month > 12)
        {
            return date;
        }

        int year = date.Year;
        int day = date.Day;

        // Get the number of days in the target month
        int daysInMonth = DateTime.DaysInMonth(year, month);
        // Adjust the day if necessary (e.g., January 31 -> February 28/29)
        int adjustedDay = Math.Min(day, daysInMonth);
        // Return the new date with the adjusted day
        return new DateTime(year, month, adjustedDay, date.Hour, date.Minute, date.Second, date.Millisecond);
    }
    /// <summary>
    /// Subtract the specified number of months from the given date.
    /// <example><code>
    /// var result = new DateTime(2001, 7, 16, 11, 55, 0).SubMonths(1);
    /// // -> 6/16/2001 11:55:00 AM
    /// </code></example>
    /// </summary>
    /// <param name="date"></param>
    /// <param name="months"></param>
    /// <returns>The new date with the months subtracted</returns>
    public static DateTime SubMonths(this DateTime date, int months) => date.AddMonths(-months);
}
