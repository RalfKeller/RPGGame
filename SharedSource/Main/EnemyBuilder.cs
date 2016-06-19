using Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
