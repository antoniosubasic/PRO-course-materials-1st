const string writtenExam = "Did you participate in the {0} exam [yes/no]: ";
const string howManyPoints = "How many points did you score (0-20): ";

int grade;
int gradeHomework;

int totalPoints = 0;
int totalPointsHomework = 20;

double possiblePoints = 20;

int scoredPoints;

Console.WriteLine(writtenExam, "first written");
if (Console.ReadLine()! == "yes")
{
    possiblePoints += 20;

    Console.WriteLine(howManyPoints);
    scoredPoints = int.Parse(Console.ReadLine()!);

    totalPoints += scoredPoints;
    totalPointsHomework += scoredPoints;
}

Console.WriteLine("\n" + writtenExam, "second written");
if (Console.ReadLine()! == "yes")
{
    possiblePoints += 20;

    Console.WriteLine(howManyPoints);
    scoredPoints = int.Parse(Console.ReadLine()!);

    totalPoints += scoredPoints;
    totalPointsHomework += scoredPoints;
}

Console.WriteLine("\nHow many points did you score through homework (0-20): ");
totalPoints += int.Parse(Console.ReadLine()!);

Console.WriteLine("\n" + writtenExam, "oral");
if (Console.ReadLine()! == "yes")
{
    possiblePoints += 20;

    Console.WriteLine(howManyPoints);
    scoredPoints = int.Parse(Console.ReadLine()!);

    totalPoints += scoredPoints;
    totalPointsHomework += scoredPoints;
}

double percentage = totalPoints / possiblePoints * 100;
double percentageHomework = totalPointsHomework / possiblePoints * 100;

if (percentage >= 89) { grade = 1; }
else if (percentage >= 76) { grade = 2; }
else if (percentage >= 63) { grade = 3; }
else if (percentage >= 50) { grade = 4; }
else { grade = 5; }

if (percentageHomework >= 89) { gradeHomework = 1; }
else if (percentageHomework >= 76) { gradeHomework = 2; }
else if (percentageHomework >= 63) { gradeHomework = 3; }
else if (percentageHomework >= 50) { gradeHomework = 4; }
else { gradeHomework = 5; }

Console.WriteLine("\n" + "Your grade is: " + grade);
if (grade != gradeHomework)
{
    Console.WriteLine("You could have gotten: " + gradeHomework);
}