/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;

namespace Atomic.Entities
{
    public static class TagAPI
    {
        ///Keys
        public const int Character = 1;
        public const int Bullet = 2;
        public const int DestructibleWall = 3;


        ///Extensions
        public static bool HasCharacterTag(this IEntity obj) => obj.HasTag(Character);
        public static bool NotCharacterTag(this IEntity obj) => !obj.HasTag(Character);
        public static bool AddCharacterTag(this IEntity obj) => obj.AddTag(Character);
        public static bool DelCharacterTag(this IEntity obj) => obj.DelTag(Character);
        public static bool HasBulletTag(this IEntity obj) => obj.HasTag(Bullet);
        public static bool NotBulletTag(this IEntity obj) => !obj.HasTag(Bullet);
        public static bool AddBulletTag(this IEntity obj) => obj.AddTag(Bullet);
        public static bool DelBulletTag(this IEntity obj) => obj.DelTag(Bullet);
        public static bool HasDestructibleWallTag(this IEntity obj) => obj.HasTag(Bullet);
        public static bool NotDestructibleWallTag(this IEntity obj) => !obj.HasTag(Bullet);
        public static bool AddDestructibleWallTag(this IEntity obj) => obj.AddTag(Bullet);
        public static bool DelDestructibleWallTag(this IEntity obj) => obj.DelTag(Bullet);
    }
}
