namespace DotNET8;

public static class Enumarables
{
    private const int DelayMs = 500;
    private const int ListSize = 10;

    public static async Task ShowListAsync()
    {
        foreach (var item in await GetListAsync()) 
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
    }

    private static async Task<IEnumerable<int>> GetListAsync()
    {
        var list = new List<int>();
        for (var i = 0; i < ListSize; i++)
        {
            await Task.Delay(DelayMs);
            list.Add(i);
        }

        return list;
    }

    public static async Task ShowAsyncList()
    {
        await foreach (var item in GetAsyncList())
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
    }

    private static async IAsyncEnumerable<int> GetAsyncList()
    {
        for (var i = 0; i < ListSize; i++)
        {
            await Task.Delay(DelayMs);
            yield return i;
        }
    }
}