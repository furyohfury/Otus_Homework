using Zenject;

namespace Upgrades
{
	public sealed class LoadStorageCapacityUpgrade : Upgrade
	{
		private ConveyorModel _conveyorModel;

		[Inject]
		public void Construct(ConveyorModel conveyorModel)
		{
			_conveyorModel = conveyorModel;
		}

		public LoadStorageCapacityUpgrade(UpgradeConfig config) : base(config)
		{
		}

		public override void OnLevelUp(int level)
		{
			_conveyorModel.LoadStorageCapacity.Value += 1;
		}
	}
}