using System.Collections.Generic;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class RebindMenuPresenter : IInitializable
	{
		private readonly InputRebindMenuConfig _rebindMenuConfig;
		private readonly RebindMenuView _rebindMenuView;
		private InputRebinder _inputRebinder;
		private List<RebindButtonPresenter> _presenters = new();

		[Inject]
		public RebindMenuPresenter(InputRebindMenuConfig rebindMenuConfig, RebindMenuView rebindMenuView, InputRebinder inputRebinder)
		{
			_rebindMenuConfig = rebindMenuConfig;
			_rebindMenuView = rebindMenuView;
			_inputRebinder = inputRebinder;
		}

		void IInitializable.Initialize()
		{
			SpawnActionsViews();
		}

		private void SpawnActionsViews()
		{
			var data = _rebindMenuConfig.Data;

			for (int i = 0, count = data.Length; i < count; i++)
			{
				var displayName = data[i].ActionDisplayName;
				var bindText = InputControlPath.ToHumanReadableString(data[i].Path, InputControlPath.HumanReadableStringOptions.OmitDevice);
				var view = _rebindMenuView.CreateRebindView(displayName, bindText);
				
				var presenter = new RebindButtonPresenter(view, _inputRebinder, data[i]);
				_presenters.Add(presenter);
				presenter.Init();
			}
		}
	}
}