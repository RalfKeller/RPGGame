///////////////////////////////////////////////////////////
//  Map.cs
//  Implementation of the Class Map
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:49
//  Original author: Ralf Keller
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Scenes;
using SpawnerClasses;
using WaveEngine.Common.Math;
using TiledSharp;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using ToBeDecided;
using Entitys;
using ToBeDecided.MapClasses;

namespace MapClasses
{
    public class Map : BaseDecorator
    {

        public enum Difficulty
        {
            Jede = 0,
            Leicht = 1,
            Mittel = 2,
            Schwer = 3,

        }

        public GameScene gameScene;
        private TmxMap tmxMap;

        private Dictionary<int, List<Spawner>> difficultyToSpawnerList;

        private Map()
        {

        }

        public Map(TmxMap tmxMap)
        {
            this.tmxMap = tmxMap;

            this.Entity = new Entity().AddComponent(new MapDrawer(tmxMap));

            #region Spawner laden

            difficultyToSpawnerList = new Dictionary<int, List<Spawner>>();

            difficultyToSpawnerList.Add(0, new List<Spawner>());
            difficultyToSpawnerList.Add(1, new List<Spawner>());
            difficultyToSpawnerList.Add(2, new List<Spawner>());

            foreach (TmxObjectGroup objectGroup in tmxMap.ObjectGroups)
            {
                if (objectGroup.Name == "Spawner")
                {
                    List<Spawner> easySpawners      = difficultyToSpawnerList.forceGetValue((int)Difficulty.Leicht);
                    List<Spawner> mediumSpawners    = difficultyToSpawnerList.forceGetValue((int)Difficulty.Mittel);
                    List<Spawner> hardSpawners      = difficultyToSpawnerList.forceGetValue((int)Difficulty.Schwer);

                    foreach (TmxObject tmxObject in objectGroup.Objects)
                    {
                        Spawner spawner = new Spawner();


                        bool inEasy;
                        bool inMedium;
                        bool inHard;

                        string inEasyString     = "false";
                        string inMediumString   = "false";
                        string inHardString     = "false";
                        string enemyType        = "";
                        string enemyCount       = "";
                        string enemyLevel       = "";

                        tmxObject.Properties.TryGetValue("inEasy", out inEasyString);
                        tmxObject.Properties.TryGetValue("inMedium", out inMediumString);
                        tmxObject.Properties.TryGetValue("inHard", out inHardString);
                        tmxObject.Properties.TryGetValue("enemyType", out enemyType);
                        tmxObject.Properties.TryGetValue("enemyCount", out enemyCount);
                        tmxObject.Properties.TryGetValue("enemyLevel", out enemyLevel);

                        inEasy      = Convert.ToBoolean(inEasyString);
                        inMedium    = Convert.ToBoolean(inMediumString);
                        inHard      = Convert.ToBoolean(inHardString);

                        spawner.setType(EnemyBuilder.getEnemyClassByName(enemyType));
                        spawner.setLevel(Convert.ToInt32(enemyLevel));
                        spawner.setCount(Convert.ToInt32(enemyCount));

                        if (inEasy)
                            easySpawners.Add(spawner);
                        if (inMedium)
                            mediumSpawners.Add(spawner);
                        if (inHard)
                            hardSpawners.Add(spawner);
                    }
                }
            }

            #endregion

        }

        /// <summary>Gibt eine Liste mit Spawner zur�ckt, die f�r die angegebene Schwierigkeit erstellt wurden</summary>
        /// <param name="schwierigkeit">Die Schwierigkeit, f�r die die Spawner gebraucht werden</param>
        public List<Spawner> getSpawner(Difficulty difficulty)
        {
            return difficultyToSpawnerList.forceGetValue((int)difficulty);
        }

        /// <summary>Checkt, ob die angegebene Position frei ist</summary>
        /// <param name="transform">Die Position, die �berpr�ft werden soll</param>
        /// <returns>True wenn keine blockierenden Objekte an der Position sind, sonst false</returns>
        public bool requestMovement(Transform2D transform)
        {

            return true;

            int row = (int)(transform.Y / tmxMap.TileHeight);
            int column = (int)(transform.X / tmxMap.TileWidth);

            foreach (TmxLayerTile tile in tmxMap.Layers["Obstacles"].Tiles)
            {
                if (tile.Y == row && tile.X == column)
                    return false;
            }

            return true;
        }

    }//end Map

}//end namespace Map