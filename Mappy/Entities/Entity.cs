using Sharlayan.Core;
using Mappy.Helpers;
using System;

namespace Mappy.Entities
{
    public class Entity
    {
        public string Index;
        public uint ID1;
        public uint ID2;
        public uint ModelID; // ModelID
        public string Name;
        public string Type;
        public byte TypeID;
        public byte Race;
        public uint MapID;
        public uint MapIndex;
        public uint MapTerritoryId;
        public uint PlaceNameId;
        public double CoordinateX;
        public double CoordinateY;
        public double CoordinateZ;
        public double PosX;
        public double PosY;
        public int PixelX;
        public int PixelY;
        public int HPMax;
        public int MPMax;
        public byte JobID;
        public byte Level;
        public byte AggroFlags;
        public byte CombatFlags;
        public uint FateID;
        public bool FateSpawned;
        public string EventObjectType;
        public uint EventObjectTypeID;
        public byte GatheringInvisible;
        public byte GatheringStatus;
        public float HitBoxRadius;
        public bool IsGM;

        public Entity(string index, ActorItem entity)
        {
            dynamic map = App.Instance.MapViewer.Map;

            Index = index;
            ID1 = entity.NPCID1;
            ID2 = entity.NPCID2;
            ModelID = entity.ModelID;
            Name = entity.Name.ToString().Trim();
            Type = entity.Type.ToString();
            TypeID = entity.TypeID;
            Race = entity.Race;
            MapID = entity.MapID;
            MapIndex = entity.MapIndex;
            MapTerritoryId = entity.MapTerritory;
            PlaceNameId = map.PlaceName.ID;
            CoordinateX = Math.Round(entity.Coordinate.X, 3);
            CoordinateY = Math.Round(entity.Coordinate.Y, 3);
            CoordinateZ = Math.Round(entity.Coordinate.Z, 3);
            PosX = Math.Round(MapHelper.ConvertCoordinatesIntoMapPosition((double)map.SizeFactor, (double)map.OffsetX, entity.Coordinate.X), 1);
            PosY = Math.Round(MapHelper.ConvertCoordinatesIntoMapPosition((double)map.SizeFactor, (double)map.OffsetY, entity.Coordinate.Y), 1);
            PixelX = MapHelper.ConvertMapPositionToPixels(PosX, (double)map.SizeFactor);
            PixelY = MapHelper.ConvertMapPositionToPixels(PosY, (double)map.SizeFactor);
            HPMax = entity.HPMax;
            MPMax = entity.MPMax;
            Level = entity.Level;
            FateID = entity.Fate;
            FateSpawned = entity.IsFate;
            AggroFlags = entity.AgroFlags;
            CombatFlags = entity.CombatFlags;
            EventObjectType = entity.EventObjectType.ToString();
            EventObjectTypeID = entity.EventObjectTypeID;
            GatheringInvisible = entity.GatheringInvisible;
            GatheringStatus = entity.GatheringStatus;
            HitBoxRadius = entity.HitBoxRadius;
            IsGM = entity.IsGM;
            JobID = entity.JobID;
        }
    }
}
