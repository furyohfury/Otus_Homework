using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class Test : MonoBehaviour
    {
        [SerializeField, TitleGroup("References")]
        private UserView _userView;
        [SerializeField, TitleGroup("References")]
        private CharacterAllStatsView _characterAllStatsView;
        [SerializeField, TitleGroup("References")]
        private PlayerLevelView _levelView;
        [SerializeField, TitleGroup("References")]
        private HeroPopupView _heroPopupView;

        [ShowInInspector, TitleGroup("User")]
        private UserInfo _userInfo;
        private PlayerLevel _level;
        [ShowInInspector, TitleGroup("Stats")]
        private CharacterInfo _characterInfo;       

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

        [TitleGroup("User"), Button]
        public void ChangeUserInfo(UserConfig config)
        {
            _userInfo.ChangeName(config.Name);
            _userInfo.ChangeDescription(config.Description);
            _userInfo.ChangeIcon(config.Icon);
        }

        [ButtonGroup("User/ShowHide")]
        public void ShowUserView()
        {
            _userView.Show(new UserPresenter(_userInfo));
        }

        [ButtonGroup("User/ShowHide")]
        public void HideUserView()
        {
            _userView.Hide();
        }

        [TitleGroup("Stats"), ButtonGroup("Stats/ShowHide")]
        public void ShowCharacterStats()
        {
            _characterAllStatsView.Show(new CharacterAllStatsPresenter(_characterInfo));
        }

        [ButtonGroup("Stats/ShowHide")]
        public void HideCharacterStats()
        {
            _characterAllStatsView.Hide();
        }

        [TitleGroup("Stats"), Button]
        public void AddStat(string name, int value) => _characterInfo.AddStat(new CharacterStat(name, value));

        [TitleGroup("Level"), ButtonGroup("Level/ShowHide")]
        public void ShowLevelView()
        {
            _levelView.Show(new PlayerLevelPresenter(_level));
        }

        [ButtonGroup("Level/ShowHide")]
        public void HideLevelView()
        {
            _levelView.Hide();
        }

        [TitleGroup("Level"), Button]
        public void ChangeLevel(int level)
        {
            _level.CurrentLevel.Value = level;
        }
        [TitleGroup("Level"), Button]
        public void AddExp(int exp)
        {
            _level.AddExperience(exp);
        }

        [TitleGroup("Popup"), ButtonGroup("Popup/ShowHide")]
        public void ShowPopup()
        {
            _heroPopupView.Show(new HeroPopupPresenter(_userInfo, _characterInfo, _level));
        }

        [ButtonGroup("Popup/ShowHide")]
        public void HidePopup()
        {
            _heroPopupView.Hide();
        }
    }
}