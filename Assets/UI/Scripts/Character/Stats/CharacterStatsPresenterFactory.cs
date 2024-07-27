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

        public IStatPresenter[] CreateStatPresenters()
        {
            IStatPresenter[] presenters = new IStatPresenter[_characterInfo.Stats.Count];
            for (int i = 0; i < presenters.Length; i++)
            {
                presenters[i] = new CharacterStatPresenter(_characterInfo.Stats[i]);
            }
            return presenters;
        }
    }
}