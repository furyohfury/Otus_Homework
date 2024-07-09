using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using Zenject;

namespace Lessons.Architecture.PM
{
    [System.Serializable]
    public sealed class UserInfo
    {
        [ShowInInspector, ReadOnly]
        public ReactiveProperty<string> Name { get; private set; } = new();

        [ShowInInspector, ReadOnly]
        public ReactiveProperty<string> Description { get; private set; } = new();

        [ShowInInspector, ReadOnly]
        public ReactiveProperty<Sprite> Icon { get; private set; } = new();

        [Inject]
        public UserInfo(UserConfig config)
        {
            Name.Value = config.Name;
            Description.Value = config.Description;
            Icon.Value = config.Icon;
        }

        [Button]
        public void ChangeName(string name)
        {
            this.Name.Value = name;
        }

        [Button]
        public void ChangeDescription(string description)
        {
            this.Description.Value = description;
        }

        [Button]
        public void ChangeIcon(Sprite icon)
        {
            this.Icon.Value = icon;
        }
    }
}