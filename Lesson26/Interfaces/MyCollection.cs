using System.Collections;

namespace Interfaces;

internal class MyCollection : IEnumerable<int>
{
    private int[] _items = {1,2,3};

    public int GetFirstElement() => _items[0];

    public IEnumerator<int> GetEnumerator()
    {
        yield return _items[0];
        yield return _items[1];
        yield return _items[2];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}