using BenchmarkDotNet.Attributes;

namespace Console_Test.Week;

public class DifferenceInCalendarWeeks
{
    private readonly DateTime date = new(2014, 7, 20, 11, 55, 0);
    private readonly DateTime date2 = new DateTime(2014, 7, 5, 11, 50, 0);

    [Benchmark]
    public DateTime DifferenceInCalendarWeeks_T()
    {
        return date.AddBusinessDays1(20);
    }
    [Benchmark]
    public DateTime DifferenceInCalendarWeeks_N()
    {
        return date.AddBusinessDays2(20);
    }
}

static class Tests
{
    public static int DifferenceInCalendarWeeks_1(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        DateTime startOfWeekLeft = dateTimeLeft.StartOfWeek_2(weekStartsOn);
        DateTime startOfWeekRight = dateTimeRight.StartOfWeek_2(weekStartsOn);
        TimeSpan diff = startOfWeekLeft - startOfWeekRight;
        return (diff.Days) / 7;
    }

    public static int DifferenceInCalendarWeeks_2(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
        int leftWeek = calendar.GetWeekOfYear(dateTimeLeft, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);
        int rightWeek = calendar.GetWeekOfYear(dateTimeRight, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);

        return (leftWeek - rightWeek) + (dateTimeLeft.Year - dateTimeRight.Year) * 52;
    }

}