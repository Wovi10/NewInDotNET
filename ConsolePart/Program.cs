using System.Collections.Frozen;
using System.Collections.Immutable;

var list = new List<int> {1, 2, 2, 3};


#region HashSet

var hashSet = list.ToHashSet();

#endregion


#region ImmutableHashSet

var immutableHashSet = list.ToImmutableHashSet();

#endregion

#region FrozenSet

var frozenSet = list.ToFrozenSet();

#endregion



Console.WriteLine();