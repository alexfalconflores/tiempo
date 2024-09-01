using BenchmarkDotNet.Attributes;

namespace Console_Test;

//var date = new DateTime(2024, 9, 1, 6, 0, 0);
//var date2 = new DateTime(2024, 9, 10);
//var date3 = DateTime.Today;

//Console.WriteLine(date.AddBusinessDays1(10));
//Console.WriteLine(date.AddBusinessDays1(-10));
//Console.WriteLine(date2.AddBusinessDays1(-7));
//Console.WriteLine(date3.AddBusinessDays1(7));

public class BusinessDaysBenchmark
{
    private readonly DateTime date = new(2024, 9, 1, 6, 0, 0);
    private readonly DateTime date2 = new(2024, 9, 10);
    private readonly DateTime date3 = DateTime.Today;

    [Benchmark]
    public DateTime AddBusinessDaysTradicional_Add10()
    {
        return date.AddBusinessDays1(20);
    }
    [Benchmark]
    public DateTime AddBusinnesDaysTicks_Add10()
    {
        return date.AddBusinessDays2(20);
    }
    [Benchmark]
    public DateTime AddBusinessDaysTradicional_Sub10()
    {
        return date.AddBusinessDays1(-20);
    }
    [Benchmark]
    public DateTime AddBusinnesDaysTicks_Sub10()
    {
        return date.AddBusinessDays2(-20);
    }
    [Benchmark]
    public DateTime Add2BusinessDaysTradicional_Sub7()
    {
        return date2.AddBusinessDays1(-7);
    }
    [Benchmark]
    public DateTime Add2BusinnesDaysTicks_Sub7()
    {
        return date2.AddBusinessDays2(-7);
    }
    [Benchmark]
    public DateTime Add3BusinessDaysTradicional_Add7()
    {
        return date3.AddBusinessDays1(7);
    }
    [Benchmark]
    public DateTime Add3BusinnesDaysTicks_Add7()
    {
        return date3.AddBusinessDays2(7);
    }
}

static class Test
{
    public static DateTime AddBusinessDays1(this DateTime dateTime, int amount)
    {
        //2
        if (amount == 0) return dateTime;
        int sign = amount < 0 ? -1 : 1;
        int absAmount = Math.Abs(amount);

        int fullWeeks = absAmount / 5;
        dateTime = dateTime.AddDays(fullWeeks * 7 * sign);
        int restDays = absAmount % 5;
        while (restDays > 0)
        {
            dateTime = dateTime.AddDays(sign);
            if (!dateTime.IsSaturday() && !dateTime.IsSunday()) restDays--;
        }
        //if (dateTime.IsSaturday()) dateTime = dateTime.AddDays(sign > 0 ? 2 : -1);
        if (dateTime.IsSaturday()) dateTime = dateTime.AddDays(sign * 2);
        //else if (dateTime.IsSunday()) dateTime = dateTime.AddDays(sign > 0 ? 1 : -2);
        else if (dateTime.IsSunday()) dateTime = dateTime.AddDays(sign);
        return dateTime;
    }
    public static DateTime AddBusinessDays2(this DateTime dateTime, int amount)
    {
        //3
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

    static bool IsSaturday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday;
    static bool IsSunday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Sunday;
}
