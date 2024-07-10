using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsView : MonoBehaviour
    {
        private CharacterStatView _characterStatPrefab;
        private List<CharacterStatView> _stats = new();
        [SerializeField]
        private Transform[] _statTransforms;

        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterAllStatsPresenter charStatsPresenter)
            {
                throw new System.Exception("Needed ICharacterAllStatsPresenter");
            }
            foreach(var stat in _stats)
        }

        public void AddStat(string stat)
        {
            var statGO = Instantiate(_characterStatPrefab, transform);            
            _stats.Add(statGO); //todo look when to add
            statGO.SetStat(stat);
            statGO.transform.position = _statTransforms[_stats.Count].position;
            statGO.gameObject.SetActive(false);            
        }

        public void RemoveStat()
        {

        }

        private void OnValidate() // todo check if works
        {
            _statTransforms.
                OrderByDescending(transform => transform.position.y).
                ThenBy(transform => transform.position.x);
        }
    }
}