///////////////////////////////////////////////////////////
//  Gameobject.cs
//  Implementation of the Class Gameobject
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:49
//  Original author: Ralf Keller
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WaveEngine.Framework;
using Scenes;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Graphics;

namespace Entitys {
	public class GameObject : BaseDecorator {

		protected GameScene gameScene;
        protected Entity thisEntity;

        public Collider2D collider { get; protected set; }
        public Transform2D transform { get; protected set; }

        public bool isAlive
        {
            get; private set;
        }

        public delegate void OnDeathHandler();
		public event OnDeathHandler onDeathEvent;

		public GameObject(){
		}


		private void onDeath(){

		}
        
		public void recieveDamange(float damage){

		}
	}
}