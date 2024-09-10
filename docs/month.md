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
