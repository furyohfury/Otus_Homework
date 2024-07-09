using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenter : IPlayerPresenter
    {
        public ReactiveProperty<string> Level { get; private set; } = new();
        public ReactiveProperty<string> Experience { get; private set; } = new();
        public ReactiveProperty<float> ProgressBarFillRate { get; private set;} = new();
        
        private PlayerLevel _playerLevel;
        private CompositeDisposable _disposable = new();

        public void PlayerLevelPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            
            playerLevel.Level
                .Subscribe(level => Level = level.ToString())
                .Addto(_disposable);

            playerLevel.CurrentExperience
                .Subscribe(exp => 
                {
                    int reqExp = playerLevel.RequiredExperience;
                    Experience = $"XP : {exp/reqExp}";
                    ProgressBarFillRate = exp/reqExp;
                })
                .Addto(_disposable);
        }


        public void Dispose() //todo rename or add interface
        {
            _disposable.Clear();
        }
    }
}