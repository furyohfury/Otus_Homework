using System;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class PlayerAttackController : IInitializable, IDisposable
	{
		private readonly IEntity _character;
		private readonly InputListener _inputListener;

		[Inject]
		public PlayerAttackController(IEntity character, InputListener inputListener)
		{
			_character = character;
			_inputListener = inputListener;
		}

		public void Initialize()
		{
			_inputListener.OnCommand += OnJumpCommand;
		}

		private void OnJumpCommand(InputCommand command)
		{
			if (command is AttackCommand attackCommand)
			{
				attackCommand.Execute(_character);
			}
		}

		public void Dispose()
		{
			_inputListener.OnCommand -= OnJumpCommand;
		}
	}
}