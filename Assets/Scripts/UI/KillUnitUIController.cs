using Cysharp.Threading.Tasks;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class KillUnitUIController : IInitializable// todo rename to controller?
    {
        private readonly Button _killButton;
        private readonly Camera _camera;
        private readonly UnitManager _unitManager;

        public KillUnitUIController(Button killButton, Camera camera, UnitManager unitManager)
        {
            _killButton = killButton;
            _camera = camera;
            _unitManager = unitManager;
        }

        void IInitializable.Initialize()
        {
            _killButton.onClick.AddListener(async () => 
            {
                Debug.Log("Choose unit to destroy");
                await KillButtonPressed();
            });
        }

        private async UniTask KillButtonPressed()
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue) && hitInfo.collider.TryGetComponent(out Unit unit))
            {
                _unitManager.DestroyUnit(unit);
                Debug.Log($"Destroyed unit of type: {unit.Type}");
            }
        }
    }
}
