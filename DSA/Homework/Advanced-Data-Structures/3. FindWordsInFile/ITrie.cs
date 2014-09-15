namespace FindWordsInFile
{
    using System.Collections.Generic;

    public interface ITrie<TKey, TValue> : IDictionary<IEnumerable<TKey>, TValue>
    {
        ICollection<KeyValuePair<IEnumerable<TKey>, TValue>> Suffixes(IEnumerable<TKey> keys);
    }
}
