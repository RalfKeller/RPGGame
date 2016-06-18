using System;
using System.Collections.Generic;
using System.Text;

namespace ToBeDecided
{
    static class Extensions
    {
        public static V forceGetValue<V, K>(this Dictionary<K, V> dict, K key)
        {
            V tempValue = default(V);
            dict.TryGetValue(key, out tempValue);

            if (tempValue.Equals(default(V)))
                throw new KeyNotFoundException();
            else
                return tempValue;
        }
    }
}
