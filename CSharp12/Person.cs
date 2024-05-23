namespace CSharp12;

public class Person
{
    public Person(string surName, string firstName, DateTime birthDate)
    {
        _surName = surName;
        _firstName = firstName;
        _birthDate = birthDate;
    }

    private readonly string _surName;
    private readonly string _firstName;
    private readonly DateTime _birthDate;

    public string Name => $"{_firstName} {_surName}";
    public int Age => (int) ((DateTime.Today - _birthDate).TotalDays / 365.25);

    public override string ToString()
    {
        return $"{Name} is {Age} years old.";
    }
}