using GameEngine;
using UnityEngine;

namespace Assets.GameEngine
{
    public sealed class Test : MonoBehaviour
    {
        public Camera _camera;
        private void Update()
        {
            var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
        }
    }
}
