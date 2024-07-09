using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterConfig : ScriptableObject
    {
        [SerializeField] 
        private CharacterStat[] _stats;
        [SerializeField] 
        private int _currentLevel;
        [SerializeField] 
        private int _currentExperience;
        

        public CharacterStat[] Stats => _stats;
        public int CurrentLevel => _currentLevel;
        public int CurrentExperience => _currentExperience;
    }
}