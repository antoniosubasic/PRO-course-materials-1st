// "Traditional" variable
int number = 42;
string text = "The quick brown fox jumps over the lazy dog";
float floatingPointNumber = 42.0f;

// Arrays
int[] numbers = new [] { 1, 2, 3, 4, 5 };
string[] texts = new [] { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };

// Problem: How to represent a person with a first name, last name and age?
Person p = new Person("John", "Doe", 42);
Person p2 = new Person("Jane", "Smith", 43);
Person c = new Person("Eve", "Doe-Smith", 15);

// Problem: How to represent a family consisting of three persons
Family f = new Family(p, p2, c, "Leonding");
Family f2 = new(
    new("x", "y", 1),
    new("x", "y", 1),
    new("x", "y", 1),
    "y"
);

// Records are immutable
record Person(string FirstName, string LastName, int Age);
record Family(Person Parent1, Person Parent2, Person Child, string Hometown);
