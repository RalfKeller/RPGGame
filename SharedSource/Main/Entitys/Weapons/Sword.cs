using Components;
using ToBeDecided.Components;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;

namespace ToBeDecided.Entitys.Weapons
{
    class Sword : Weapon
    {
        public Sword()
        {
            this.collider = new RectangleCollider2D();
            this.transform = new Transform2D();
            this.stats = WeaponStatComponent.SWORD;

            Entity
                .AddComponent(transform)
                .AddComponent(collider)
                .AddComponent(stats);
        }
    }
}
