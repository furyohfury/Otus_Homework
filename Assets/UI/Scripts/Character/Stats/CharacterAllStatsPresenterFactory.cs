using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsPresenterFactory
    {
        private CharacterInfo _charInfo;

        public CharacterAllStatsPresenterFactory(CharacterInfo charInfo)
        {
            _charInfo=charInfo;
        }

        public CharacterAllStatsPresenter Create() => new CharacterAllStatsPresenter(_charInfo);
    }
}