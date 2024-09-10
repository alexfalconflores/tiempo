# Week

>```csharp
>using Tiempo;
>```

## AddWeeks
Add the specified number of weeks to the given date. `Return` The new `DateTime` with the weeks added.
```csharp
// Add 4 weeks to 1 September, 2024
var result = new DateTime(2024, 9, 1, 6, 0, 0).AddWeeks(4);
// -> 9/29/2024 6:00:00 AM
```

## SubtractWeeks
Subtract the specified number of weeks from the given date. `Return` The new `DateTime` with the weeks subtracted.
```csharp
// Subtract 4 weeks from 1 September, 2024
var result = new DateTime(2024, 9, 1, 6, 0, 0).SubtractWeeks(4);\
// -> 8/4/2024 6:00:00 AM
```

## IsSameWeek (`DateTime`, `DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Are the given dates in the same week (and month and year)? `Return` The dates are in the same week (and month and year).
```csharp
// Are 2 September 11:55:00 and 2 September 11:50:00 in the same week?
var result = new DateTime(2024, 9, 2, 11, 55, 0).IsSameWeek(new DateTime(2024, 9, 2, 11, 50, 0));
// -> True

// Are 30 September 11:55:00 and 3 Octuber 11:55:00 in the same week?
var result = new DateTime(2024, 9, 30, 11, 55, 0).IsSameWeek(new DateTime(2024, 10, 3, 11, 55, 0));
// -> True

// Are 2 September 11:55:00 and 3 Octuber 11:55:00 in the same week?
var result = new DateTime(2024, 9, 2, 11, 55, 0).IsSameWeek(new DateTime(2024, 10, 3, 11, 55, 0));
// -> False
```

## StartOfWeek (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
`Return` the start of a week for the given date.
```csharp
// The start of a week for 3 Octuber, 2024 11:55:00
var result = new DateTime(2024, 10, 3,11, 55, 0).StartOfWeek();
// -> 9/29/2024 12:00:00 AM

// If the week starts on Monday, the start of a week for 3 Octuber, 2024 11:55:00
var result = new DateTime(2024, 10, 3,11, 55, 0).StartOfWeek(DayOfWeek.Monday);
// -> 9/30/2024 12:00:00 AM
```

## DifferenceInCalendarWeeks (`DateTime`, `DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Get the number of calendar weeks between the given dates. `Return` The number of calendar weeks.
```csharp
// How many calendar weeks are between 5 July 2014 and 20 July 2014?
var result = new DateTime(2014, 7, 20, 11, 55, 0).DifferenceInCalendarWeeks(new DateTime(2014, 7, 5, 11, 50, 0));
// -> 3

// If the week starts on Monday,
// how many calendar weeks are between 5 July 2024 and 20 July 2024?
var result = new DateTime(2024, 7, 20, 11, 55, 0).DifferenceInCalendarWeeks(new DateTime(2024, 7, 5, 11, 50, 0), DayOfWeek.Monday);
// -> 2
```

## DifferenceInWeeks(`DateTime`)
Get the number of full weeks between the given dates. `Return` The number of full weeks.
```csharp
// How many full weeks are between 1 September, 2024 23:59:00 and 28 September, 2024?
var result = new DateTime(2024, 9, 1, 23, 59, 59).DifferenceInWeeks(new DateTime(2024, 9, 28, 0, 0, 0));
// -> 3
```

## EndOfWeek(`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
`Return` the end of a week for the given date.
```csharp
// The end of a week for 2 September 2024 11:55:00
var result = new DateTime(2024, 9, 2, 11, 55, 0).EndOfWeek();
// -> 9/6/2024 11:59:59 PM

// If the week starts on Monday, the end of a week for 2 September 2024 11:55:00
var result = new DateTime(2024, 9, 2, 11, 55, 0).EndOfWeek(DayOfWeek.Monday);
// -> 9/7/2024 11:59:59 PM 
```

## StartOfWeekYear (`WeekYearOptions options = null`)
Return the start of a local week-numbering year for the given date.
The exact calculation depends on the values of `WeekYearOptions.WeekStartsOn`
(which is the index of the first day of the week) and `WeekYearOptions.FirstWeekContainsDate` (which is the day of January, which is always in the first week of the week-numbering year). `Return` The start of a week-numbering year.
```csharp
// The start of a week-numbering year for 2 July. 2005
var result = new DateTime(2005, 7, 2).StartOfWeekYear();
// -> 12/26/2004 12:00:00 AM

// The start of a week-numbering year for 2 July. 2005,
// if Monday is the first day of week and 4 January is always in the first week of the year
var result = new DateTime(2005, 7, 2).StartOfWeekYear(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
// -> 1/3/2005 12:00:00 AM
```

## GetWeek (`WeekYearOptions options = null`)
Get the local week index of the given date. The exact calculatio depends on the values of `WeekYearOptions.WeekStartsOn`(which is the index of the first day of the week) and `WeekYearOptions.FirstWeekContainsDate` (which is the day of january, which is always in the first week of the week-numbering year). `Return` The week.
```csharp
// Which week of the local week numbering year is 2 January 2005?
var result = new DateTime(2005, 1, 2).GetWeek();
// -> 2

// Which week of the local week numbering year is 2 January 2005.
// if Monday is the first day of the week and the first week of the year always contains 4 January?
var result = new DateTime(2005, 1, 2).GetWeek(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
// -> 53
```

## GetWeekYear (`WeekYearOptions options = null`)
Get the local week-numbering year of the given date. The exact calculation
depends of the values of `WeekYearOptions.WeekStartsOn` (Which is the index of the first day of the week) and `WeekYearOptions.FirstWeekContainsDate` (which is the day of January, which is always in the first week of the week-numbering year). `Return` The local week-numbering year.
```csharp
// Which week numbering year is 26 December 2004 with the default settings?
var result = new DateTime(2004, 12, 26).GetWeekYear();
// -> 2005

// Which week numbering year is 26 December 2004 if week starts on Saturday?
var result = new DateTime(2004, 12, 26).GetWeekYear(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Saturday });
// -> 2004

// Which week numbering year is 26 December 2004 if the first week contains 4 January?
var result = new DateTime(2004, 12, 26).GetWeekYear(new WeekYearOptions() { FirstWeekContainsDate = 4 });
// -> 2004
```

## GetWeekOfMonth (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Get the week of the month of the given date. `Return` The week of month.
```csharp
// Which week of the month is 9 November 2017
var result = new DateTime(2017, 11, 9, 23, 55, 0).GetWeekOfMonth();
//-> 2
```

## GetWeeksInMonth (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Get the number of calendar weeks a month spans. `Return` The number of calendar weeks.
```csharp
// How many calendar weeks does febreary 2015 span?
var result = new DateTime(2015, 2, 8, 23, 55, 0).GetWeeksInMonth();
// -> 4

// How many calendar weeks does febreary 2015 span, if the week starts on Monday
var result = new DateTime(2017, 7, 5, 23, 55, 0).GetWeeksInMonth(DayOfWeek.Monday);
// -> 6
```

## WeekOfYear (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Get the week number of the year of the given date. `Return` The week number of the year.
```csharp
// Which week number of the year is 2 September, 2024
var result = new DateTime(2024, 9, 2, 23, 55, 0).WeekOfYear();
//-> 36
```

## IsThisWeek (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Is the given date in the same week as the current date? `Return` The date is in this week.
```csharp
// If today is 3 September, 2024, is 1 September 2024 in this week?
var result = new DateTime(2024, 9, 1, 23, 55, 0).IsThisWeek();
// -> True

// If today is 3 September, 2024 and week starts with Monday, is 1 September 2024 in this week?
var result = new DateTime(2024, 9, 1, 23, 55, 0).IsThisWeek(DayOfWeek.Monday);
// -> False
```

## LastDayOfWeek (`DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
`Return` the last day of a week for the given date.
```csharp
// The last day of a week for 1 September 2024 23:55:00
var result = new DateTime(2024, 9, 1, 23, 55, 0).LastDayOfWeek();
//-> 9/7/2024 12:00:00 AM

// The last day of a week for 1 September 2024 23:55:00, if the week starts on Monday
var result = new DateTime(2024, 9, 1, 23, 55, 0).LastDayOfWeek(DayOfWeek.Monday);
//-> 9/1/2024 12:00:00 AM
```

## SetWeek (`int week`, `WeekYearOptions options = null`)
Set the local week to the given date. The exact calculation depends on the values of WeekYearOptions.WeekStartsOn (which is the index the first day of the week) and WeekYearOptions.FirstWeekContainsDate (which is the day of January which is always in the first week of the week-numbering year). `Return` Te new `DateTime` with the local week set.
```csharp
// Set the 1st week to 2 January 2005
var result = new DateTime(2005, 1, 2, 23, 55, 0).SetWeek(1);
// -> 12/26/2004 12:00:00 AM

// Set the 1st week to 2 January 2005, if Monday is the first day of the week and the first week of the year always contains 4 January
var result = new DateTime(2005, 1, 2, 23, 55, 0).SetWeek(1, new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 });
// -> 1/4/2004 12:00:00 AM
```

## `class` WeekYearOptions
```csharp
// Deconstruct
(DayOfWeek weekStartsOn, int firstWeekContainsDate) = options ?? new WeekYearOptions();
```
