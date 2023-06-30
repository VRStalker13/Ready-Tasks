using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Класс вызывающий события при добавлении и удалении объектов из коллекции.
/// </summary>
namespace Weather
{
    [Serializable]
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)_dictionary).Keys;

        public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)_dictionary).Values;

        public int Count => ((IDictionary<TKey, TValue>)_dictionary).Count;

        public bool IsReadOnly => ((IDictionary<TKey, TValue>)_dictionary).IsReadOnly;

        public TValue this[TKey key]
        {
            get => ((IDictionary<TKey, TValue>)_dictionary)[key];
            set => ((IDictionary<TKey, TValue>)_dictionary)[key] = value;
        }

        public event Action<TKey, TValue> ItemAdded;

        public event Action<TKey> ItemRemoved;

        public void Add(TKey key, TValue value)
        {
            _dictionary[key] = value;       
            ItemAdded?.Invoke(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
          
            var result = _dictionary.Remove(key);

            if (result)            
                ItemRemoved?.Invoke(key);            

            return result;     
        }

        public bool ContainsKey(TKey key)
        {
            return ((IDictionary<TKey, TValue>)_dictionary).ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)_dictionary).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((IDictionary<TKey, TValue>)_dictionary).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<TKey, TValue>)_dictionary).Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)_dictionary).Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)_dictionary).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)_dictionary).Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)_dictionary).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)_dictionary).GetEnumerator();
        }
    }
}
