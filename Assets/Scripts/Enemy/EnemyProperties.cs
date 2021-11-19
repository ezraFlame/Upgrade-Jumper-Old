using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties
{
    public EnemyProperties()
    {
        values = new Dictionary<string, object>();
    }

    private Dictionary<string, object> values;

    public void Set(string valueName, object value)
    {
        values[valueName] = value;
    }

    public T Get<T>(string valueName)
    {
        T value;

        try
        {
            value = (T)values[valueName];
        }
        catch (System.IndexOutOfRangeException)
        {
            value = default(T);
        }
        return value;
    }
}
