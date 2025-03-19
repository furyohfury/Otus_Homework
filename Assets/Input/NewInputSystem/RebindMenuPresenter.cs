using System.Collections.Generic;
using Zenject;

namespace Game
{
	public sealed class RebindMenuPresenter : IInitializable
	{
		private readonly InputRebindMenuConfig _rebindMenuConfig;
		private readonly RebindMenuView _rebindMenuView;
		private readonly InputRebinder _inputRebinder;
		private readonly BindPathService _bindPathService;
		private readonly List<RebindButtonPresenter> _presenters = new();

		[Inject]
		public RebindMenuPresenter(InputRebindMenuConfig rebindMenuConfig, RebindMenuView rebindMenuView, InputRebinder inputRebinder
			, BindPathService bindPathService)
		{
			_rebindMenuConfig = rebindMenuConfig;
			_rebindMenuView = rebindMenuView;
			_inputRebinder = inputRebinder;
			_bindPathService = bindPathService;
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
				var view = _rebindMenuView.CreateRebindView();
				var currentPath = _bindPathService.GetFormattedPath(data[i].Action, _rebindMenuConfig.Scheme);
				var presenter = new RebindButtonPresenter(view, _inputRebinder, data[i], currentPath);
				_presenters.Add(presenter);
				presenter.Init();
			}
		}
	}
}