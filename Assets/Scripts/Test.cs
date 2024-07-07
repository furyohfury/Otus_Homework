using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class Test : MonoBehaviour
    {
        public RectTransform RectTransform;
        [ShowInInspector]
        public Vector2 SizeDelta => RectTransform.sizeDelta;


        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        private void Update()
        {
            // SizeDelta = RectTransform.sizeDelta;
        }

    }
}