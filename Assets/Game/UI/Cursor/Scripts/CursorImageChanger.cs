using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class CursorImageChanger : IInitializable, IDisposable
	{
		private readonly LevelManager _levelManager;
		private readonly GameStateManager _gameStateManager;
		private readonly CursorSpritesConfig _cursorSpritesConfig;

		private Vector2 _gameplayCursorHotspot;

		public CursorImageChanger(
			LevelManager levelManager,
			GameStateManager gameStateManager,
			CursorSpritesConfig cursorSpritesConfig)
		{
			_levelManager = levelManager;
			_gameStateManager = gameStateManager;
			_cursorSpritesConfig = cursorSpritesConfig;
		}

		public void Initialize()
		{
			_levelManager.OnLevelStarted += OnLevelStart;
			_levelManager.OnLevelFinished += OnLevelFinished;

			_gameStateManager.OnStateChanged += OnGameStateChanged;

			var gameplaySprite = _cursorSpritesConfig.Sprites[CursorState.Gameplay];
			_gameplayCursorHotspot = new Vector2(gameplaySprite.texture.width / 2f, gameplaySprite.texture.height / 2f);
		}

		private void OnLevelStart()
		{
			SetGameplayCursor();
		}

		private void OnLevelFinished()
		{
			SetUICursor();
		}

		private void OnGameStateChanged(GameState state)
		{
			if (state is GameState.Pause or GameState.Finish or GameState.Start)
			{
				SetUICursor();
			}
			else if (state is GameState.Resume)
			{
				SetGameplayCursor();
			}
		}

		public void SetGameplayCursor()
		{
			Cursor.SetCursor(_cursorSpritesConfig.Sprites[CursorState.Gameplay].texture, _gameplayCursorHotspot, CursorMode.Auto);
		}

		public void SetUICursor()
		{
			Cursor.SetCursor(_cursorSpritesConfig.Sprites[CursorState.UI].texture, new Vector2(0, 0), CursorMode.Auto);
		}

		public void Dispose()
		{
			_levelManager.OnLevelStarted -= OnLevelStart;
			_levelManager.OnLevelFinished -= OnLevelFinished;

			_gameStateManager.OnStateChanged -= OnGameStateChanged;
		}
	}
}