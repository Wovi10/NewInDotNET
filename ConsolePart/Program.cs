using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Running;
using CSharp12;
using DotNET8;

// await DotNet8();
CSharp12();
return;

async Task DotNet8()
{
    var inputList = new List<int> {1, 2, 3, 4, 5};
    var hashSet = inputList.ToHashSet();
    hashSet.Add(5);
    hashSet.Remove(8);
    
    var immutableList = inputList.ToImmutableHashSet();
    immutableList = immutableList.Add(5);

    var frozenList = inputList.ToFrozenSet();
    

    // BenchmarkRunner.Run<DictionaryBenchmarks>();
    // BenchmarkRunner.Run<CollectionBenchmarks>();

    // await Enumarables.ShowListAsync();
    // await Enumarables.ShowAsyncList();
}

void CSharp12()
{
    var person = new Person("Vinckevleugel", "Wout", new DateTime(2001, 11, 26));

    
    List<string> weekDaysOriginal = new()
        {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
    
    List<string> weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

    var numbersOriginal = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    var range = weekDays[5..6];
    var range1 = weekDaysOriginal[5..6];
    var secondNumberOriginal = numbersOriginal[1];
    var secondNumber = numbers[1];


    var OldIncrementBy = new Func<int, int, int>((source, increment) => source + increment);
    Console.WriteLine(OldIncrementBy(5, 2));

    var IncrementBy = (int source, int increment = 1) => source + increment;
    var SumCollection = (params int[] values) => values.Sum();

    Console.WriteLine(IncrementBy(5));
    Console.WriteLine(SumCollection(1, 2, 3, 4, 5));
}