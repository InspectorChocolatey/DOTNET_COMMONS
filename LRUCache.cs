using System.Collections.Generic;

public class LRUCache {

    private int _capacity { get; set; }
    private Dictionary<int, int> _dictionary { get; set; }
    
    public LRUCache(int capacity)
    {
        _dictionary = new Dictionary<int, int>();
        _capacity = capacity;
    }
    
    public int Get(int key)
    {
        foreach (KeyValuePair<int,int> kvp in _dictionary)
        {
            if (kvp.Key == key)
            {
                return kvp.Value;
            }
        }
        throw new ArgumentOutOfRangeException("Key not found : " + key);
    }

    public bool HasKey(int key)
    {
        foreach (KeyValuePair<int, int> kvp in _dictionary)
        {
            if (kvp.Key == key)
            {
                return true;
            }
        }
        return false;
    }

    public void Put(int key, int value)
    {
        if (HasKey(key))
        {
            throw new Exception("Cannot add a duplicate Key : " + key.ToString());
        }
        else if (_dictionary.Keys.Count >= _capacity)
        {
            throw new Exception("Dictionary already at capacity : cannot add new key");
        }
        else
        {
            _dictionary.Add(key, value);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
