using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [System.Serializable]
    public sealed class CharacterStat
    {
        [ShowInInspector, ReadOnly]
        public ReactiveProperty<string> Name { get; private set; } = new();

        [ShowInInspector, ReadOnly]
        public ReactiveProperty<int> Value { get; private set; } = new();

        public CharacterStat(string name, int value)
        {
            Name.Value = name;
            Value.Value = value;
        }
        
        [Button]
        public void ChangeName(string name)
        {
            this.Name.Value = name;
        }

        [Button]
        public void ChangeValue(int value)
        {
            this.Value.Value = value;
        }
    }
}