using System.Linq;
using Popup.GameData;
using UniRx;

namespace Popup.UI.Character.Stats
{
    public sealed class CharacterStatsPresenterFactory
    {
        private readonly CharacterInfo _characterInfo;

        public CharacterStatsPresenterFactory(CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;
        }

        public CharacterStatPresenter[] CreateStatPresenters()
        {
            var presenters = _characterInfo.Stats.Select(stat => new CharacterStatPresenter(stat));
            return presenters.ToArray();
        }
    }
}