using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _experience;
        [SerializeField] private RectTransform _uncompletedBar;
        [SerializeField] private RectTransform _completedBar;

        private float _barsWidth;
        private readonly float _duration = 1; // todo put somewhere

        private void Awake()
        {
            if (_uncompletedBar.rect.width - _completedBar.rect.width > 1)
            {
                throw new System.Exception("Progress bars must have same width");
            }
            _barsWidth = _completedBar.sizeDelta.x;
        }

        public void SetLevel(int level) => _level.text = level.ToString();

        [Button]
        public void SetProgressBar(int currentValue, int maxValue)
        {
            _experience.text = $"XP : {currentValue}/{maxValue}";
            
            DOTween.To(() => _completedBar.sizeDelta.x,
             x => _completedBar.sizeDelta = new Vector2(x, _completedBar.sizeDelta.y),
             (float) currentValue / (float) maxValue * _barsWidth,
             _duration);
        }
    }
}