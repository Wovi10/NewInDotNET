namespace CSharp12;

public class Person(string surname, string firstname, DateTime birthDate)
{
    public string Surname { get; set; } = surname;
    public string Name => $"{firstname} {surname}";
    public int Age => (int) ((DateTime.Today - birthDate).TotalDays / 365.25);

    public override string ToString()
    {
        return $"{Name} is {Age} years old.";
    }
}