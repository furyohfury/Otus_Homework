using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Lessons.Architecture.PM
{
    public sealed class LevelUpButtonPresenter : ILevelUpButtonPresenter
    {
        public ReactiveCommand LevelUpCommand {get; private set;}
        public ReactiveProperty<bool> CanLevelUp {get; private set;} = new(false);
        private PlayerLevel _playerLevel;
        private CompositeDisposable _disposable = new();

        public LevelUpButtonPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            playerLevel.CurrentExperience
                .Subscribe(_ => CanLevelUp.Value = playerLevel.CanLevelUp())
                .AddTo(_disposable);

            LevelUpCommand = new(CanLevelUp);
            LevelUpCommand
                .Subscribe(OnLevelUpCommand)
                .AddTo(_disposable);
        }

        private void OnLevelUpCommand(Unit unit)
        {
            _playerLevel.LevelUp();
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}
