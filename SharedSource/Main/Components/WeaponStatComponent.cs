using System;
using WaveEngine.Framework;

namespace ToBeDecided.Components
{
    public class WeaponStatComponent : Behavior
    {
        public float damage { get; private set; }

        public static WeaponStatComponent SWORD
        {
            get
            {
                return new WeaponStatComponent() { damage = 1f };
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
        }
    }
}
