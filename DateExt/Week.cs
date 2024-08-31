using System;

namespace DateExt;

public static class Week
{
    public static DateTime AddWeeks(this DateTime dateTime, int amount)
    {
        int days = amount * 7;
        return dateTime.AddDays(days);
    }
}
