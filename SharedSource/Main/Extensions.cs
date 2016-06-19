using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Common.Input;

namespace ToBeDecided
{
    public static class Extensions
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

        public static bool nonePressed(this KeyboardState state, List<Keys> keys)
        {
            foreach (Keys key in keys)
            {
                if (state.IsKeyPressed(key))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
