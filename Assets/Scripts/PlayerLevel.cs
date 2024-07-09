using System;
using Sirenix.OdinInspector;
using UniRx;

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
        public ReactiveProperty<int> RequiredExperience
        {
            get { return 100 * (this.CurrentLevel + 1); }
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
            var xp = Math.Min(this.CurrentExperience + range, this.RequiredExperience);
            this.CurrentExperience = xp;
        }

        [Button]
        public void LevelUp()
        {
            if (this.CanLevelUp())
            {
                this.CurrentExperience = 0;
                this.CurrentLevel++;
            }
        }

        public bool CanLevelUp()
        {
            return this.CurrentExperience == this.RequiredExperience;
        }
    }
}