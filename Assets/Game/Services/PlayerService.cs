using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class PlayerService
	{
		public IEntity Player => _player;

		private readonly SceneEntity _player;

		[Inject]
		public PlayerService(SceneEntity player)
		{
			_player = player;
		}
	}
}