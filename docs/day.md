# Day

>```csharp
>using Tiempo;
>```

## SubtractDays
Subtract the specified number of days from the given date. `Return` The new `DateTime` with the days subtracted.
```csharp
// Subtract 10 days from 31 august, 2024?
var result = new DateTime(2024, 8, 31).SubtractDays(10);
// 21 august, 2024 -> 8/21/2024 12:00:00 AM
```

## IsSameDay
Are the given dates in the same day (and year and month)? `Return` The date are in the same day (and year and month).
```csharp
//Are 31 August 06:00:00 and 31 August 18:00:00 in the same day?
var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
// -> True
 
//Are 30 August and 30 September in the same day?
 var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
// -> False

//Are 31 August, 2024 and 31 August, 2023 in the same day?
var result = new DateTime(2024, 8, 31, 6,0,0).IsSameDay(new DateTime(2024, 8, 31, 18, 0,0));
// -> False
```

## StartOfDay
`Return` the start of a day for the given date.
```csharp
//The start of a day for 31 August, 2024 06:00:00
var result = new DateTime(2024, 8, 31, 6,0,0).StartOfDay();
// -> 8/31/2024 12:00:00 AM
```

## DifferenceInCalendarDays
Get the number of calendar days between the given dates. This means that times are removed from the dates and then the difference in days is calculated. `Return` The number of calendar days.

```csharp
// How many calendar days are between
// 31 August, 2024 06:00:00 and 30 August, 2024 00:00:00
var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2024, 8, 30));
// -> 1
 
// How many calendar days are between
// 31 August, 2024 06:00:00 and 31 August, 2023 00:00:00
var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2023, 8, 31));
// -> 366
```

## DifferenceInBusinessDays
Get the number of business day between the given dates. Business days being days that aren't in the weekend. Like `date1.DifferenceInCalendarDays(DateTime)`, the function removes the times from the dates before calculating the difference. `Return` The number of business days.
```csharp
// How many business days are between
// 31 August, 2024 06:00:00 and 29 August, 2024 00:00:00
var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2024, 8, 29));
// -> 2
 
// How many business days are between
// 31 August, 2024 06:00:00 and 31 August, 2023 00:00:00
var res = new DateTime(2024, 8, 31, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2023, 8, 31));
// -> 262

// How many business days are between
// 1 November, 2021 06:00:00 and 1 December, 2021 00:00:00
var res = new DateTime(2021, 11, 1, 6, 0, 0).DifferenceInCalendarDays(new DateTime(2021, 12, 1));
// -> -22
```

## DifferenceInDays
Get the number of full days between the given dates. One "full day" is the distance between a local time in one day to the same local time on the next or previous day. A full day can sometimes be less than or more than 24 hours if a daylight savings change happens between two dates. `Return` The number of full days according to the local timezone.
```csharp
// How many full days are between
2 July, 2011 23:00:00 and 2 July, 2012 00:00:00?
var result = new DateTime(2012, 7,2, 0, 0, 0).DifferenceInDays(new DateTime(2011, 7, 2, 23, 0, 0));
// -> 365

// How many full days are between
2 July, 2011 23:59:00 and 3 July, 2011 00:01:00?
var result = new DateTime(2011, 7, 3, 0, 1, 0).DifferenceInDays(new DateTime(2011, 7, 2, 23, 59, 0));
// -> 0

// How many full days are between
1 March, 2020 00:00 and 1 June, 2020 00:00?
var result = new DateTime(2020, 6, 1, 0, 0, 0).DifferenceInDays(new DateTime(2020, 3, 1, 0, 0, 0));
// -> 92
```

## EndOfDay
`Return` the end of a day for the given date.
```csharp
// The end of a day for 1 September, 2024 11:55:00 AM
var result = new DateTime(2024, 9, 1, 11,55,0).EndOfDay();
// -> 9/1/2024 11:59:59 PM
```

## EndOfToday
`Return` the end of `DateTime.Today`.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.EndOfToday();
// -> 9/1/2024 11:59:59 PM
```

## EndOfTomorrow
`Return` the end of tomorrow.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.EndOfTomorrow();
// -> 9/2/2024 11:59:59 PM
```

## EndOfYesterday
`Return` the end of yesterday.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.EndOfTomorrow();
// -> 8/31/2024 11:59:59 PM
```

## IsToday
Is the given date today? `Return` The date to check.
```csharp
// If today is 1 September, 2024, is 1 September, 2024 11:55:00 today?
var result = new DateTime(2024, 9, 1, 11,55,0).IsToday();
// -> True
```

## IsTomorrow
Is the given date tomorrow? `Return` The date is tomorrow.
```csharp
// If today is 1 September, 2024, is 2 September, 2024 06:00:00 tomorrow?
var result = new DateTime(2024, 9, 2, 6, 0, 0).IsTomorrow();
// -> True
```

## IsYesterday
Is the given date yesterday? `Return` The date is yesterday.
```csharp
// If today is 1 September, 2024, is 31 August, 2024 06:00:00 yesterday?
var result = new DateTime(2024, 9, 2, 6, 0, 0).IsYesterday();
// -> True
```

## SetDay
Set the day of the month to the given date. `Return` The new `DateTime` with the day of the month set.
```csharp
// Set the 10th day of the month to 31 August, 2024 06:00:00
var result = new DateTime(2024, 8, 31, 6, 0, 0).SetDay(10);
// -> 8/10/2024 6:00:00 AM
```

## SetDayOfYear
Set the day of the year to the given date. `Return` The new `DateTime` with the day of the year set.
```csharp
// Set the 2nd day of the year to 31 August, 2024 06:00:00
var result = new DateTime(2024, 8, 31, 6, 0, 0).SetDay(2);
// -> 1/2/2024 12:00:00 AM
```

## StartOfToday
`Return` the start of `DateTime.Today`.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.StartOfToday();
// -> 9/1/2024 12:00:00 AM
```

## StartOfTomorrow
`Return` the start of tomorrow.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.StartOfTomorrow();
// -> 9/2/2024 12:00:00 AM
```

## StartOfYesterday
`Return` the start of yesterday.
```csharp
// If today is 1 September, 2024
var result = DateTime.Today.EndOfTomorrow();
// -> 8/31/2024 12:00:00 AM
```

## AddBusinessDays
Add the specified number of business days (monday - friday) to the given date, ignoraring weekends. `Return` The new `DateTime` with the business days added.
```csharp
//Add 10 business days to 1 September, 2024
var result = new DateTime(2024, 9, 1, 6, 0, 0).AddBusinessDays(10);
// -> 9/16/2024 6:00:00 AM
```

## SubtractBusinessDays
Subtract the specified number of business days (monday - friday) to the given date, ignoring weekends. `Return` The new `DateTime` with the business days subtracted.
```csharp
// Subtract 10 business days from 1 September, 2024
var result = new DateTime(2024, 9, 1, 6, 0, 0).SubtractBusinessDays(10);
// -> 8/17/2024 6:00:00 AM
```

