using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatPresenterFactory
    {
        private CharacterStat _characterStat ;

        public CharacterStatPresenterFactory(CharacterStat characterStat)
        {
            _characterStat =characterStat;
        }

        public CharacterStatPresenter Create() => new CharacterStatPresenter(_characterStat );
    }
}