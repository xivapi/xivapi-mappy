using System;

using Mappy.Helpers;
using Sharlayan.Core;

namespace Mappy.Tracking
{
    public class TrackingPlayer
    {
        public uint MapId = 0;
        
        //
        // Checks if the player has changed map,
        // if it returns true, it means the player has moved
        // maps, otherwise false the map has not changed
        //
        public bool HasMovedMap() 
        {
            ActorItem Player = GameMemory.GetPlayer();

            // Check for map id
            if (Player.MapID > 0 && Player.MapID != MapId) 
            {
                // set map
                MapId = Player.MapID;
                Logger.Add($"> MAP ID: {Player.MapID}");

                // Tell app to change map
                return true;
            }

            return false;
        }

        public uint GetMapId()
        {
            return MapId;
        }
    }
}
