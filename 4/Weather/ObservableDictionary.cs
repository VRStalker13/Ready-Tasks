using System;
using System.Collections;
using System.Collections.Generic;

namespace Weather
{    
    /// <summary>
    /// Класс вызывающий события при добавлении и удалении объектов из коллекции.
    /// </summary>    
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDisposable
    {
        /// <summary>
        /// Словарь ключ - значеие
        /// </summary>
        private readonly IDictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();        
        /// <summary>
        /// Ключи
        /// </summary>
        public ICollection<TKey> Keys => _dictionary.Keys;

        /// <summary>
        /// Значения
        /// </summary>
        public ICollection<TValue> Values => _dictionary.Values;

        /// <summary>
        /// Получает колличство элементов содержащихся в словаре 
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Получает значение указывающее является ли объект коллекции доступным только для чтения
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Свойство для получения значения из словаря
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Значение</returns>
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
        /// Метод удаления элементов из словаря
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Ложь\Истина</returns>
        public bool Remove(TKey key)
        {          
            var result = _dictionary.Remove(key);

            if (result)            
                ItemRemoved?.Invoke(key);            

            return result;     
        }

        /// <summary>
        /// Определяет кодержится ли элемент с заданным ключом
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Ложь\Истина</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Возвращает значение с заданным ключом
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        /// <returns>Ложь\Истина</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Удаляет все элементы из коллекции
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Определяет содержит ли коллекция заданное значение
        /// </summary>
        /// <param name="item"> Значение </param>
        /// <returns>Ложь\Истина</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// Копирует элементы коллекции начиная с заданного значения
        /// </summary>
        /// <param name="array">Массив в который происходит копирование</param>
        /// <param name="arrayIndex">Индекс с которого начинается копирование </param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Удаляет первое вхождение заданного элемента
        /// </summary>
        /// <param name="item">Значение удаляемое</param>
        /// <returns>Истина\Ложь</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Remove(item);
        }

        /// <summary>
        /// Перебор элементов коллекции
        /// </summary>
        /// <returns>Перечислитель выполняющий пперебор</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// Перебор элементов в коллекции
        /// </summary>
        /// <returns>Возвращает перечислитель, выполняющий перебор элементов в коллекции</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// Добавляет элемент в коллекцию
        /// </summary>
        /// <param name="item">Пара ключ - значение</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dictionary.Add(item);
        }

        /// <summary>
        /// Очищает события
        /// </summary>
        public void Dispose()
        {
            ItemAdded = null;
            ItemRemoved = null;
        }
    }
}
