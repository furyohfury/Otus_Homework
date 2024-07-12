using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Lessons.Architecture.PM
{
    public interface ILevelUpButtonPresenter
    {
        public ReactiveCommand LevelUpCommand {get;}
        public ReactiveProperty<bool> CanLevelUp {get;}
    }
}