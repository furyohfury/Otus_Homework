using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class HeroPopupView : MonoBehaviour
    {
        [SerializeField] 
        private Button _exitButton;
        [SerializeField] 
        private Button _levelupButton;
        [SerializeField] 
        private UserView _userView;
        [SerializeField] 
        private PlayerLevelView _playerLevelView;
        [SerializeField] 
        private CharacterAllStatsView _allCharacterStatsView;

        private IHeroPopupPresenter _heroPopupPresenter;

        public void Show(IPresenter presenter)
        {
            if (presenter is not IHeroPopupPresenter heroPopupPresenter)
            {
                throw new System.Exception("Needed IHeroPopupPresenter");
            }

        }

        public interface IHeroPopupPresenter: IPresenter
        {
            public UserPresenter
        }        
    }
}