
using Entities;
using Lessons.Lesson19_EventBus;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public class DebugHelper : MonoBehaviour
	{
		private TurnPipelineRunner _turnPipelineRunner;
		private CurrentHeroService _currentHeroService;
		
		[SerializeField]
		private HeroListView _redPlayerViews;
		[SerializeField]
		private HeroView _heroView;
		
		[SerializeField]
		private Button _herobutton;
		[SerializeField]
		private Button _debugButton;

		// [ShowInInspector]
		private HeroEntity _currentHero => _currentHeroService.CurrentHero;

		private void Start()
		{
			// _redPlayerViews = FindObjectOfType<UIService>().GetRedPlayer();
			// _redPlayerViews.OnHeroClicked += RedPlayerViewsOnOnHeroClicked;
		}
		
		private void RedPlayerViewsOnOnHeroClicked(HeroView obj)
		{
			Debug.Log($"hero {obj.name} clicked");
		}


		[Inject]
		public void Construct(CurrentHeroService currentHeroService, TurnPipelineRunner turnPipelineRunner)
		{
			_currentHeroService = currentHeroService;
			_turnPipelineRunner = turnPipelineRunner;
		}

		[Button]
		public void SetCurrentHero(HeroEntity hero)
		{
			_currentHeroService._currentHero = hero;
		}

		[Button]
		public void RunTurnPipeline() => _turnPipelineRunner.Run();
	}
}