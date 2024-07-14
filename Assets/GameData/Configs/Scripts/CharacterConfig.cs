using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Popup.GameData.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Create config/CharacterConfig")]
    public sealed class CharacterConfig : SerializedScriptableObject
    {
        [SerializeField] 
        private Dictionary<string, int> _stats;
        [SerializeField] 
        private int _currentLevel;
        [SerializeField] 
        private int _currentExperience;
        

        public Dictionary<string, int> Stats => _stats;
        public int CurrentLevel => _currentLevel;
        public int CurrentExperience => _currentExperience;

        internal HashSet<CharacterStat> Select()
        {
            throw new NotImplementedException();
        }
    }
}