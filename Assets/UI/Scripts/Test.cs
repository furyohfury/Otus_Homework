using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class Test : MonoBehaviour
    {
        [ShowInInspector]
        private UserInfo _userInfo;
        private PlayerLevel _level;
        private CharacterInfo _characterInfo;

        [SerializeField]
        private UserView _userView;
        [SerializeField]
        private CharacterAllStatsView _characterAllStatsView;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        [Inject]
        public void Construct(UserInfo userInfo, PlayerLevel level, CharacterInfo characterInfo)
        {
            _userInfo = userInfo;
            _level = level;
            _characterInfo = characterInfo;
        }

        [Button]
        public void ChangeUserInfo(UserConfig config)
        {
            _userInfo.ChangeName(config.Name);
            _userInfo.ChangeDescription(config.Description);
            _userInfo.ChangeIcon(config.Icon);
        }

        [Button, ButtonGroup("UserView")]
        public void ShowUserView()
        {
            _userView.Show(new UserPresenter(_userInfo));
        }

        [Button, ButtonGroup("UserView")]
        public void HideUserView()
        {
            _userView.Hide();
        }

        [Button, ButtonGroup("Stats")]
        public void ShowCharacterStats()
        {
            _characterAllStatsView.Show(new CharacterAllStatsPresenter(_characterInfo));
        }

        [Button, ButtonGroup("Stats")]
        public void HideCharacterStats()
        {
            _characterAllStatsView.Hide();
        }

    }
}