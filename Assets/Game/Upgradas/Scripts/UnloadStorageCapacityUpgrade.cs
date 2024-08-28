using Zenject;

namespace Upgrades
{
	public sealed class UnloadStorageCapacityUpgrade : Upgrade
	{
		private ConveyorModel _conveyorModel;

		[Inject]
		public void Construct(ConveyorModel conveyorModel)
		{
			_conveyorModel = conveyorModel;
		}

		public UnloadStorageCapacityUpgrade(UpgradeConfig config) : base(config)
		{
		}

		public override void OnLevelUp(int i)
		{
			_conveyorModel.UnloadStorageCapacity.Value += 1;
		}
	}
}