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



using Components;
using Entitys;
namespace Entitys {
	public class Player : Gameobject, Gameobject {

		public Components.GameComponent m_GameComponent;
		public Components.PlayerBehaviourComponent m_PlayerBehaviourComponent;
		public Components.StatComponent m_StatComponent;



		~Player(){

		}

		public Player(){

		}

		public void finalize(){

		}

	}//end Player

}//end namespace Entitys