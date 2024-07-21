using GameEngine;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public class UnitData
    {
        public int ID;
        public int HitPoints;
        public Unit GO;
        public Vector3 Position;
        public Vector3 Rotation;

        public UnitData(int iD, int hitPoints, Vector3 position, Vector3 rotation, Unit gO)
        {
            ID = iD;
            HitPoints = hitPoints;
            Position = position;
            Rotation = rotation;
            GO = gO;
        }
    }
}