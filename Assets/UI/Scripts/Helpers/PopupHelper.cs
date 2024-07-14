using System.Linq;
using Popup.GameData;
using Popup.UI.Popup;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Popup.UI
{
    public class PopupHelper : MonoBehaviour
    {
        [TitleGroup("References"), SerializeField]
        private HeroPopupView _heroPopupView;
        [TitleGroup("Models readonly"), ShowInInspector]
        private GameData.CharacterInfo _characterInfo;
        [TitleGroup("Models readonly"), ShowInInspector]
        private PlayerLevel _playerLevel;
        [TitleGroup("Models readonly"), ShowInInspector]
        private UserInfo _userInfo;
        private HeroPopupPresenterFactory _heroPopupPresenterFactory;

        [Inject]
        public void Construct(GameData.CharacterInfo characterInfo, PlayerLevel playerLevel, UserInfo userInfo, HeroPopupPresenterFactory heroPopupPresenterFactory)
        {
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _heroPopupPresenterFactory = heroPopupPresenterFactory;
        }

        [TitleGroup("Editing"), Button]
        public void AddStat(string name, int value) => _characterInfo.AddStat(new CharacterStat(name, value));

        [TitleGroup("Editing"), Button]
        public void RemoveStat(string name)
        {
            var stat = _characterInfo.Stats
                .SingleOrDefault(s => s.Name.Value.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (stat != default)
            {
                _characterInfo.RemoveStat(stat);
            }
        }

        [TitleGroup("Editing"), Button]
        public void AddExperience(int value) => _playerLevel.AddExperience(value);

        [TitleGroup("Editing"), Button]
        public void ChangeUsername(string name) => _userInfo.ChangeName(name);

        [TitleGroup("Editing"), Button]
        public void ChangeDescription(string desc) => _userInfo.ChangeDescription(desc);

        [TitleGroup("Editing"), Button]
        public void ChangeIcon(Sprite icon) => _userInfo.ChangeIcon(icon);

        [TitleGroup("Popup"), ButtonGroup("Popup/ShowHide")]
        public void ShowPopup()
        {
            if (_heroPopupView.gameObject.activeSelf)
            {
                return;
            }
            var presenter = _heroPopupPresenterFactory.Create();
            _heroPopupView.Show(presenter);
        }

        [ButtonGroup("Popup/ShowHide")]
        public void HidePopup()
        {
            _heroPopupView.Hide();
        }
    }
}