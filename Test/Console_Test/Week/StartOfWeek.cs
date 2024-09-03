using BenchmarkDotNet.Attributes;

namespace Console_Test.Week;

public class StartOfWeek
{
    private readonly DateTime date = new(2024, 9, 2, 11, 55, 0);

    [Benchmark]
    public DateTime StartOfWeek_1()
    {
        return date.StartOfWeek_1();
    }

    [Benchmark]
    public DateTime StartOfWeek_2()
    {
        return date.StartOfWeek_2();
    }
}

static class Test
{
    public static DateTime StartOfWeek_1(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        int dayOfWeek = dateTime.DayOfWeek.GetHashCode();
        int dayStart = weekStartsOn.GetHashCode();
        int diff = (dayOfWeek < dayStart ? 6 : 0) + dayOfWeek - dayStart;
        dateTime = dateTime.SetDay(dateTime.Day - diff);
        return dateTime.Date;
    }

    public static DateTime StartOfWeek_2(this DateTime dateTime, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        int diff = (7 + (dateTime.DayOfWeek - weekStartsOn)) % 7;
        return dateTime.AddDays(-1 * diff).Date;
    }

    public static DateTime SetDay(this DateTime dateTime, int dayOfMonth = 1)
    {
        int daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        dayOfMonth = Math.Max(1, Math.Min(dayOfMonth, daysInMonth));
        return dateTime.Day == dayOfMonth
            ? dateTime
            : new DateTime(dateTime.Year, dateTime.Month, dayOfMonth, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);
    }
}