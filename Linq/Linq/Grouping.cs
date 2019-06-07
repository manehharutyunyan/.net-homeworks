using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a collection of objects that have a common key.
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TSource"></typeparam>
class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
{
    private TKey key;
    private IEnumerable<TSource> elements;

    public Grouping(TKey key, IEnumerable<TSource> elements)
    {
        this.key = key;
        this.elements = elements;
    }

    public IEnumerator<TSource> GetEnumerator()
    {
        return elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public TKey Key
    {
        get { return key; }
    }
}
