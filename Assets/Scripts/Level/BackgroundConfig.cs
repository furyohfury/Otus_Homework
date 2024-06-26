using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "Background_config", menuName = "Configs/Create background config")]
    public sealed class BackgroundConfig : ScriptableObject
    {
        public float m_startPositionY;

        public float m_endPositionY;

        public float m_movingSpeedY;
    }
}
