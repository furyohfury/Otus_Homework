using System;
using Popup.GameData.Configs;
using Sirenix.OdinInspector;
using UniRx;
using Zenject;

namespace Popup.GameData
{
    [Serializable]
    public sealed class PlayerLevel
    {
        [ShowInInspector, ReadOnly]
        public ReactiveProperty<int> CurrentLevel { get; private set; } = new(1);

        [ShowInInspector, ReadOnly]
        public ReactiveProperty<int> CurrentExperience { get; private set; } = new();

        [ShowInInspector, ReadOnly]
        public int RequiredExperience
        {
            get { return 100 * (CurrentLevel.Value + 1); }
        }

        [Inject]
        public PlayerLevel(CharacterConfig config)
        {
            CurrentLevel.Value = config.CurrentLevel;
            CurrentExperience.Value = config.CurrentExperience;
        }

        [Button]
        public void AddExperience(int range)
        {
            var xp = Math.Min(CurrentExperience.Value + range, RequiredExperience);
            CurrentExperience.Value = xp;
        }

        [Button]
        public void LevelUp()
        {
            if (CanLevelUp())
            {
                CurrentLevel.Value++;
                CurrentExperience.Value = 0;
            }
        }

        public bool CanLevelUp()
        {
            return CurrentExperience.Value == RequiredExperience;
        }
    }
}