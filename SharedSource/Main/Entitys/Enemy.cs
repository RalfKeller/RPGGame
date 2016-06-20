///////////////////////////////////////////////////////////
//  Enemy.cs
//  Implementation of the Class Enemy
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:48
//  Original author: Ralf
///////////////////////////////////////////////////////////


using ToBeDecided.Components;
using WaveEngine.Framework;

namespace ToBeDecided.Entitys
{
    public abstract class Enemy : GameObject {

        private StatComponent statComponent;

		public Enemy(){
            Entity = new Entity();
            Entity.AddComponent(statComponent);
		}

		public Enemy(StatComponent statComponent){

		}

		public void finalize(){

		}

	}//end Enemy

}//end namespace Entitys