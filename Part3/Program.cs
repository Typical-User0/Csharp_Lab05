
class MyDictionary<TKey, TValue>
{
    private TKey[] keys = new TKey[0];
    private TValue[] values = new TValue[0];
    private int count = 0;

    public void Add(TKey key, TValue value)
    {
        if (Array.IndexOf(keys, key) != -1)
        {
            throw new ArgumentException("Duplicate element");
        }

        if (count == keys.Length)
        {
            Array.Resize(ref keys, (keys.Length == 0) ? 4 : keys.Length * 2);
            Array.Resize(ref values, (values.Length == 0) ? 4 : values.Length * 2);
        }

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public TValue this[TKey key]
    {
        get
        {
            int index = Array.IndexOf(keys, key);
            if (index == -1)
            {
                throw new KeyNotFoundException("Key was not found.");
            }
            return values[index];
        }
    }

    public int Count
    {
        get { return count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyDictionary<string, int> dictionary = new MyDictionary<string, int>();
        dictionary.Add("one", 1);
        dictionary.Add("two", 2);
        dictionary.Add("three", 3);

        Console.WriteLine("Count: " + dictionary.Count);
        Console.WriteLine("Value for key 'two': " + dictionary["two"]);
    }
}