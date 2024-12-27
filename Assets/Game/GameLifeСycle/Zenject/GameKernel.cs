using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class GameKernel : MonoKernel
	{
		[Inject(Optional = true, Source = InjectSources.Local)]
		private List<IGameTickable> _tickables = new();
		[Inject(Optional = true, Source = InjectSources.Local)]
		private List<IGameFixedTickable> _fixedTickables = new();
		[Inject(Optional = true, Source = InjectSources.Local)]
		private List<IGameLateTickable> _lateTickables = new();

		[Inject]
		private GameStateManager _gameStateManager;

		public override void Start()
		{
			_gameStateManager.OnStateChanged += OnStartGame;
		}

		private void OnStartGame(GameState state)
		{
			if (state == GameState.Start)
			{
				base.Start();
			}
		}

		public override void Update()
		{
			base.Update();
			if (_gameStateManager.State is GameState.Pause or GameState.Finish)
			{
				return;
			}
			
			float deltaTime = Time.deltaTime;
			foreach (var tickable in _tickables)
			{
				tickable.Tick(deltaTime);
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (_gameStateManager.State is GameState.Pause or GameState.Finish)
			{
				return;
			}
			
			float deltaTime = Time.fixedDeltaTime;
			foreach (var tickable in _fixedTickables)
			{
				tickable.FixedTick(deltaTime);
			}
		}

		public override void LateUpdate()
		{
			base.LateUpdate();
			if (_gameStateManager.State is GameState.Pause or GameState.Finish)
			{
				return;
			}
			
			float deltaTime = Time.deltaTime;
			foreach (var tickable in _lateTickables)
			{
				tickable.LateTick(deltaTime);
			}
		}
	}
}