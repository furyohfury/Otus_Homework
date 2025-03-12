using System.Collections.Generic;
using SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public class GameRepositoryDebugHelper : MonoBehaviour
	{
		[ShowInInspector]
		public IReadOnlyDictionary<string, string> gamestate => _gameRepository.GameState;

		private GameRepository _gameRepository;

		private void Awake()
		{
			var projectContext = FindObjectOfType<ProjectContext>();
			_gameRepository = projectContext.Container.Resolve<GameRepository>();
		}
	}
}