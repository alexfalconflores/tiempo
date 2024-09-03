using BenchmarkDotNet.Attributes;

namespace Console_Test.Week;

public class IsSameWeek
{
    private readonly DateTime date = new(2024, 9, 2, 11, 55, 0);
    private readonly DateTime dateS = new(2024, 9, 2, 11, 55, 0);
    private readonly DateTime date2 = new DateTime(2024, 10, 3,11, 55, 0);

    [Benchmark]
    public bool IsSameWeek_1_OK()
    {
        return date.IsSameWeek_1(dateS);
    }

    [Benchmark]
    public bool IsSameWeek_2_OK()
    {
        return date.IsSameWeek_2(dateS);
    }

    [Benchmark]
    public bool IsSameWeek_1_BAD()
    {
        return date.IsSameWeek_1(date2);
    }

    [Benchmark]
    public bool IsSameWeek_2_BAD()
    {
        return date.IsSameWeek_2(date2);
    }
}

static class Test1
{
    public static bool IsSameWeek_1(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday) =>
        dateTimeLeft.StartOfWeek_2(weekStartsOn).Equals(dateTimeRight.StartOfWeek_2(weekStartsOn));

    public static bool IsSameWeek_2(this DateTime dateTimeLeft, DateTime dateTimeRight, DayOfWeek weekStartsOn = DayOfWeek.Sunday)
    {
        var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
        var leftWeek = calendar.GetWeekOfYear(dateTimeLeft, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);
        var rightWeek = calendar.GetWeekOfYear(dateTimeRight, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn);

        return leftWeek == rightWeek && dateTimeLeft.Year == dateTimeRight.Year;
    }
}
