using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class BackgroundParams
    {

        [SerializeField]
        public float m_endPositionY;

        [SerializeField]
        public float m_movingSpeedY;
        [SerializeField]
        public float m_startPositionY;
    }
}