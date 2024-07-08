using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class CharacterStatView : MonoBehaviour
    {        
        [SerializeField] private TMP_Text _value;

        public void Show(object presenter)
        {
            //_value.text = presenter.StatValue.ToString();
        }
    }
}