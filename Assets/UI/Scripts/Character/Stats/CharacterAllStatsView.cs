using System.Collections.Generic;
using System.Linq;
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

        public void Show(IPresenter presenter) //todo subscribe on change of PModel collection
        {
            if (presenter is not ICharacterAllStatsPresenter charStatsPresenter)
            {
                throw new System.Exception("Needed ICharacterAllStatsPresenter");
            }
            _characterAllStatsPresenter = charStatsPresenter;
            for (int i = 0; i < charStatsPresenter.StatPresenters.Count; i++)
            {
                var statPresenter = charStatsPresenter.StatPresenters[i];
                ShowStat(CreateStat(), statPresenter);
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
            var statGO = Instantiate(_characterStatPrefab, transform);
            _statViews.Add(statGO); //todo look when to add
            statGO.transform.position = _statTransforms[_statViews.Count].position;
            return statGO;
        }

        private void OnValidate() // todo check if works
        {
            _statTransforms.
                OrderByDescending(transform => transform.position.y).
                ThenBy(transform => transform.position.x);
        }
    }
}