///////////////////////////////////////////////////////////
//  WeaponBehaviour.cs
//  Implementation of the Interface WeaponBehaviour
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:52
//  Original author: Ralf
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WaveEngine.Framework;
using ToBeDecided.Components;
using WaveEngine.Framework.Graphics;

namespace Components {
	public abstract class WeaponBehaviour : Behavior {

        [RequiredComponent]
        WeaponStatComponent stats;

        [RequiredComponent]
        Transform2D transform;

    }//end WeaponBehaviour

}//end namespace Components