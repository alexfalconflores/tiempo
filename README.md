![Tiempo Cover](assets/tiempo-cover.jpg)
# Tiempo
[![NuGet](https://img.shields.io/nuget/dt/Tiempo.svg)](https://www.nuget.org/stats/packages/Tiempo?groupby=Version) 
[![NuGet](https://img.shields.io/nuget/vpre/Tiempo.svg)](https://www.nuget.org/packages/Tiempo/)
<a href="https://www.nuget.org/packages/Tiempo">
    <img src="https://raw.githubusercontent.com/alexfalconflores/alexfalconflores/main/img/nuget-banner.svg" height=20 alt="Go to Nuget"/>
</a>

<a href="#installation--">Installation 📦</a> | 
<a href="#documentation-">Documentation 📖</a> |
<a href="#support-">Support ⭐</a>

📅 Tiempo is a modern, lightweight library for date and time manipulation in C#. Tiempo provides a simple and consistent API that makes it easy to work with dates in any type of .NET application. From parsing and formatting dates to performing complex calculations and managing time zones, Tiempo provides you with all the tools you need to handle dates and times accurately and efficiently in your C# projects.

## Installation 📦
This project is available as a [NuGet package](https://www.nuget.org/packages/Tiempo). You can install it using the NuGet Package Console window:
```bash
dotnet add package Tiempo --version 0.0.3
```

## Documentation 📖

- [Day](docs/day.md)
    - [SubtractDays](docs/day.md#subtractdays)
    - [IsSameDay](docs/day.md#issameday)
    - [StartOfDay](docs/day.md#startofday)
    - [DifferenceInCalendarDays](docs/day.md#differenceincalendardays)
    - [DifferenceInBusinessDays](docs/day.md#differenceinbusinessdays)
    - [DifferenceInDays](docs/day.md#differenceindays)
    - [EndOfDay](docs/day.md#endofday)
    - [EndOfToday](docs/day.md#endoftoday)
    - [EndOfTomorrow](docs/day.md#endoftomorrow)
    - [EndOfYesterday](docs/day.md#endofyesterday)
    - [IsToday](docs/day.md#istoday)
    - [IsTomorrow](docs/day.md#istomorrow)
    - [IsYesterday](docs/day.md#isyesterday)
    - [SetDay](docs/day.md#setday)
    - [SetDayOfYear](docs/day.md#setdayofyear)
    - [StartOfToday](docs/day.md#startoftoday)
    - [StartOfTomorrow](docs/day.md#startoftomorrow)
    - [StartOfYesterday](docs/day.md#startofyesterday)
    - [AddBusinessDays](docs/day.md#addbusinessdays)
    - [SubtractBusinessDays](docs/day.md#subtractbusinessdays)
- [Weekday](docs/weekday.md)
    - [GetDayOfWeek](docs/weekday.md#getdayofweek)
    - [IsSunday](docs/weekday.md#issunday)
    - [IsMonday](docs/weekday.md#ismonday)
    - [IsTuesday](docs/weekday.md#istuesday)
    - [IsWednesday](docs/weekday.md#iswednesday)
    - [IsThursday](docs/weekday.md#isthursday)
    - [IsFriday](docs/weekday.md#isfriday)
    - [IsSaturday](docs/weekday.md#issaturday)
    - [IsWeekend](docs/weekday.md#isweekend)
    - [IsWeekdays](docs/weekday.md#isweekdays)
    - [NextDay (DayOfWeek)](docs/weekday.md#nextday-dayofweek)
    - [NextDay (int dayOfWeek)](docs/weekday.md#nextday-int-dayofweek)
    - [NextSunday](docs/weekday.md#nextsunday)
    - [NextMonday](docs/weekday.md#nextmonday)
    - [NextTuesday](docs/weekday.md#nexttuesday)
    - [NextWednesday](docs/weekday.md#nextwednesday)
    - [NextThursday](docs/weekday.md#nextthursday)
    - [NextFriday](docs/weekday.md#nextfriday)
    - [NextSaturday](docs/weekday.md#nextsaturday)
    - [PreviousDay (DayOfWeek)](docs/weekday.md#previousday-dayofweek)
    - [PreviousDay (int dayOfWeek)](docs/weekday.md#previousday-int-dayofweek)
    - [PreviousSunday](docs/weekday.md#previoussunday)
    - [PreviousMonday](docs/weekday.md#previousmonday)
    - [PreviousTuesday](docs/weekday.md#previoustuesday)
    - [PreviousWednesday](docs/weekday.md#previouswednesday)
    - [PreviousThursday](docs/weekday.md#previousthursday)
    - [PreviousFriday](docs/weekday.md#previousfriday)
    - [PreviousSaturday](docs/weekday.md#previoussaturday)
    - [SetDayOfWeek (`DayOfWeek`, `DayOfWeek weekStartsOn = DayOfWeek.Sunday`)](docs/weekday.md#setdayofweek-dayofweek-dayofweek-weekstartson--dayofweeksunday)
- [Week](docs/week.md)
    - [AddWeeks](docs/week.md#addweeks)
    - [SubtractWeeks](docs/week.md#subtractweeks)
    - [IsSameWeek](docs/week.md#issameweek-datetime-dayofweek-weekstartson--dayofweeksunday)
    - [StartOfWeek](docs/week.md#startofweek-dayofweek-weekstartson--dayofweeksunday)
    - [DifferenceInCalendarWeeks](docs/week.md#differenceincalendarweeks-datetime-dayofweek-weekstartson--dayofweeksunday)
    - [DifferenceInWeeks](docs/week.md#differenceinweeksdatetime)
    - [EndOfWeek](docs/week.md#endofweekdayofweek-weekstartson--dayofweeksunday)
    - [StartOfWeekYear](docs/week.md#startofweekyear-weekyearoptions-options--null)
    - [GetWeek](docs/week.md#getweek-weekyearoptions-options--null)
    - [GetWeekYear](docs/week.md#getweekyear-weekyearoptions-options--null)
    - [GetWeekOfMonth](docs/week.md#getweekofmonth-dayofweek-weekstartson--dayofweeksunday)
    - [GetWeeksInMonth](docs/week.md#getweeksinmonth-dayofweek-weekstartson--dayofweeksunday)
    - [WeekOfYear](docs/week.md#weekofyear-dayofweek-weekstartson--dayofweeksunday)
    - [IsThisWeek](docs/week.md#isthisweek-dayofweek-weekstartson--dayofweeksunday)
    - [LastDayOfWeek](docs/week.md#lastdayofweek-dayofweek-weekstartson--dayofweeksunday)
    - [SetWeek](docs/week.md#setweek-int-week-weekyearoptions-options--null)
    - [`class` WeekYearOptions](docs/week.md#class-weekyearoptions)
- [Month](docs/month.md)
    - [StartOfMonth](docs/month.md#startofmonth)
    - [LastDayOfMonth](docs/month.md#lastdayofmonth)

## Support ⭐
I am working to add more function. 
I would appreciate if you could give it a star⭐, thank you very much.. 🙏
