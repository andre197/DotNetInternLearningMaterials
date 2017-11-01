namespace TeststingInfoFromDotNetLearningMaterials.HashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomHashTable<TKey, TValue>
    {
        private const string KeyNotContainedExceptionMessage = "The key {0} is not contained in the current collection";
        private const int InitialLenght = 16;
        private const int Multiplier = 2;

        private LinkedList<KeyValuePair<TKey, TValue>>[] data;
        private int currentSize;

        public CustomHashTable()
        {
            this.data = new LinkedList<KeyValuePair<TKey, TValue>>[InitialLenght];
        }

        public int Size => this.data.Length;

        public void Add(TKey key, TValue value)
        {
            int position = GetPosition(key, this.Size);

            if (this.data[position] == null)
            {
                this.data[position] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            else if (this.data[position].Any(x => x.Key.Equals(key)))
            {
                throw new ArgumentException("KeyNotContainedExceptionMessage", key.ToString());
            }

            if (this.currentSize >= this.Size)
            {
                ResizeIfTooBig();
            }

            position = GetPosition(key, this.Size);

            if (this.data[position] == null)
            {
                this.data[position] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            this.data[position].AddLast(new KeyValuePair<TKey, TValue>(key, value));

            this.currentSize++;
        }

        public void Remove(KeyValuePair<TKey, TValue> itemToBeRmoved)
        {
            int position = GetPosition(itemToBeRmoved.Key, this.Size);

            if (this.data[position] == null)
            {
                throw new ArgumentException(KeyNotContainedExceptionMessage, itemToBeRmoved.Key.ToString());
            }

            this.data[position].Remove(itemToBeRmoved);

            this.currentSize--;

            if (this.currentSize <= this.Size / 2 && this.currentSize >= 16)
            {
                ResizeIfTooSmall();
            }
        }

        public KeyValuePair<TKey, TValue> Search(TKey key)
        {
            int position = GetPosition(key, this.Size);

            if (this.data[position] == null || !this.data[position].Any(x => x.Key.Equals(key)))
            {
                throw new ArgumentException(KeyNotContainedExceptionMessage, key.ToString());
            }

            return this.data[position].FirstOrDefault(x => x.Key.Equals(key));
        }

        private void ResizeIfTooSmall()
        {
            int newSize = this.Size / 2;

            Resize(newSize);
        }

        private void ResizeIfTooBig()
        {
            int newSize = this.Size * Multiplier;

            Resize(newSize);
        }

        private void Resize(int newSize)
        {
            var resizedHashTable = new LinkedList<KeyValuePair<TKey, TValue>>[newSize];

            foreach (var item in data.Where(x => x != null))
            {
                foreach (var kvp in item)
                {
                    int position = GetPosition(kvp.Key, newSize);

                    if (resizedHashTable[position] == null)
                    {
                        resizedHashTable[position] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    }

                    resizedHashTable[position].AddLast(kvp);
                }
            }

            this.data = resizedHashTable;
        }

        private int GetPosition(TKey key, int size)
        {
            var hash = Math.Abs(key.GetHashCode());
            var position = hash % size;

            return position;
        }
    }
}
