using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class GameOverController : IInitializable, IDisposable
	{
		private readonly GamePipelineRunner _gamePipelineRunner;
		private readonly GameObject _gameOverScreen;
		private readonly TMP_Text _playerText;

		[Inject]
		public GameOverController(GamePipelineRunner gamePipelineRunner, GameObject gameOverScreen, TMP_Text playerText)
		{
			_gamePipelineRunner = gamePipelineRunner;
			_gameOverScreen = gameOverScreen;
			_playerText = playerText;
		}

		public void Initialize()
		{
			_gamePipelineRunner.OnNoHeroesLeft += GameOver;
		}

		private void GameOver(Player player)
		{
			var winner = player == Player.Blue
				? Player.Red
				: Player.Blue;
			_gameOverScreen.SetActive(true);
			_playerText.text = $"Player {winner.ToString()} won!";
		}

		public void Dispose()
		{
			_gamePipelineRunner.OnNoHeroesLeft -= GameOver;
		}
	}
}