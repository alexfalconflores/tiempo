# Month
>```csharp
>using Tiempo;
>```

## StartOfMonth
`Return` the start of a month for the given date.
```csharp
// The start of a month for 2 September 2024 23:55:00
var result = new DateTime(2024, 9, 2, 23, 55, 0).StartOfMonth();
// -> 9/1/2024 12:00:00 AM
```

## LastDayOfMonth
`Return` the last day of a month for the given date.
```csharp
// The last day of a month for 2 September 2024
var result = new DateTime(2024, 9, 2, 23, 55, 0).LastDayOfMonth();
//-> 9/30/2024 12:00:00 AM
```

## DifferenceInCalendarMonths
Get the number of calendar months between the given dates.
`Return` The number of calendar months.
```csharp
int result = new DateTime(2013, 9, 1).DifferenceInCalendarMonths(new DateTime(2014, 9, 30));
//-> 12
```

## DifferenceInMonths
Get the number of full months between the given dates.
`Return` The number of full months
```csharp
var res = new DateTime(2021, 6, 28).DifferenceInMonths(new DateTime(2021, 1, 31));
//-> 4
```

## EachWeekendOfMonth
Get all the Saturdays and Sundays in the given month.
`Return` An array containing all the Saturdays and Sundays.
```csharp
List<DateTime> result = new DateTime(2022, 2, 1).EachWeekendOfMonth();
//-> [
// 2/5/2022 12:00:00 AM
// 2/6/2022 12:00:00 AM
// 2/12/2022 12:00:00 AM
// 2/13/2022 12:00:00 AM
// 2/19/2022 12:00:00 AM
// 2/20/2022 12:00:00 AM
// 2/26/2022 12:00:00 AM
// 2/27/2022 12:00:00 AM
// ]
```

## EndOfMonth
`Return` the end of a month for the given date.
```csharp
var result = new DateTime(2014, 9, 1, 11, 55, 0).EndOfMonth();
// -> 9/30/2014 11:59:59 PM
```

## GetDaysInMonth
Gets the number of days in the month of the given date.
`Return` The number of days in the month.
```csharp
var result = new DateTime(2014, 9, 1, 11, 55, 0).GetDaysInMonth();
//-> 30
```

## IsFirstDayOfMonth
Checks if the given date is the first day of the month.
`Return` True if the date is the first day of the month, false otherwise.
```csharp
var result = new DateTime(2000, 2, 1, 11, 55, 0).IsFirstDayOfMonth();
//-> true
```

## IsLastDayOfMonth
Is the given date the last day of a month?
`Return` True if the date is the last day of the month; otherwise, false.
```csharp
DateTime date = new DateTime(2014, 2, 28);
var res = date.IsLastDayOfMonth()
//-> True
```

## IsSameMonth
Checks if two given dates are in the same month and year.
`Return` True if the dates are in the same month and year, false otherwise.
```csharp
var result = new DateTime(2000, 2, 1, 11, 55, 0).IsSameMonth(new DateTime(2000, 2, 5));
//-> true

var result = new DateTime(2001, 2, 1, 11, 55, 0).IsSameMonth(new DateTime(2000, 2, 5));
//-> false
```

## IsThisMonth
Checks if the given date is in the same month as the current date.
`Return` True if the date is in the current month, false otherwise.
```csharp
// -> Today , 2/1/2001
var result = new DateTime(2001, 2, 1, 11, 55, 0).IsThisMonth();
// -> true
```

## SetMonth
Set the month to the given date.
`Return` The new date with the month set.
```csharp
var result = new DateTime(2001, 2, 16, 11, 55, 0).SetMonth(7);
//-> 7/16/2001 11:55:00 AM
```

## SubMonths
Subtract the specified number of months from the given date.
`Return` The new date with the months subtracted.
```csharp
var result = new DateTime(2001, 7, 16, 11, 55, 0).SubMonths(1);
// -> 6/16/2001 11:55:00 AM
```

