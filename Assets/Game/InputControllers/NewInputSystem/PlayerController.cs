using System;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerController : IInitializable, IDisposable
	{
		private readonly InputReader _inputReader;
		private readonly PlayerService _playerService;

		[Inject]
		public PlayerController(InputReader inputReader, PlayerService playerService)
		{
			_inputReader = inputReader;
			_playerService = playerService;
		}

		public void Initialize()
		{
			_inputReader.OnMove += OnMove;
			_inputReader.OnJumped += OnJump;
			_inputReader.OnAttacked += OnAttack;
			_inputReader.OnAbilityUsed += OnAbility;
		}

		private void OnMove(Vector2 moveDirection)
		{
			IEntity player = _playerService.Player;
			player.GetMoveDirection().Value = moveDirection;
		}

		private void OnJump()
		{
			IEntity player = _playerService.Player;
			player.GetJumpRequest().Invoke();
		}

		private void OnAttack()
		{
			IEntity player = _playerService.Player;
			player.GetAttackRequest().Invoke();
		}

		private void OnAbility()
		{
			IEntity player = _playerService.Player;
			player.GetAbilityRequest().Invoke();
		}

		public void Dispose()
		{
			_inputReader.OnMove -= OnMove;
			_inputReader.OnAttacked -= OnAttack;
			_inputReader.OnAbilityUsed -= OnAbility;
		}
	}
}