using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public sealed class GameStateDebugHelper : MonoBehaviour
	{
#if UNITY_EDITOR
		[ShowInInspector]
		public GameState CurrentGameState => _gameStateManager.State;

		private GameStateManager _gameStateManager;

		[Inject]
		public void Construct(GameStateManager gameStateManager)
		{
			_gameStateManager = gameStateManager;
		}
#endif
	}
}