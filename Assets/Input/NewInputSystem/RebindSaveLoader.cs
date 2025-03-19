using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public sealed class RebindSaveLoader : IRebindSaveLoader
	{
		private readonly InputControls _inputControls;
		private const string PREFS_KEY = "Rebinds";

		public RebindSaveLoader(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		void IRebindSaveLoader.Save()
		{
			string rebinds = _inputControls.SaveBindingOverridesAsJson();
			PlayerPrefs.SetString(PREFS_KEY, rebinds);
		}

		void IRebindSaveLoader.Load()
		{
			string rebinds = PlayerPrefs.GetString(PREFS_KEY);
			if (!string.IsNullOrEmpty(rebinds))
			{
				_inputControls.LoadBindingOverridesFromJson(rebinds);
			}
		}
	}
}