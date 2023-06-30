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

        public int Count => _dictionary.Count;

        public bool IsReadOnly => ((IDictionary<TKey, TValue>)_dictionary).IsReadOnly;

        public TValue this[TKey key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        /// <summary>
        /// Событие при добавлении элементов в словарь
        /// </summary>
        public event Action<TKey, TValue> ItemAdded;

        /// <summary>
        /// Событие при удалении элементов из словаря
        /// </summary>
        public event Action<TKey> ItemRemoved;

        /// <summary>
        /// Метод добавления элементов в словарь
        /// </summary>
        /// <param name="key"> Ключ </param>
        /// <param name="value"> Значение </param>
        public void Add(TKey key, TValue value)
        {
            _dictionary[key] = value;       
            ItemAdded?.Invoke(key, value);
        }

        /// <summary>
        /// метод удаления элементов из словаря
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
            return _dictionary.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((IDictionary<TKey, TValue>)_dictionary).Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
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

        public void Dispose()
        {
            ItemAdded = null;
            ItemRemoved = null;
        }
    }
}
