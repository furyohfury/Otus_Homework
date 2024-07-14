using Sirenix.OdinInspector;
using UniRx;

namespace Popup.GameData
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
        public void ChangeName(string name) => Name.Value = name;

        [Button]
        public void ChangeValue(int value) => Value.Value = value;
    }
}