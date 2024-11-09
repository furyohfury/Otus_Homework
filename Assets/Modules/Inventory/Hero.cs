using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Meta.Lesson_Inventory
{
    public class Hero : MonoBehaviour, ICharacter
    {
        public static Hero Instance;

        [field: SerializeField]
        public int HitPoints { get; set; }
        [field: SerializeField]
        public float ManaPoints { get; set; }
        
        public void Awake()
        {
            Instance = this;
        }
        
    }
}