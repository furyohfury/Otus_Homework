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
        public const int AbilityCard = 4;
        public const int Enemy = 5;
        public const int LevelEntity = 6;
        public const int WorldEntity = 7;
        public const int Weapon = 8;


        ///Extensions
        public static bool HasCharacterTag(this IEntity obj) => obj.HasTag(Character);
        public static bool NotCharacterTag(this IEntity obj) => !obj.HasTag(Character);
        public static bool AddCharacterTag(this IEntity obj) => obj.AddTag(Character);
        public static bool DelCharacterTag(this IEntity obj) => obj.DelTag(Character);

        public static bool HasBulletTag(this IEntity obj) => obj.HasTag(Bullet);
        public static bool NotBulletTag(this IEntity obj) => !obj.HasTag(Bullet);
        public static bool AddBulletTag(this IEntity obj) => obj.AddTag(Bullet);
        public static bool DelBulletTag(this IEntity obj) => obj.DelTag(Bullet);

        public static bool HasDestructibleWallTag(this IEntity obj) => obj.HasTag(DestructibleWall);
        public static bool NotDestructibleWallTag(this IEntity obj) => !obj.HasTag(DestructibleWall);
        public static bool AddDestructibleWallTag(this IEntity obj) => obj.AddTag(DestructibleWall);
        public static bool DelDestructibleWallTag(this IEntity obj) => obj.DelTag(DestructibleWall);
        
        public static bool HasAbilityCardTag(this IEntity obj) => obj.HasTag(AbilityCard);
        public static bool NotAbilityCardTag(this IEntity obj) => !obj.HasTag(AbilityCard);
        public static bool AddAbilityCardTag(this IEntity obj) => obj.AddTag(AbilityCard);
        public static bool DelAbilityCardTag(this IEntity obj) => obj.DelTag(AbilityCard);
        
        public static bool HasEnemyTag(this IEntity obj) => obj.HasTag(Enemy);
        public static bool NotEnemyTag(this IEntity obj) => !obj.HasTag(Enemy);
        public static bool AddEnemyTag(this IEntity obj) => obj.AddTag(Enemy);
        public static bool DelEnemyTag(this IEntity obj) => obj.DelTag(Enemy);
        
        public static bool HasLevelEntityTag(this IEntity obj) => obj.HasTag(LevelEntity);
        public static bool NotLevelEntityTag(this IEntity obj) => !obj.HasTag(LevelEntity);
        public static bool AddLevelEntityTag(this IEntity obj) => obj.AddTag(LevelEntity);
        public static bool DelLevelEntityTag(this IEntity obj) => obj.DelTag(LevelEntity);
        
        public static bool HasWeaponTag(this IEntity obj) => obj.HasTag(Weapon);
        public static bool NotWeaponTag(this IEntity obj) => !obj.HasTag(Weapon);
        public static bool AddWeaponTag(this IEntity obj) => obj.AddTag(Weapon);
        public static bool DelWeaponTag(this IEntity obj) => obj.DelTag(Weapon);
    }
}
