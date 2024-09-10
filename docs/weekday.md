# Weekday
>```csharp
> using Tiempo;
>```

## GetDayOfWeek
Get the day of the week of the given date. `Return` The day of week, 0 represents Sunday.
```csharp
//Which day of the week is 31 august 2024?
int day = new DateTime(2024,8,31).GetDayOfWeek();
// 6
```

## IsSunday
Is the given date Sunday? `Return` The date is Sunday.
```csharp
// Is today Sunday?
var result = new DateTime(9,9,2024).IsSunday();
// -> false
```

## IsMonday
Is the given date Monday? `Return` The date is Monday.
```csharp
// Is today Monday?
var result = new DateTime(9,9,2024).IsMonday();
// -> true
```

## IsTuesday
Is the given date Tuesday? `Return` The date is Tuesday.
```csharp
// Is today Tuesday?
var result = new DateTime(9,9,2024).IsTuesday();
// -> false
```

## IsWednesday
Is the given date Wednesday? `Return` The date is Wednesday.
```csharp
// Is today Wednesday?
var result = new DateTime(9,9,2024).IsWednesday();
// -> false
```

## IsThursday
Is the given date Thursday? `Return` The date is Thursday.
```csharp
// Is today Thursday?
var result = new DateTime(9,9,2024).IsThursday();
// -> false
```

## IsFriday
Is the given date Friday? `Return` The date is Friday.
```csharp
// Is today Friday?
var result = new DateTime(9,9,2024).IsFriday();
// -> false
```

## IsSaturday
Is the given date Saturday? `Return` The date is Saturday.
```csharp
// Is today Saturday?
var result = new DateTime(9,9,2024).IsSaturday();
// -> false
```

## IsWeekend
Does the given date fall on a weekend? A weekend is either Saturday(`6`) or Sunday (`0`). `Return` The date falls on a weekend.
```csharp
// Is today Weekend?
var result = new DateTime(9,9,2024).IsWeekend();
// -> false
```

## IsWeekdays
Does the date fall on a weekday? Weekdays are Monday (`1`) through Friday (`5`). `Return` The date falls on a weekday.
```csharp
// Is today Weekdays?
var result = new DateTime(9,9,2024).IsWeekdays();
// -> false
```

## NextDay (DayOfWeek)
When is the next day of the week? `DayOfWeek` the day of the week. `Return` The date is the next day of week.
```csharp
// When is the next Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Monday);
// 2 september 2024 -> 9/2/2024 12:00:00 AM

// When is the next Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Thursday);
// 5 september 2024 -> 9/5/2024 12:00:00 AM
```

## NextDay (int dayOfWeek)
When is the next day of the week? 0-6 the day o the week, 0 represents Sunday. `Return` The date is the next day of week. If `dayOfWeek` is less than `0` or greater than `6`, the original `date` is returned.
```csharp
// When is the next Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Monday);
// 2 september 2024 -> 9/2/2024 12:00:00 AM

// When is the next Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextDay(DayOfWeek.Thursday);
// 5 september 2024 -> 9/5/2024 12:00:00 AM
```

## NextSunday
When is the next Sunday? `Return` The next Sunday.
```csharp
// When is the next Sunday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextSunday();
// 1 september 2024 -> 9/1/2024 12:00:00 AM
```

## NextMonday
When is the next Monday? `Return` The next Monday.
```csharp
// When is the next Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextMonday();
// 2 september 2024 -> 9/2/2024 12:00:00 AM
```

## NextTuesday
When is the next Tuesday? `Return` The next Tuesday.
```csharp
// When is the next Tuesday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextTuesday();
// 3 september 2024 -> 9/3/2024 12:00:00 AM
```

## NextWednesday
When is the next Wednesday? `Return` The next Wednesday.
```csharp
// When is the next Wednesday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextWednesday();
// 4 september 2024 -> 9/4/2024 12:00:00 AM
```

## NextThursday
When is the next Thursday? `Return` The next Thursday.
```csharp
// When is the next Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextThursday();
// 5 september 2024 -> 9/5/2024 12:00:00 AM
```

## NextFriday
When is the next Friday? `Return` The next Friday.
```csharp
// When is the next Friday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextFriday();
// 6 september 2024 -> 9/6/2024 12:00:00 AM
```

## NextSaturday
When is the next Saturday? `Return` The next Saturday.
```csharp
// When is the next Saturday after 31 august 2024?
var result = new DateTime(2024, 8, 31).NextSaturday();
// 7 september 2024 -> 9/7/2024 12:00:00 AM
```

## PreviousDay (DayOfWeek)
When is the previous day of the week? `DayOfWeek` the day of the week. `Return` The date is the previous day of week.
```csharp
// When is the previous Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousDay(DayOfWeek.Monday);
// 26 august 2024 -> 8/26/2024 12:00:00 AM

// When is the previous Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousDay(DayOfWeek.Thursday);
// 29 august 2024 -> 8/29/2024 12:00:00 AM
```

## PreviousDay (int dayOfWeek)
When is the previous day of the week? `0-6` the day o the week, `0` represents `Sunday`. `Return` The date is the previous day of week. If `dayOfWeek` is less than `0` or greater than `6`, the original date is returned.
```csharp
// When is the previous Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousDay(1);
// 26 august 2024 -> 8/26/2024 12:00:00 AM

// When is the previous Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousDay(4);
// 29 august 2024 -> 8/29/2024 12:00:00 AM

// When is the previous Thursday after 31 august 2024? 
var result = new DateTime(2024, 8, 31).PreviousDay(-5); // Wrong day of the week
// 31 august 2024 -> 8/31/2024 12:00:00 AM
```

## PreviousSunday
When is the previous Sunday? `Return` The previous Friday.
```csharp
// When is the previous Sunday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousSunday();
// 25 august 2024 -> 8/25/2024 12:00:00 AM
```

## PreviousMonday
When is the previous Monday? `Return` The previous Monday
```csharp
// When is the previous Monday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousMonday();
// 26 august 2024 -> 8/26/2024 12:00:00 AM
```

## PreviousTuesday
When is the previous Tuesday? `Return` The previous Tuesday.
```csharp
// When is the previous Tuesday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousTuesday();
// 27 august 2024 -> 8/27/2024 12:00:00 AM
```

## PreviousWednesday
When is the previous Wednesday? `Return` The previous Wednesday.
```csharp
// When is the previous Wednesday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousWednesday();
// 28 august 2024 -> 8/28/2024 12:00:00 AM
```

## PreviousThursday
When is the previous Thursday? `Return` The previous Thursday.
```csharp
// When is the previous Thursday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousThursday();
// 29 august 2024 -> 8/29/2024 12:00:00 AM
```

## PreviousFriday
When is the previous Friday? `Return` The previous Friday.
```csharp
// When is the previous Friday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousFriday();
// 30 august 2024 -> 8/30/2024 12:00:00 AM
```

## PreviousSaturday
When is the previous Saturday? `Return` The previous Saturday.
```csharp
// When is the previous Saturday after 31 august 2024?
var result = new DateTime(2024, 8, 31).PreviousSaturday();
// 24 august 2024 -> 8/24/2024 12:00:00 AM
```

## SetDayOfWeek (`DayOfWeek`, `DayOfWeek weekStartsOn = DayOfWeek.Sunday`)
Set the day of the week to the given date. `Return` The new `DateTime` with the day of the week set.
```csharp
// Set week day to Sunday, with the default weekStartsOn of Sunday:
var result = new DateTime(2024, 8, 31).SetDayOfWeek(DayOfWeek.Sunday);
// 25 august 2024 -> 8/25/2024 12:00:00 AM

// Set week day to Sunday, with a weekStartsOn of Monday:
var result = new DateTime(2024, 8, 31).SetDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Monday);
// 1 september 2024 -> 9/1/2024 12:00:00 AM
```