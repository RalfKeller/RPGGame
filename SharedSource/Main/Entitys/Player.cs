///////////////////////////////////////////////////////////
//  Player.cs
//  Implementation of the Class Player
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:51
//  Original author: Ralf Keller
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WaveEngine.Framework;

using Components;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using ToBeDecided;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Animation;
using Scenes;

namespace Entitys {
	public class Player : GameObject {

		public PlayerBehaviourComponent playerBehaviourComponent { get; private set; }
        public StatComponent statComponent { get; private set; }

        public Player(GameScene scene) {
            playerBehaviourComponent = new PlayerBehaviourComponent(scene);
            collider = new RectangleCollider2D();
            statComponent = StatComponent.PlayerLevel1;
            transform = new Transform2D() { X = 50, Y = 50, DrawOrder = 0 };

            Entity = new Entity("Player")
                .AddComponent(transform)
                .AddComponent(new SpriteAtlas(WaveContent.Assets.SpriteSheet_spritesheet))
                .AddComponent(new SpriteAtlasRenderer())
                .AddComponent(new Animation2D())
                .AddComponent(collider)
                .AddComponent(playerBehaviourComponent)
                .AddComponent(statComponent);
		}

	}//end Player

}//end namespace Entitys