// Find out which day it is.
// If it is a weekday (Saturday is a weekday, too), print "I have to work"
// else (= Sunday) print "Sunday, funday, better than a monday"

Console.WriteLine(IsSunday() ? "Sunday, funday, better than a monday" : "I have to work");

bool IsSunday() => DateTime.Today.DayOfWeek == DayOfWeek.Sunday;