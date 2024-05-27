namespace CSharp12;

public class Person
{
    public Person(string surname, string firstname, DateTime birthDate)
    {
        _surname = surname;
        _firstname = firstname;
        _birthDate = birthDate;
    }
    
    private readonly string _firstname;
    private readonly string _surname;
    private readonly DateTime _birthDate;
    
    public string Name => $"{_firstname} {_surname}";
    public int Age => (int) ((DateTime.Today - _birthDate).TotalDays / 365.25);

    public override string ToString()
    {
        return $"{Name} is {Age} years old.";
    }
}