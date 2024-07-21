using GameEngine;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public class UnitData
    {
        public int ID;
        public string Type;
        public int HitPoints;
        public Vector3 Position;
        public Vector3 Rotation;

        public UnitData(int iD, int hitPoints, Vector3 position, Vector3 rotation, string type)
        {
            ID = iD;
            HitPoints = hitPoints;
            Position = position;
            Rotation = rotation;
            Type = type;
        }
    }
}