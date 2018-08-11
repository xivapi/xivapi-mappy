using Sharlayan.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mappy.Helpers;

namespace Mappy.Tracking
{
    public class Tracking
    {
        protected Saver Saver = new Saver();
        protected List<uint> list = new List<uint>();
        protected bool axisRestricted = false;
        protected ActorItem Player;

        /// <summary>
        /// Nicely log a new entity
        /// </summary>
        /// <param name="type"></param>
        /// <param name="entity"></param>
        public void LogEntity(string type, ActorItem entity)
        {
            var entityType = type.PadRight(15, ' ');
            var entityLevel = entity.Level.ToString().PadRight(4, ' ');
            var entityName = entity.Name.PadRight(30, ' ');
            var entityId = entity.NPCID2.ToString().PadRight(15, ' ');
            var entityString = $"{entityType} id: {entityId} (TypeID: {entity.TypeID})   lv.{entityLevel} {entityName}";

            if (Properties.Settings.Default.ExtendLogMessages) {
                entityString += $"ModelID: {entity.ModelID} - NPCID1:  {entity.NPCID1} - Distance: {entity.Distance} - Pos: {entity.Coordinate.X},{entity.Coordinate.Y}";
            }

            Logger.Add(entityString);
        }

        /// <summary>
        /// State if this entity should be ignored or not
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsIgnored(string type, ActorItem entity)
        {
            // skip if missing data or unknown
            if (entity.Type.ToString().ToLower() == "unknown"
                || entity.Type.ToString().ToLower() == "minion"
                || entity.NPCID2 == 0
                || entity.MapID == 0
                || entity.Name == String.Empty)
            {
                return true;
            }

            // if enabled, non English entities will be ignored.
            // off by default
            if (Properties.Settings.Default.IgnoreNoneEnglish) {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string name = rgx.Replace(entity.Name.ToString(), "");

                // name too short or too long
                if (entity.Name.ToString().Length < 2 || entity.Name.ToString().Length > 64) {
                    return true;
                }
            }

            // has a stupid big id (100 million)
            if (entity.NPCID2 > 100000000) {
                return true;
            }

            // egis and fairies
            uint[] egis = { 952, 1881, 1404, 1403, 1402, 1398, 1399 };
            if (type == "BNpcName" && egis.Contains(entity.ModelID)) {
                return true;
            }

            // we only care about entities on the same map as the player
            if (entity.MapID != Player.MapID) {
                return true;
            }

            // ignore out of range eobjs
            if (entity.Type.ToString().ToLower() == "eobj" && entity.NPCID2 > 50000000) {
                return true;
            }

            // ignore if it starts with an x
            if (entity.Name[0].ToString() == "×") {
                return true;
            }

            // has weird symbols
            if (entity.Name.ToString().Contains('�')) {
                return true;
            }

            // restrict axis
            if (axisRestricted) {
                double AxisLimit = 6;
                double AxisDiff = entity.Z - Player.Z;
                AxisDiff = Math.Abs(AxisDiff);

                // don't include stuff that is past the axis threshold
                if (AxisDiff > AxisLimit) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Define if trackign should be restricted via it's axis, it will be true
        /// when the layer count is above 1
        /// </summary>
        /// <param name="enabled"></param>
        public void SetAxisRestriction(bool enabled)
        {
            axisRestricted = enabled;
        }
    }
}
