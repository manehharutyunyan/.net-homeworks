using System;
using System.Collections;
using System.Collections.Generic;

namespace Multimap
{
    class Multimap<TKey, TValue> : IDictionary
    {
        private Dictionary<TKey, List<TValue>> dictionary = new Dictionary<TKey, List<TValue>>();

        /// <summary>
        /// Gets the number of key/value pairs
        /// </summary>
        public int Count { get; private set; } = 0;

        public Multimap()
        {
            dictionary = new Dictionary<TKey, List<TValue>>();
            Count = 0;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[object key]
        {
            get
            {
                return dictionary[(TKey)key];
            }
            set
            {
                dictionary[(TKey)key] = (List<TValue>)value;
            }
        }

        /// <summary>
        /// Gets a collection containing the keys.
        /// </summary>
        public ICollection Keys
        {
            get
            {
                return (ICollection)dictionary.Keys;
            }
        }

        /// <summary>
        /// Gets a collection containing the values.
        /// </summary>
        public ICollection Values
        {
            get
            {
                return (ICollection)dictionary.Values;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public bool IsFixedSize { get { return false; } }

        //?
        public object SyncRoot { get { return false; } }

        //?
        public bool IsSynchronized { get { return false; } }

        public object CmdItem { get; private set; }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(object key, object value)
        {
                ++Count;
                foreach (var item in dictionary)
                {
                    if (item.Key.Equals(key))
                    {
                        item.Value.Add((TValue)value);
                        return;
                    }
                }

                List<TValue> newList = new List<TValue> { (TValue)value };
                dictionary.Add((TKey)key, newList);
        }

        /// <summary>
        /// Removes the value with the specified key.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (Contains((TKey)key))
            {
                Count -= dictionary[(TKey)key].Count;
                dictionary.Remove((TKey)key);
            }
        }

        /// <summary>
        ///  Removes all keys and values.
        /// </summary>
        public void Clear()
        {
            foreach (var item in dictionary)
            {
                Remove(item.Key);
                if (Count == 0)
                    return;
            }
        }

        /// <summary>
        /// Determines whether the multimap contains the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(object key)
        {
            return dictionary.ContainsKey((TKey)key);
        }

        /// <summary>
        /// Copies the multimap elements to an existing one-dimensional
        /// System.Array, starting at the specified array index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            array = new TValue[dictionary.Count - index];
            array = (TValue[])array;
            for (int i = index; i < array.Length; ++i)
            {
                foreach (var item in dictionary)
                {
                    for (int j = 0; j < item.Value.Count; ++j)
                    {
                        //why we cannot apply indexing with[] to an expression of type array?
                        //array[i] = item.Value[j];
                        ++i;
                    } 
                }
            }
        }

        /// <summary>
        /// Prints the multimap elements.
        /// </summary>
        public void Print()
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"\nkey: {item.Key} ");
                Console.Write("values: ");
                foreach (var listItem in item.Value)
                {
                    Console.Write( listItem + " ");
                }
            }
        }

        //?
        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //?
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
