using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PopupHelper : MonoBehaviour
    {
        [ShowInInspector] 
        private CharacterInfo _characterInfo;
        [ShowInInspector] 
        private PlayerLevel _playerLevel;
        [ShowInInspector] 
        private UserInfo _userInfo;

        [Inject]
        public void Construct(CharacterInfo characterInfo, PlayerLevel playerLevel, UserInfo userInfo)
        {
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;
            _userInfo = userInfo;
        }
    }
}