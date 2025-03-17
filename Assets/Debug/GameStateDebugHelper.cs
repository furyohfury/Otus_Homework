using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public sealed class GameStateDebugHelper : MonoBehaviour
	{
		[ShowInInspector]
		public GameState CurrentGameState => _gameStateManager.State;
		
		private GameStateManager _gameStateManager;

		[Inject]
		public void Construct(GameStateManager gameStateManager)
		{
			_gameStateManager = gameStateManager;
		}
	}
}