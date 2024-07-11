using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenter : IPlayerLevelPresenter
    {
        public ReactiveProperty<string> Level { get; private set; } = new();
        public ReactiveProperty<string> Experience { get; private set; } = new();
        public ReactiveProperty<float> ProgressBarFillRate { get; private set;} = new();
        
        private PlayerLevel _playerLevel;
        private CompositeDisposable _disposable = new();

        public PlayerLevelPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            
            playerLevel.CurrentLevel
                .Subscribe(level => Level.Value = level.ToString())
                .AddTo(_disposable);

            playerLevel.CurrentExperience
                .Subscribe(exp => 
                {
                    int reqExp = playerLevel.RequiredExperience;
                    Experience.Value = $"XP : {exp/reqExp}";
                    ProgressBarFillRate.Value = exp/reqExp;
                })
                .AddTo(_disposable);
        }


        public void Dispose() //todo rename or add interface
        {
            _disposable.Clear();
        }
    }
}