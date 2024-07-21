using GameEngine;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            //var units = FindObjectsOfType<Unit>();
            //foreach (var unit in units)
            //{
            //    Debug.Log($"{unit.gameObject.name} hashcode is {unit.GetHashCode()}");
            //}

            Application.targetFrameRate = 60;
        }
    }
}