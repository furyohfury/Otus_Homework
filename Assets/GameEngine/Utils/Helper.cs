using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class Helper : MonoBehaviour
    {
        private SpawnerOnCD _spawner;

        [Inject]
        public void Construct(SpawnerOnCD spawner)
        {
            _spawner = spawner;
        }

        [Button]
        public void EnableSpawning()
        {
            if (_spawner == null)
            {
                Debug.Log("Spawner havent been injected");
            }
            _spawner.Enable();
        }

        [Button]
        public void DisableSpawning()
        {
            _spawner.Disable();
        }
    }
}