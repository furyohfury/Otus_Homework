using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBackground : IInitializable, IOnFixedUpdateListener
    {
        private float startPositionY;

        private float endPositionY;

        private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private readonly Transform _myTransform;

        private readonly BackgroundConfig _backgroundConfig;

        public LevelBackground(Transform myTransform, BackgroundConfig backgroundConfig)
        {
            _myTransform = myTransform;
            _backgroundConfig = backgroundConfig;
        }

        void IInitializable.Initialize()
        {
            ConfigurePositions();
            IGameStateListener.Register(this);
        }

        public void OnFixedUpdate(float delta)
        {
            if (_myTransform.position.y <= endPositionY)
            {
                _myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            _myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }

        private void ConfigurePositions()
        {
            startPositionY = _backgroundConfig.m_startPositionY;
            endPositionY = _backgroundConfig.m_endPositionY;
            movingSpeedY = _backgroundConfig.m_movingSpeedY;
            var position = _myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }        
    }
}