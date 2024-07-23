using Cysharp.Threading.Tasks;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class KillUnitPresenter : IInitializable// todoooo
    {
        private Button _killButton;
        private Camera _camera;
        private UnitManager _unitManager;

        public KillUnitPresenter(Button killButton, Camera camera, UnitManager unitManager)
        {
            _killButton = killButton;
            _camera = camera;
            _unitManager = unitManager;
        }

        void IInitializable.Initialize()
        {
            _killButton.onClick.AddListener(async () => await KillButtonPressed());
        }

        private async UniTask KillButtonPressed()
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            //var mouseWOrldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            //var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //go.transform.position = mouseWOrldPos;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue) && hitInfo.collider.TryGetComponent(out Unit unit))
            {
                _unitManager.DestroyUnit(unit);
            }
        }
    }
}
