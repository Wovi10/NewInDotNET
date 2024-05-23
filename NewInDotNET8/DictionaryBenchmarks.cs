using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace NewInDotNET8;

[MemoryDiagnoser]
public class DictionaryBenchmarks
{
    private Random _random = null!;
    private List<int> _list = null!;

    private ImmutableDictionary<int, string> _immutableDictionary = null!;
    private FrozenDictionary<int, string> _frozenDictionary = null!;

    private int _middle;

    [Params(1000)] 
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _random = new Random(420);
        _list = Enumerable.Range(0, Size).Select(_ => _random.Next()).ToList();

        _middle = _list[Size / 2];

        _immutableDictionary = _list.ToImmutableDictionary(i => i, i => i.ToString());
        _frozenDictionary = _list.ToFrozenDictionary(i => i, i => i.ToString());
    }

    [Benchmark]
    public ImmutableDictionary<int, string> ImmutableDictionary_Init()
        => _list.ToImmutableDictionary(i => i, i => i.ToString());

    [Benchmark]
    public FrozenDictionary<int, string> FrozenDictionary_Init()
        => _list.ToFrozenDictionary(i => i, i => i.ToString());

    [Benchmark]
    public bool ImmutableDictionary_Contains()
        => _immutableDictionary.ContainsKey(_middle);

    [Benchmark]
    public bool FrozenDictionary_Contains()
        => _frozenDictionary.ContainsKey(_middle);

    [Benchmark]
    public string ImmutableDictionary_Get()
        => _immutableDictionary[_middle];

    [Benchmark]
    public string FrozenDictionary_Get()
        => _frozenDictionary[_middle];
}