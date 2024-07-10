using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsView : MonoBehaviour
    {
        private CharacterStatView _characterStatPrefab;
        private List<CharacterStatView> _statViews = new();
        [SerializeField]
        private Transform[] _statTransforms;
        private ICharacterAllStatsPresenter _characterAllStatsPresenter;

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

            //for (var index = 0; index < shopPopupPresenter.ProductPresenters.Count; index++)
            //{
            //    var productPresenter = shopPopupPresenter.ProductPresenters[index];
            //    ProductView view = Instantiate(_viewPrefab, _container);
            //    view.Initialized(productPresenter);
            //    _views.Add(view);
            //}
        }

        public void Hide()
        {
            foreach (var statView in _statViews)
            {
                statView.Hide();
            }
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