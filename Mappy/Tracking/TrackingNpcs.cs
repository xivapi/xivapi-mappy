using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mappy.Helpers;
using Sharlayan.Core;

namespace Mappy.Tracking
{
    public class TrackingNpcs : Tracking
    {
        private static int total = 0;

        /// <summary>
        /// Submit NPC Data
        /// </summary>
        public void SubmitData()
        {
            Saver.SubmitNpcData();
        }

        /// <summary>
        /// Scan for entities
        /// </summary>
        public void Scan()
        {
            Player = GameMemory.GetPlayer();

            // get npcs
            List<ActorItem> entities = GameMemory.GetNpcsAroundPlayer();
            if (entities.Count == 0)
            {
                return;
            }

            // loop through npcs
            foreach (var entity in entities)
            {
                // check if we're ignoring this entity
                if (IsIgnored("ENPC", entity))
                {
                    continue;
                }

                // check we havent already tracked it
                if (list.IndexOf(entity.NPCID2) == -1)
                {
                    total++;

                    // add to existing list
                    list.Add(entity.NPCID2);
                    LogEntity("ENPC", entity);

                    // add to map
                    App.Instance.Invoke((MethodInvoker)delegate
                    {
                        App.Instance.MapViewer.AddNpcIcon(entity);
                        App.Instance.labelTotalNpcs.Text = total.ToString();
                    });

                    // save npc to file
                    Saver.SaveNpc(entity);
                }
            }
        }

        /// <summary>
        /// Get a list of entities
        /// </summary>
        /// <returns></returns>
        public List<ActorItem> GetEntities()
        {
            Player = GameMemory.GetPlayer();

            List<ActorItem> entities = GameMemory.GetNpcsAroundPlayer();

            // remove junk
            for (var i = 0; i < entities.Count; i++)
            {
                ActorItem entity = entities[i];

                // check if we're ignoring this entity
                if (IsIgnored("ENPC", entity))
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
