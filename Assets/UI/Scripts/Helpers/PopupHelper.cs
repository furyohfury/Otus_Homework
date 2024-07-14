using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PopupHelper : MonoBehaviour
    {
        [TitleGroup("References"), SerializeField]
        private HeroPopupView _heroPopupView;
        [TitleGroup("For editing"), ShowInInspector]
        private CharacterInfo _characterInfo;
        [TitleGroup("For editing"), ShowInInspector]
        private PlayerLevel _playerLevel;
        [TitleGroup("For editing"), ShowInInspector]
        private UserInfo _userInfo;
        private HeroPopupPresenterFactory _heroPopupPresenterFactory;

        [Inject]
        public void Construct(CharacterInfo characterInfo, PlayerLevel playerLevel, UserInfo userInfo, HeroPopupPresenterFactory heroPopupPresenterFactory)
        {
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _heroPopupPresenterFactory = heroPopupPresenterFactory;
        }

        [TitleGroup("Popup"), ButtonGroup("Popup/ShowHide")]
        public void ShowPopup()
        {
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