using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Popup.UI.User
{
    public sealed class UserView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;

        private readonly CompositeDisposable _disposable = new();

        public void Show(IPresenter presenter)
        {
            if (presenter is not IUserPresenter userPresenter)
            {
                throw new System.Exception("UserView needed IUserPresenter");
            }
            userPresenter.Name.Subscribe(ChangeName)
                .AddTo(_disposable);
            userPresenter.Description.Subscribe(ChangeDescription)
                .AddTo(_disposable);
            userPresenter.Icon.Subscribe(ChangeIcon)
                .AddTo(_disposable);

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _disposable.Clear();
            gameObject.SetActive(false);
        }

        private void ChangeIcon(Sprite sprite) => _icon.sprite = sprite;

        private void ChangeDescription(string desc) => _description.text = desc;

        private void ChangeName(string name) => _name.text = name;
    }
}