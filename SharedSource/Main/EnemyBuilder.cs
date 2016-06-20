using System;
using ToBeDecided.Entitys;

namespace ToBeDecided
{
    class EnemyBuilder
    {
        public static Type getEnemyClassByName(string classname)
        {
            return typeof(Enemy);
        }
    }
}
