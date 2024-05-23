using BenchmarkDotNet.Running;
using NewInDotNET8;

#region .NET 8

// BenchmarkRunner.Run<CollectionBenchmarks>();
// BenchmarkRunner.Run<DictionaryBenchmarks>();

await Enumarables.ShowListAsync();
Console.WriteLine();
await Enumarables.ShowAsyncList();

#endregion


