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

        //
        // Add an enemy to save list
        //
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
                    // submit the tracked data
                    List<Entity> savedEnemiesList = new List<Entity>(savedEnemies);
                    savedEnemies.Clear();
                    API.SubmitData("BNPC", savedEnemiesList);

                    // write to log
                    Logger.Add("> SAVE: Enemies");
                    File.AppendAllText(AppHelper.getApplicationPath() + "/logs/enemies.json", JsonConvert.SerializeObject(savedEnemiesList) + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Saver -> SaveEnemy");
            }
            
        }

        //
        // Add an npc to save list
        //
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
                    // submit the tracked data
                    List<Entity> savedNpcsList = new List<Entity>(savedNpcs);
                    savedNpcs.Clear();
                    API.SubmitData("ENPC", savedNpcsList);

                    // write to log
                    Logger.Add("> Save: NPCs");
                    File.AppendAllText(AppHelper.getApplicationPath() + "/logs/npcs.json", JsonConvert.SerializeObject(savedNpcsList) + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Saver -> SaveEnemy");
            }
        }
    }
}
