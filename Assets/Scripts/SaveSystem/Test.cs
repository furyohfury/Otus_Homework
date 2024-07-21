using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public class Test : MonoBehaviour
    {
        private SceneContext _sceneContext;
        private void Start()
        {
            //var units = FindObjectsOfType<Unit>();
            //foreach (var unit in units)
            //{
            //    Debug.Log($"{unit.gameObject.name} hashcode is {unit.GetHashCode()}");
            //}

            Application.targetFrameRate = 60;

            _sceneContext = FindObjectOfType<SceneContext>();
        }

        [Button]
        public void KillUnit(Unit unit)
        {
            _sceneContext.Container.Resolve<UnitManager>().DestroyUnit(unit);
        }
    }
}