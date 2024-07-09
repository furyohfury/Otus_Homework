using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsView : MonoBehaviour
    {
        private CharacterStatView _characterStatPrefab;
        private HashSet<CharacterStatView> _stats = new();
        [SerializeField] 
        private Transform[] _statTransforms;       
                
        public AddStat(string stat)
        {
            var statGO = Instantiate(_characterStatPrefab, transform);
            statGO.SetStat(stat);
            statGO.position = _statTransforms[_stats.Count].position;
            _stats.Add(statGO); //todo look when to add
        }

        public void RemoveStat()

        private void OnValidate() // todo check if works
        {
            _statTransforms.
                OrderByDescending(transform => transform.position.y).
                ThenBy(transform => transform.position.x);
        }
    }
}