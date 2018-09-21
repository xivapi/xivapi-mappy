using System.Collections.Generic;
using Mappy.Helpers;
using Sharlayan.Core;

namespace Mappy.Tracking
{
    public class TrackingEnemies : Tracking
    {
        private static int total = 0;

        /// <summary>
        /// Submit Enemy Data
        /// </summary>
        public void SubmitData()
        {
            Saver.SubmitEnemyData();
        }

        /// <summary>
        /// Scan for enemies
        /// </summary>
        public void Scan()
        {
            Player = GameMemory.getPlayer();

            List<ActorItem> entities = GameMemory.getMonstersAroundPlayer();

            if (entities.Count == 0)
            {
                return;
            }

            // loop through monsters
            foreach (var entity in entities)
            {
                // check if we're ignoring this entity
                if (IsIgnored("BNPC", entity))
                {
                    continue;
                }

                // check we havent already tracked it
                if (list.IndexOf(entity.ID) == -1)
                {
                    total++;

                    // add to list
                    list.Add(entity.ID);
                    LogEntity("BNPC", entity);

                    // add to map
                    App.Instance.MapViewer.AddEnemyIcon(entity);
                    App.Instance.labelTotalEnemies.Text = total.ToString();

                    // save enemy
                    Saver.SaveEnemy(entity);
                }
            }
        }

        /// <summary>
        /// Get a list of entities
        /// </summary>
        /// <returns></returns>
        public List<ActorItem> GetEntities()
        {
            Player = GameMemory.getPlayer();

            List<ActorItem> entities = GameMemory.getMonstersAroundPlayer();

            // remove junk
            for (var i = 0; i < entities.Count; i++)
            {
                ActorItem entity = entities[i];

                // check if we're ignoring this entity
                if (IsIgnored("BNPC", entity))
                {
                    entities.RemoveAt(i);
                    continue;
                }
            }

            return entities;
        }       

        /// <summary>
        /// Clear all recorded map markers
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }   
    }
}
