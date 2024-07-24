using System;
using Lessons.Architecture.SaveLoad;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class SaveLoadUIController : IInitializable // todo rename to controller?
    {
        private readonly Button _saveButton;
        private readonly Button _loadButton;
        private readonly SaveLoadManager _saveLoadManager;

        public SaveLoadUIPresenter(Button saveButton, Button loadButton, SaveLoadManager saveLoadManager)
        {
            _saveButton = saveButton;
            _loadButton = loadButton;
            _saveLoadManager = saveLoadManager;
        }

        void IInitializable.Initialize()
        {
            _saveButton.onClick.AddListener(() => _saveLoadManager.Save());
            _loadButton.onClick.AddListener(() => _saveLoadManager.Load());
        }
    }
}
