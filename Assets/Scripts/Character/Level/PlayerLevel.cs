using System;
using Sirenix.OdinInspector;
using UniRx;
using Zenject;

namespace Lessons.Architecture.PM
{
    [System.Serializable]
    public sealed class PlayerLevel
    {
        [ShowInInspector, ReadOnly]
        public ReactiveProperty<int> CurrentLevel { get; private set; } = new(1);

        [ShowInInspector, ReadOnly]
        public ReactiveProperty<int> CurrentExperience { get; private set; } = new();

        [ShowInInspector, ReadOnly]
        public int RequiredExperience
        {
            get { return 100 * (this.CurrentLevel.Value + 1); }
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
            var xp = Math.Min(this.CurrentExperience.Value + range, this.RequiredExperience);
            this.CurrentExperience.Value = xp;
        }

        [Button]
        public void LevelUp()
        {
            if (this.CanLevelUp())
            {
                this.CurrentExperience.Value = 0;
                this.CurrentLevel.Value++;
            }
        }

        public bool CanLevelUp()
        {
            return this.CurrentExperience.Value == this.RequiredExperience;
        }
    }
}