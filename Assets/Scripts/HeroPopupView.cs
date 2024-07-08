using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class HeroPopupView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _levelupButton;
        [SerializeField] private UserView _userView;
        [SerializeField] private PlayerLevelView _playerLevelView;
        [SerializeField] private AllCharacterStatsView _allCharacterStatsView;


    }
}