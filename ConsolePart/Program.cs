using BenchmarkDotNet.Running;
using CSharp12;
using DotNET8;

await DotNet8();
// CSharp12();
return;


async Task DotNet8()
{
    BenchmarkRunner.Run<CollectionBenchmarks>();
    BenchmarkRunner.Run<DictionaryBenchmarks>();

    await Enumarables.ShowListAsync();
    Console.WriteLine();
    await Enumarables.ShowAsyncList();
}

void CSharp12()
{
    var person = new Person("Vinckevleugel", "Wout", new DateTime(2001, 11, 26));
    Console.WriteLine(person.Age);

    Span<string> weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

    var numbersOriginal = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    var secondNumberOriginal = numbersOriginal[1];
    var secondNumber = numbers[1];

    var IncrementBy = (int source, int increment = 1) => source + increment;
    var SumCollection = (params int[] values) => values.Sum();

    Console.WriteLine(IncrementBy(5));
    Console.WriteLine(SumCollection(1, 2, 3, 4, 5));
}