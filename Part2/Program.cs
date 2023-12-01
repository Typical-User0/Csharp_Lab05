
using System.Collections;

class MyList<T> : IEnumerable<T>
{
    T[] items;
    private int count;

    public MyList()
    {
        count = 0;
        items = Array.Empty<T>();
    }

    public MyList(T[] list)
    {
        count = list.Length;
        items = list;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)items.GetEnumerator();
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, (items.Length == 0) ? 4 : items.Length * 2);
        }

        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    public int Count
    {
        get { return count; }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyList<int> myList = new() {1, 2, 3, 4, 5, 6};
        
        Console.WriteLine("Count: " + myList.Count);
        Console.WriteLine("index 0: " + myList[0]);
    }
}