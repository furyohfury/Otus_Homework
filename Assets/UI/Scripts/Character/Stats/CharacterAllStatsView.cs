using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsView : MonoBehaviour
    {
        private CharacterStatView _characterStatPrefab;
        private List<CharacterStatView> _statViews = new();
        [SerializeField]
        private Transform[] _statTransforms;
        private ICharacterAllStatsPresenter _characterAllStatsPresenter;

        [Inject]
        private void Construct(CharacterStatView characterStatView)
        {
            _characterStatPrefab = characterStatView;
        }

        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterAllStatsPresenter charStatsPresenter)
            {
                throw new System.Exception("Needed ICharacterAllStatsPresenter");
            }

            _characterAllStatsPresenter = charStatsPresenter;
            foreach (var pres in _characterAllStatsPresenter.StatPresenters)
            {
                var statView = CreateStat();
                ShowStat(statView, pres);
            }
        }

        public void Hide()
        {
            foreach (var statView in _statViews)
            {
                Destroy(statView.gameObject);
            }
            _statViews.Clear();
        }

        public void ShowStat(CharacterStatView view, IStatPresenter presenter)
        {
            view.Show(presenter);
        }

        public CharacterStatView CreateStat()
        {
            var statTransform = _statTransforms[_statViews.Count];
            var statGO = Instantiate(_characterStatPrefab, statTransform);
            statGO.transform.position = statTransform.position;
            _statViews.Add(statGO);
            return statGO;
        }

        //public void RemoveStat(string stat) => _statViews.Remove

        private void OnValidate() // todo check if works
        {
            _statTransforms.
                OrderByDescending(transform => transform.position.y).
                ThenBy(transform => transform.position.x);
        }
    }
}