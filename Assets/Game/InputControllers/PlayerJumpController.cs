using System;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class PlayerJumpController : IInitializable, IDisposable
	{
		private readonly IEntity _character;
		private readonly InputListener _inputListener;

		[Inject]
		public PlayerJumpController(IEntity character, InputListener inputListener)
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
			if (command is JumpCommand jumpCommand)
			{
				jumpCommand.Execute(_character);
			}
		}

		public void Dispose()
		{
			_inputListener.OnCommand -= OnJumpCommand;
		}
	}
}