using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Lab03
{
    public sealed class IntHashTable<TValue>
    {
        private readonly List<Entry<TValue>>[] _buckets;
        private int _count;

        public IntHashTable(int bucketCount)
        {
            if (bucketCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bucketCount));
            }

            _buckets = new List<Entry<TValue>>[bucketCount];
            for (int i = 0; i < _buckets.Length; ++i)
            {
                _buckets[i] = new List<Entry<TValue>>();
            }
        }

        public int Count => _count;
        public int BucketCount => _buckets.Length;

        public void Set(int key, TValue value)
        {
            //sets index & bucket based on index then iterates through the buckets indexes if the index.key == key value
            //set the bucket index to a new Entry with the correct Key,Value pair then returns
            //if no key was found then add a new entry and increase the count
            
            int bucketindex = GetBucketIndex(key);
            List<Entry<TValue>> bucket = _buckets[bucketindex];
            for (int i = 0; i < bucket.Count; ++i)
            {
                if (bucket[i].Key == key)
                {
                    bucket[i] = new Entry<TValue>(key,value);
                    return;
                }
            }
            
            bucket.Add(new Entry<TValue>(key, value));
            _count++;
            
        }

        public bool TryGetValue(int key, out TValue value)
        {
            //if the key does not exist in the current buckets then return early
            //if it does exist then set the index & bucket based on the index then iterate through each entry of every bucket
            //if the entry key == the key then set value to the right entry value & return true if it does not exist then
            //set the value to default & return false
            if (!ContainsKey(key))
            {
                value = default;
                return false;
            }
            
            int bucketIndex = GetBucketIndex(key);
            List<Entry<TValue>> bucket = _buckets[bucketIndex];
            foreach (Entry<TValue> entry in bucket)
            {
                if (entry.Key == key)
                {
                    value = entry.Value;
                    return true;
                }
            }

            value = default;
            return false;
        
        }

        public bool ContainsKey(int key)
        {
            //set the index of the bucket based on key & and the bucket based on the index
            //iterate through each entry in the bucket and if the entry key is == key then return true if no key was equal
            //then return false
            int bucketIndex = GetBucketIndex(key);
            List<Entry<TValue>> bucket = _buckets[bucketIndex];
            foreach (Entry<TValue> entry in bucket)
            {
                if (entry.Key == key)
                {
                    return true;
                }
            }
            return false;
        }

        private int GetBucketIndex(int key)
        {
            if (key < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "This learning implementation uses non-negative integer keys.");
            }

            return key % _buckets.Length;
        }
    }
}
