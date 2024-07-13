using UnityEngine;

namespace Lessons.Architecture.PM
{
    [CreateAssetMenu(fileName = "UserConfig", menuName = "Create config/UserConfig")]
    public sealed class UserConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
    }
}