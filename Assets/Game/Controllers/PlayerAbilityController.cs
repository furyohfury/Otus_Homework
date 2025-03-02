using System;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class PlayerAbilityController : IInitializable, IDisposable
	{
		private readonly IEntity _character;
		private readonly InputListener _inputListener;

		[Inject]
		public PlayerAbilityController(IEntity character, InputListener inputListener)
		{
			_character = character;
			_inputListener = inputListener;
		}

		public void Initialize()
		{
			_inputListener.OnCommand += OnMoveXCommand;
		}

		private void OnMoveXCommand(InputCommand command)
		{
			if (command is AbilityCommand abilityCommand)
			{
				abilityCommand.Execute(_character);
			}
		}

		public void Dispose()
		{
			_inputListener.OnCommand -= OnMoveXCommand;
		}
	}
}