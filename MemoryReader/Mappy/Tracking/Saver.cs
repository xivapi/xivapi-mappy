using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sharlayan.Core;
using Mappy.Entities;
using Mappy.Helpers;

namespace Mappy.Tracking
{
    public class Saver
    {
        public List<Entity> savedEnemies = new List<Entity>();
        public List<Entity> savedNpcs = new List<Entity>();

        /// <summary>
        /// Add an enemy to save list
        /// </summary>
        /// <param name="entity"></param>
        public void SaveEnemy(ActorItem entity)
        {
            try
            {
                // create new monster
                Entity monster = new Entity("BNPC", entity);
                savedEnemies.Add(monster);

                // Have we hit out minimum?
                if (savedEnemies.Count == Properties.Settings.Default.MinimumSubmitQuantity)
                {
                    SubmitEnemyData();
                    Logger.Add("> SAVE: Enemies");
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Saver -> SaveEnemy");
            }
            
        }

        /// <summary>
        /// Submit Enemy data to the API
        /// </summary>
        public void SubmitEnemyData()
        {
            // submit the tracked data
            List<Entity> savedEnemiesList = new List<Entity>(savedEnemies);
            savedEnemies.Clear();

            API.SubmitData("BNPC", savedEnemiesList);
            File.AppendAllText(AppHelper.getApplicationPath() + "/logs/enemies.json", JsonConvert.SerializeObject(savedEnemiesList) + Environment.NewLine);
        }

        /// <summary>
        /// Add an npc to save list
        /// </summary>
        /// <param name="entity"></param>
        public void SaveNpc(ActorItem entity)
        {
            try
            {
                // create new npc
                Entity npc = new Entity("ENPC", entity);
                savedNpcs.Add(npc);

                // Have we hit out minimum?
                if (savedNpcs.Count == Properties.Settings.Default.MinimumSubmitQuantity)
                {
                    SubmitNpcData();
                    Logger.Add("> Save: NPCs");
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Saver -> SaveEnemy");
            }
        }

        /// <summary>
        /// Submit NPC data to the API
        /// </summary>
        public void SubmitNpcData()
        {
            // submit the tracked data
            List<Entity> savedNpcsList = new List<Entity>(savedNpcs);
            savedNpcs.Clear();

            API.SubmitData("ENPC", savedNpcsList);
            File.AppendAllText(AppHelper.getApplicationPath() + "/logs/npcs.json", JsonConvert.SerializeObject(savedNpcsList) + Environment.NewLine);
        }
    }
}
