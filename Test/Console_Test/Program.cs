using BenchmarkDotNet.Running;
using Console_Test.Week;
using Tiempo;

//var date = new DateTime(2024, 8, 31, 10, 0, 0, 0, 0);
//var nextWednesday = date.NextDay(DayOfWeek.Wednesday);
//var day = date.AddDays(2);
//var week = date.AddDays(2 * 7).AddDays(1);
//var dayOfWeek = date.DayOfWeek;
//var dayOfWeek2 = day.DayOfWeek;
//var dayOfWeek3 = week.DayOfWeek;
//Console.WriteLine(date);
//Console.WriteLine(dayOfWeek);
//Console.WriteLine(nextWednesday);
//Console.WriteLine(nextWednesday.DayOfWeek);
//Console.WriteLine(IsWeekdays(date));
//Console.WriteLine(dayOfWeek2);
//Console.WriteLine(IsWeekdays(day));
//Console.WriteLine(dayOfWeek3);
//Console.WriteLine(IsWeekdays(week));
//nextWednesday = date.NextDay(-5);
//var subDate = date.SetDayOfWeek(DayOfWeek.Sunday);
//var subDate = date.SetDayOfWeek(DayOfWeek.Sunday, DayOfWeek.Monday);
//nextWednesday = date.NextSaturday();
//Console.WriteLine(subDate);
//Console.WriteLine(subDate.DayOfWeek);
//Console.WriteLine(nextWednesday);
//Console.WriteLine(nextWednesday.DayOfWeek);

//date = new DateTime(2024, 8, 31, 6, 0, 0);
//var date2 = new DateTime(2024, 8, 29);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2024, 8, 31, 6, 0, 0);
//date2 = new DateTime(2023, 8, 31);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2014, 7, 20, 6, 0, 0);
//date2 = new DateTime(2014, 1, 10);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2021, 11, 30, 6, 0, 0);
//date2 = new DateTime(2021, 11, 1);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2021, 11, 1, 6, 0, 0);
//date2 = new DateTime(2021, 12, 1);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2021, 12, 1, 6, 0, 0);
//date2 = new DateTime(2021, 11, 1);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));

//date = new DateTime(2021, 11, 1, 6, 0, 0);
//date2 = new DateTime(2021, 11, 1);
//Console.WriteLine("DifferenceInBusinessDays");
//Console.WriteLine(date.DifferenceInBusinessDays(date2));


//Console.WriteLine(dayOfWeek);
//Console.WriteLine(date.StartOfDay());
//Console.WriteLine(date2.StartOfDay());

//date = new DateTime(2012, 7,2, 0, 0, 0);
//date2 = new DateTime(2011, 7, 2, 23, 0, 0);
//Console.WriteLine(date.DifferenceInDays(date2));

//date = new DateTime(2011, 7, 3, 0, 1, 0);
//date2 = new DateTime(2011, 7, 2, 23, 59, 0);
//Console.WriteLine(date.DifferenceInDays(date2));

//date = new DateTime(2020, 6, 1, 0, 0, 0);
//date2 = new DateTime(2020, 3, 1, 0, 0, 0);
//Console.WriteLine(date.DifferenceInDays(date2));

//date = new DateTime(2024, 9, 1, 11,55,0);
//Console.WriteLine(date);
//Console.WriteLine(date.EndOfDay());


//var date3 = DateTime.Today;
//Console.WriteLine(date3.EndOfToday());
//Console.WriteLine(date3.EndOfTomorrow());
//Console.WriteLine(date3.EndOfYesterday());

//date = new DateTime(2024, 8, 31, 6, 0, 0);
//Console.WriteLine(date.IsYesterday());
//Console.WriteLine(date.SetDay(10));
//Console.WriteLine(date.SetDayOfYear(2));

//var date3 = DateTime.Today;
//Console.WriteLine(date3.StartOfToday());
//Console.WriteLine(date3.StartOfTomorrow());
//Console.WriteLine(date3.StartOfYesterday());


//BenchmarkRunner.Run<BusinessDaysBenchmark>();

//var date = new DateTime(2024, 9, 1, 6, 0, 0);
//var date2 = DateTime.Today;

//Console.WriteLine(date.SubtractBusinessDays(10));
//Console.WriteLine(date2.SubtractBusinessDays(7));

//BenchmarkRunner.Run<StartOfWeek>();
//var date = new DateTime(2024, 10, 3,11, 55, 0);
//var date = new DateTime(2024, 8, 30,11, 55, 0);
//var date2 = DateTime.Today;

//Console.WriteLine(date.StartOfWeek());
//Console.WriteLine(date.StartOfWeek(DayOfWeek.Monday));
//Console.WriteLine(date.StartOfWeek(DayOfWeek.Monday));
//Console.WriteLine(date2.StartOfWeek());

//BenchmarkRunner.Run<IsSameWeek>();
//var date = new DateTime(2024, 9, 2, 11, 55, 0);
//var dateS = new DateTime(2024, 9, 2, 11, 50, 0);
//var date2 = new DateTime(2024, 10, 3, 11, 55, 0);

//Console.WriteLine(date.IsSameWeek_2(dateS, DayOfWeek.Monday));
//Console.WriteLine(date.IsSameWeek_2(date2, DayOfWeek.Monday));


//BenchmarkRunner.Run<DifferenceInCalendarWeeks>();
//var date = new DateTime(2024, 7, 20, 11, 55, 0);
//var dateS = new DateTime(2024, 7, 5, 11, 50, 0);

//Console.WriteLine(date.DifferenceInCalendarWeeks(dateS));
//Console.WriteLine(date.DifferenceInCalendarWeeks(dateS, DayOfWeek.Monday));

//var date = new DateTime(2024, 9, 1, 23, 59, 59);
//var dateS = new DateTime(2024, 9, 28, 0, 0, 0);

//Console.WriteLine(date.DifferenceInWeeks(dateS));

//var date = new DateTime(2024, 9, 2, 11, 55, 0);
//var date2 = DateTime.Today;

//Console.WriteLine(date.EndOfWeek());
//Console.WriteLine(date.EndOfWeek(DayOfWeek.Monday));
//Console.WriteLine(date2.EndOfWeek());

//var date = new DateTime(2005, 1, 2);
//Console.WriteLine(date.GetWeek());
//Console.WriteLine(date.GetWeek(new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 }));

//var date = new DateTime(2024, 9, 2, 23, 55, 0);
//Console.WriteLine(date.StartOfMonth());

//var date = new DateTime(2017, 11, 9, 23, 55, 0);
//Console.WriteLine(date.GetWeekOfMonth());

//var date = new DateTime(2024, 9, 2, 23, 55, 0);
//Console.WriteLine(date.WeekOfYear());

//var date = new DateTime(2015, 2, 8, 23, 55, 0);
//var date2 = new DateTime(2017, 7, 5, 23, 55, 0);
//Console.WriteLine(date.GetWeeksInMonth());
//Console.WriteLine(date2.GetWeeksInMonth(DayOfWeek.Monday));

//var date = new DateTime(2024, 9, 1, 23, 55, 0);
//Console.WriteLine(date.IsThisWeek());
//Console.WriteLine(date.IsThisWeek(DayOfWeek.Monday));

//var date = new DateTime(2024, 9, 1, 23, 55, 0);
//Console.WriteLine(date.LastDayOfWeek());
//Console.WriteLine(date.LastDayOfWeek(DayOfWeek.Monday));

var date = new DateTime(2005, 1, 2, 23, 55, 0);
var date2 = new DateTime(2009, 12, 2, 23, 55, 0);
var date3 = new DateTime(2014, 7, 2, 23, 55, 0);

Console.WriteLine(date.SetWeek(1));
Console.WriteLine(date.SetWeek(1, new WeekYearOptions() { WeekStartsOn = DayOfWeek.Monday, FirstWeekContainsDate = 4 }));
Console.WriteLine(date2.SetWeek(1));
Console.WriteLine(date3.SetWeek(52));