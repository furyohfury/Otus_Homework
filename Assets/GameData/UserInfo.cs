using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

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

        public UserInfo(UserConfig config)
        {
            Name.Value = config.Name;
            Description.Value = config.Description;
            Icon.Value = config.Icon;
        }

        [Button]
        public void ChangeName(string name) => Name.Value = name;

        [Button]
        public void ChangeDescription(string description) => Description.Value = description;

        [Button]
        public void ChangeIcon(Sprite icon) => Icon.Value = icon;
    }
}