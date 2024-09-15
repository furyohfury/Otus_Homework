using System.Collections.Generic;
using Entities;
using Game.EventBus;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public class DebugHelper : MonoBehaviour
	{
		private GamePipelineRunner _turnPipelineRunner;
		private CurrentHeroService _currentHeroService;

		[SerializeField]
		private HeroListView _redPlayerViews;
		[SerializeField]
		private HeroView _heroView;

		[SerializeField]
		private Button _herobutton;
		[SerializeField]
		private Button _debugButton;
		[SerializeField]
		private DiContainer _diContainer;

		// [ShowInInspector]
		private HeroEntity _currentHero => _currentHeroService.CurrentHero;

		private List<HeroEntity> _playerOneHeroes;

		private void Start()
		{
			// _diContainer.Instantiate<>()
			// _playerOneHeroes = _turnPipelineRunner.GetType().GetField("")
		}

		private void RedPlayerViewsOnOnHeroClicked(HeroView obj)
		{
			Debug.Log($"hero {obj.name} clicked");
		}


		[Inject]
		public void Construct(CurrentHeroService currentHeroService, GamePipelineRunner turnPipelineRunner,
			DiContainer diContainer)
		{
			_currentHeroService = currentHeroService;
			_turnPipelineRunner = turnPipelineRunner;
			_diContainer = diContainer;
		}

		[Button]
		public void SetCurrentHero(HeroEntity hero)
		{
			_currentHeroService.SetCurrentHero(hero);
		}

		[Button]
		public void RunTurnPipeline()
		{
			_turnPipelineRunner.Run();
		}
	}
}